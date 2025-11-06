using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Inbound;

/// <summary>
/// Courier Track Event
/// </summary>
public sealed record class InboundTrackEventParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// A descriptive name of the event. This name will appear as a trigger in the
    /// Courier Automation Trigger node.
    /// </summary>
    public required string Event
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("event", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'event' cannot be null",
                    new System::ArgumentOutOfRangeException("event", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'event' cannot be null",
                    new System::ArgumentNullException("event")
                );
        }
        set
        {
            this.BodyProperties["event"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A required unique identifier that will be used to de-duplicate requests.
    /// If not unique, will respond with 409 Conflict status
    /// </summary>
    public required string MessageID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("messageId", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'messageId' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "messageId",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'messageId' cannot be null",
                    new System::ArgumentNullException("messageId")
                );
        }
        set
        {
            this.BodyProperties["messageId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Dictionary<string, JsonElement> Properties
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("properties", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'properties' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "properties",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'properties' cannot be null",
                    new System::ArgumentNullException("properties")
                );
        }
        set
        {
            this.BodyProperties["properties"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, global::Courier.Models.Inbound.Type> Type
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("type", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, global::Courier.Models.Inbound.Type>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The user id associatiated with the track
    /// </summary>
    public string? UserID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("userId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["userId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override System::Uri Url(ICourierClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/inbound/courier")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ICourierClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(global::Courier.Models.Inbound.TypeConverter))]
public enum Type
{
    Track,
}

sealed class TypeConverter : JsonConverter<global::Courier.Models.Inbound.Type>
{
    public override global::Courier.Models.Inbound.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "track" => global::Courier.Models.Inbound.Type.Track,
            _ => (global::Courier.Models.Inbound.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Courier.Models.Inbound.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Courier.Models.Inbound.Type.Track => "track",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
