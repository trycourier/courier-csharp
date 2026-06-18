using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Notifications;

/// <summary>
/// Shared mutation response for `PUT` content, `PUT` element, and `PUT` locale operations.
/// Contains the template ID, content version, per-element checksums, and resulting state.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        NotificationContentMutationResponse,
        NotificationContentMutationResponseFromRaw
    >)
)]
public sealed record class NotificationContentMutationResponse : JsonModel
{
    /// <summary>
    /// Template ID.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required IReadOnlyList<NotificationContentMutationResponseElement> Elements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<NotificationContentMutationResponseElement>
            >("elements");
        }
        init
        {
            this._rawData.Set<ImmutableArray<NotificationContentMutationResponseElement>>(
                "elements",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Template state. Defaults to `DRAFT`.
    /// </summary>
    public required ApiEnum<string, NotificationTemplateState> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, NotificationTemplateState>>(
                "state"
            );
        }
        init { this._rawData.Set("state", value); }
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
        _ = this.ID;
        foreach (var item in this.Elements)
        {
            item.Validate();
        }
        this.State.Validate();
        _ = this.Version;
    }

    public NotificationContentMutationResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationContentMutationResponse(
        NotificationContentMutationResponse notificationContentMutationResponse
    )
        : base(notificationContentMutationResponse) { }
#pragma warning restore CS8618

    public NotificationContentMutationResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationContentMutationResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationContentMutationResponseFromRaw.FromRawUnchecked"/>
    public static NotificationContentMutationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationContentMutationResponseFromRaw : IFromRawJson<NotificationContentMutationResponse>
{
    /// <inheritdoc/>
    public NotificationContentMutationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationContentMutationResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        NotificationContentMutationResponseElement,
        NotificationContentMutationResponseElementFromRaw
    >)
)]
public sealed record class NotificationContentMutationResponseElement : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Checksum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("checksum");
        }
        init { this._rawData.Set("checksum", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Checksum;
    }

    public NotificationContentMutationResponseElement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationContentMutationResponseElement(
        NotificationContentMutationResponseElement notificationContentMutationResponseElement
    )
        : base(notificationContentMutationResponseElement) { }
#pragma warning restore CS8618

    public NotificationContentMutationResponseElement(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationContentMutationResponseElement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationContentMutationResponseElementFromRaw.FromRawUnchecked"/>
    public static NotificationContentMutationResponseElement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationContentMutationResponseElementFromRaw
    : IFromRawJson<NotificationContentMutationResponseElement>
{
    /// <inheritdoc/>
    public NotificationContentMutationResponseElement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationContentMutationResponseElement.FromRawUnchecked(rawData);
}
