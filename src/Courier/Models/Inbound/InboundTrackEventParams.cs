using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using InboundTrackEventParamsProperties = Courier.Models.Inbound.InboundTrackEventParamsProperties;

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
                    new ArgumentOutOfRangeException("event", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'event' cannot be null",
                    new ArgumentNullException("event")
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
                    new ArgumentOutOfRangeException("messageId", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'messageId' cannot be null",
                    new ArgumentNullException("messageId")
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
                    new ArgumentOutOfRangeException("properties", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'properties' cannot be null",
                    new ArgumentNullException("properties")
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

    public required ApiEnum<string, InboundTrackEventParamsProperties::Type> Type
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("type", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, InboundTrackEventParamsProperties::Type>
            >(element, ModelBase.SerializerOptions);
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

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/inbound/courier")
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
