using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Generic = System.Collections.Generic;

namespace Courier.Models.Lists.Subscriptions;

/// <summary>
/// Subscribes additional users to the list, without modifying existing subscriptions.
/// If the list does not exist, it will be automatically created.
/// </summary>
public sealed record class SubscriptionAddParams : ParamsBase
{
    public Generic::Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string ListID;

    public required Generic::List<PutSubscriptionsRecipient> Recipients
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("recipients", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'recipients' cannot be null",
                    new ArgumentOutOfRangeException("recipients", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Generic::List<PutSubscriptionsRecipient>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'recipients' cannot be null",
                    new ArgumentNullException("recipients")
                );
        }
        set
        {
            this.BodyProperties["recipients"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/lists/{0}/subscriptions", this.ListID)
        )
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
