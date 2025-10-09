using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Bulk;

/// <summary>
/// Ingest user data into a Bulk Job
/// </summary>
public sealed record class BulkAddUsersParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string JobID;

    public required List<InboundBulkMessageUser> Users
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("users", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'users' cannot be null",
                    new ArgumentOutOfRangeException("users", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<InboundBulkMessageUser>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'users' cannot be null",
                    new ArgumentNullException("users")
                );
        }
        set
        {
            this.BodyProperties["users"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/bulk/{0}", this.JobID)
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
