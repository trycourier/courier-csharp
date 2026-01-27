using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<MessageRouting, MessageRoutingFromRaw>))]
public sealed record class MessageRouting : JsonModel
{
    public required IReadOnlyList<MessageRoutingChannel> Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MessageRoutingChannel>>(
                "channels"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<MessageRoutingChannel>>(
                "channels",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, Method> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Method>>("method");
        }
        init { this._rawData.Set("method", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Channels)
        {
            item.Validate();
        }
        this.Method.Validate();
    }

    public MessageRouting() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageRouting(MessageRouting messageRouting)
        : base(messageRouting) { }
#pragma warning restore CS8618

    public MessageRouting(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageRouting(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageRoutingFromRaw.FromRawUnchecked"/>
    public static MessageRouting FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageRoutingFromRaw : IFromRawJson<MessageRouting>
{
    /// <inheritdoc/>
    public MessageRouting FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageRouting.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MethodConverter))]
public enum Method
{
    All,
    Single,
}

sealed class MethodConverter : JsonConverter<Method>
{
    public override Method Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all" => Method.All,
            "single" => Method.Single,
            _ => (Method)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Method value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Method.All => "all",
                Method.Single => "single",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
