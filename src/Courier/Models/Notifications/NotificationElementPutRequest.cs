using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Notifications;

/// <summary>
/// Request body for updating a single element. Additional type-specific fields are allowed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<NotificationElementPutRequest, NotificationElementPutRequestFromRaw>)
)]
public sealed record class NotificationElementPutRequest : JsonModel
{
    /// <summary>
    /// Element type (text, meta, action, image, etc.).
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public IReadOnlyList<string>? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("channels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "channels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "data",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? If
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("if");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("if", value);
        }
    }

    public string? Loop
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("loop");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("loop", value);
        }
    }

    public string? Ref
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ref");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ref", value);
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
        _ = this.Type;
        _ = this.Channels;
        _ = this.Data;
        _ = this.If;
        _ = this.Loop;
        _ = this.Ref;
        this.State?.Validate();
    }

    public NotificationElementPutRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationElementPutRequest(
        NotificationElementPutRequest notificationElementPutRequest
    )
        : base(notificationElementPutRequest) { }
#pragma warning restore CS8618

    public NotificationElementPutRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationElementPutRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationElementPutRequestFromRaw.FromRawUnchecked"/>
    public static NotificationElementPutRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NotificationElementPutRequest(string type)
        : this()
    {
        this.Type = type;
    }
}

class NotificationElementPutRequestFromRaw : IFromRawJson<NotificationElementPutRequest>
{
    /// <inheritdoc/>
    public NotificationElementPutRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationElementPutRequest.FromRawUnchecked(rawData);
}
