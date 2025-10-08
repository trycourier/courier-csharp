using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Users.Tokens.TokenUpdateParamsProperties;
using Generic = System.Collections.Generic;

namespace Courier.Models.Users.Tokens;

/// <summary>
/// Apply a JSON Patch (RFC 6902) to the specified token.
/// </summary>
public sealed record class TokenUpdateParams : ParamsBase
{
    public Generic::Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string UserID;

    public required string Token;

    public required Generic::List<Patch> Patch
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("patch", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'patch' cannot be null",
                    new ArgumentOutOfRangeException("patch", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Generic::List<Patch>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'patch' cannot be null",
                    new ArgumentNullException("patch")
                );
        }
        set
        {
            this.BodyProperties["patch"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/users/{0}/tokens/{1}", this.UserID, this.Token)
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
