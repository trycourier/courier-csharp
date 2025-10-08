using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Generic = System.Collections.Generic;
using ListSubscribeParamsProperties = Courier.Models.Profiles.Lists.ListSubscribeParamsProperties;

namespace Courier.Models.Profiles.Lists;

/// <summary>
/// Subscribes the given user to one or more lists. If the list does not exist, it
/// will be created.
/// </summary>
public sealed record class ListSubscribeParams : ParamsBase
{
    public Generic::Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string UserID;

    public required Generic::List<ListSubscribeParamsProperties::List> Lists
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("lists", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'lists' cannot be null",
                    new ArgumentOutOfRangeException("lists", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Generic::List<ListSubscribeParamsProperties::List>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'lists' cannot be null",
                    new ArgumentNullException("lists")
                );
        }
        set
        {
            this.BodyProperties["lists"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/profiles/{0}/lists", this.UserID)
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
