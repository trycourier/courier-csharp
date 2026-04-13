using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Notifications;

/// <summary>
/// Elemental content response for V2 templates. Contains versioned elements with
/// content checksums.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        NotificationContentGetResponse,
        NotificationContentGetResponseFromRaw
    >)
)]
public sealed record class NotificationContentGetResponse : JsonModel
{
    public required IReadOnlyList<ElementWithChecksums> Elements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ElementWithChecksums>>("elements");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ElementWithChecksums>>(
                "elements",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Content version identifier.
    /// </summary>
    public required string Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("version");
        }
        init { this._rawData.Set("version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Elements)
        {
            item.Validate();
        }
        _ = this.Version;
    }

    public NotificationContentGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationContentGetResponse(
        NotificationContentGetResponse notificationContentGetResponse
    )
        : base(notificationContentGetResponse) { }
#pragma warning restore CS8618

    public NotificationContentGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationContentGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationContentGetResponseFromRaw.FromRawUnchecked"/>
    public static NotificationContentGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationContentGetResponseFromRaw : IFromRawJson<NotificationContentGetResponse>
{
    /// <inheritdoc/>
    public NotificationContentGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationContentGetResponse.FromRawUnchecked(rawData);
}
