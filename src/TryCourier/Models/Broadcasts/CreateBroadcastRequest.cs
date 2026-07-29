using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Broadcasts;

/// <summary>
/// Request body for creating a broadcast.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreateBroadcastRequest, CreateBroadcastRequestFromRaw>))]
public sealed record class CreateBroadcastRequest : JsonModel
{
    /// <summary>
    /// The single delivery channel for this broadcast.
    /// </summary>
    public required ApiEnum<string, CreateBroadcastRequestChannel> Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CreateBroadcastRequestChannel>>(
                "channel"
            );
        }
        init { this._rawData.Set("channel", value); }
    }

    /// <summary>
    /// Human-readable name.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Channel.Validate();
        _ = this.Name;
    }

    public CreateBroadcastRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreateBroadcastRequest(CreateBroadcastRequest createBroadcastRequest)
        : base(createBroadcastRequest) { }
#pragma warning restore CS8618

    public CreateBroadcastRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreateBroadcastRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreateBroadcastRequestFromRaw.FromRawUnchecked"/>
    public static CreateBroadcastRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreateBroadcastRequestFromRaw : IFromRawJson<CreateBroadcastRequest>
{
    /// <inheritdoc/>
    public CreateBroadcastRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreateBroadcastRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// The single delivery channel for this broadcast.
/// </summary>
[JsonConverter(typeof(CreateBroadcastRequestChannelConverter))]
public enum CreateBroadcastRequestChannel
{
    Email,
    Sms,
    Push,
    Inbox,
    Slack,
    Msteams,
}

sealed class CreateBroadcastRequestChannelConverter : JsonConverter<CreateBroadcastRequestChannel>
{
    public override CreateBroadcastRequestChannel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email" => CreateBroadcastRequestChannel.Email,
            "sms" => CreateBroadcastRequestChannel.Sms,
            "push" => CreateBroadcastRequestChannel.Push,
            "inbox" => CreateBroadcastRequestChannel.Inbox,
            "slack" => CreateBroadcastRequestChannel.Slack,
            "msteams" => CreateBroadcastRequestChannel.Msteams,
            _ => (CreateBroadcastRequestChannel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreateBroadcastRequestChannel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreateBroadcastRequestChannel.Email => "email",
                CreateBroadcastRequestChannel.Sms => "sms",
                CreateBroadcastRequestChannel.Push => "push",
                CreateBroadcastRequestChannel.Inbox => "inbox",
                CreateBroadcastRequestChannel.Slack => "slack",
                CreateBroadcastRequestChannel.Msteams => "msteams",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
