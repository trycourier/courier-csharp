using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Notifications;

/// <summary>
/// Request body for setting locale-specific content overrides. Each element override
/// must include the target element ID.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<NotificationLocalePutRequest, NotificationLocalePutRequestFromRaw>)
)]
public sealed record class NotificationLocalePutRequest : JsonModel
{
    /// <summary>
    /// Elements with locale-specific content overrides.
    /// </summary>
    public required IReadOnlyList<NotificationLocalePutRequestElement> Elements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<NotificationLocalePutRequestElement>
            >("elements");
        }
        init
        {
            this._rawData.Set<ImmutableArray<NotificationLocalePutRequestElement>>(
                "elements",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Template state. Defaults to `DRAFT`.
    /// </summary>
    public ApiEnum<string, NotificationTemplateState>? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, NotificationTemplateState>>(
                "state"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("state", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Elements)
        {
            item.Validate();
        }
        this.State?.Validate();
    }

    public NotificationLocalePutRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationLocalePutRequest(NotificationLocalePutRequest notificationLocalePutRequest)
        : base(notificationLocalePutRequest) { }
#pragma warning restore CS8618

    public NotificationLocalePutRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationLocalePutRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationLocalePutRequestFromRaw.FromRawUnchecked"/>
    public static NotificationLocalePutRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NotificationLocalePutRequest(IReadOnlyList<NotificationLocalePutRequestElement> elements)
        : this()
    {
        this.Elements = elements;
    }
}

class NotificationLocalePutRequestFromRaw : IFromRawJson<NotificationLocalePutRequest>
{
    /// <inheritdoc/>
    public NotificationLocalePutRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationLocalePutRequest.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        NotificationLocalePutRequestElement,
        NotificationLocalePutRequestElementFromRaw
    >)
)]
public sealed record class NotificationLocalePutRequestElement : JsonModel
{
    /// <summary>
    /// Target element ID.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public NotificationLocalePutRequestElement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationLocalePutRequestElement(
        NotificationLocalePutRequestElement notificationLocalePutRequestElement
    )
        : base(notificationLocalePutRequestElement) { }
#pragma warning restore CS8618

    public NotificationLocalePutRequestElement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationLocalePutRequestElement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationLocalePutRequestElementFromRaw.FromRawUnchecked"/>
    public static NotificationLocalePutRequestElement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NotificationLocalePutRequestElement(string id)
        : this()
    {
        this.ID = id;
    }
}

class NotificationLocalePutRequestElementFromRaw : IFromRawJson<NotificationLocalePutRequestElement>
{
    /// <inheritdoc/>
    public NotificationLocalePutRequestElement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationLocalePutRequestElement.FromRawUnchecked(rawData);
}
