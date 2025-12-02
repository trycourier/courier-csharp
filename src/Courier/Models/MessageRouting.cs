using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<MessageRouting, MessageRoutingFromRaw>))]
public sealed record class MessageRouting : ModelBase
{
    public required IReadOnlyList<MessageRoutingChannel> Channels
    {
        get
        {
            if (!this._rawData.TryGetValue("channels", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'channels' cannot be null",
                    new System::ArgumentOutOfRangeException("channels", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<MessageRoutingChannel>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'channels' cannot be null",
                    new System::ArgumentNullException("channels")
                );
        }
        init
        {
            this._rawData["channels"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Method> Method
    {
        get
        {
            if (!this._rawData.TryGetValue("method", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'method' cannot be null",
                    new System::ArgumentOutOfRangeException("method", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Method>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'method' cannot be null",
                    new System::ArgumentNullException("method")
                );
        }
        init
        {
            this._rawData["method"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Channels)
        {
            item.Validate();
        }
        this.Method.Validate();
    }

    public MessageRouting() { }

    public MessageRouting(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageRouting(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static MessageRouting FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageRoutingFromRaw : IFromRaw<MessageRouting>
{
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
