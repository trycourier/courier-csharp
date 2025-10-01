using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Send;

/// <summary>
/// Use the send API to send a message to one or more recipients.
/// </summary>
public sealed record class SendSendMessageParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// Defines the message to be delivered
    /// </summary>
    public required Message Message
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("message", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'message' cannot be null",
                    new ArgumentOutOfRangeException("message", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Message>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'message' cannot be null",
                    new ArgumentNullException("message")
                );
        }
        set
        {
            this.BodyProperties["message"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/send")
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
