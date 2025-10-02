using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Auth;

/// <summary>
/// Returns a new access token.
/// </summary>
public sealed record class AuthIssueTokenParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string ExpiresIn
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("expires_in", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'expires_in' cannot be null",
                    new ArgumentOutOfRangeException("expires_in", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'expires_in' cannot be null",
                    new ArgumentNullException("expires_in")
                );
        }
        set
        {
            this.BodyProperties["expires_in"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Scope
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("scope", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'scope' cannot be null",
                    new ArgumentOutOfRangeException("scope", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'scope' cannot be null",
                    new ArgumentNullException("scope")
                );
        }
        set
        {
            this.BodyProperties["scope"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/auth/issue-token")
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
