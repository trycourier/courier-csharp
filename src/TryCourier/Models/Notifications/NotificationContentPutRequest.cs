using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Notifications;

/// <summary>
/// Request body for replacing the elemental content of a notification template.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<NotificationContentPutRequest, NotificationContentPutRequestFromRaw>)
)]
public sealed record class NotificationContentPutRequest : JsonModel
{
    /// <summary>
    /// Elemental content payload. The server defaults `version` when omitted.
    /// </summary>
    public required NotificationContentPutRequestContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NotificationContentPutRequestContent>("content");
        }
        init { this._rawData.Set("content", value); }
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
        this.Content.Validate();
        this.State?.Validate();
    }

    public NotificationContentPutRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationContentPutRequest(
        NotificationContentPutRequest notificationContentPutRequest
    )
        : base(notificationContentPutRequest) { }
#pragma warning restore CS8618

    public NotificationContentPutRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationContentPutRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationContentPutRequestFromRaw.FromRawUnchecked"/>
    public static NotificationContentPutRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NotificationContentPutRequest(NotificationContentPutRequestContent content)
        : this()
    {
        this.Content = content;
    }
}

class NotificationContentPutRequestFromRaw : IFromRawJson<NotificationContentPutRequest>
{
    /// <inheritdoc/>
    public NotificationContentPutRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationContentPutRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Elemental content payload. The server defaults `version` when omitted.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        NotificationContentPutRequestContent,
        NotificationContentPutRequestContentFromRaw
    >)
)]
public sealed record class NotificationContentPutRequestContent : JsonModel
{
    public required IReadOnlyList<ElementalNode> Elements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ElementalNode>>("elements");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ElementalNode>>(
                "elements",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Content version identifier (e.g., `2022-01-01`). Optional; server defaults
    /// when omitted.
    /// </summary>
    public string? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("version", value);
        }
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

    public NotificationContentPutRequestContent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationContentPutRequestContent(
        NotificationContentPutRequestContent notificationContentPutRequestContent
    )
        : base(notificationContentPutRequestContent) { }
#pragma warning restore CS8618

    public NotificationContentPutRequestContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationContentPutRequestContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationContentPutRequestContentFromRaw.FromRawUnchecked"/>
    public static NotificationContentPutRequestContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NotificationContentPutRequestContent(IReadOnlyList<ElementalNode> elements)
        : this()
    {
        this.Elements = elements;
    }
}

class NotificationContentPutRequestContentFromRaw
    : IFromRawJson<NotificationContentPutRequestContent>
{
    /// <inheritdoc/>
    public NotificationContentPutRequestContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationContentPutRequestContent.FromRawUnchecked(rawData);
}
