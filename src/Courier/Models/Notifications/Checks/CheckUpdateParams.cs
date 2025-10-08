using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Generic = System.Collections.Generic;

namespace Courier.Models.Notifications.Checks;

public sealed record class CheckUpdateParams : ParamsBase
{
    public Generic::Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string ID;

    public required string SubmissionID;

    public required Generic::List<BaseCheck> Checks
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("checks", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'checks' cannot be null",
                    new ArgumentOutOfRangeException("checks", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Generic::List<BaseCheck>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'checks' cannot be null",
                    new ArgumentNullException("checks")
                );
        }
        set
        {
            this.BodyProperties["checks"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/notifications/{0}/{1}/checks", this.ID, this.SubmissionID)
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
