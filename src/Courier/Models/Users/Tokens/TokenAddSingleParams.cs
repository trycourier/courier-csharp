using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Users.Tokens.TokenAddSingleParamsProperties;

namespace Courier.Models.Users.Tokens;

/// <summary>
/// Adds a single token to a user and overwrites a matching existing token.
/// </summary>
public sealed record class TokenAddSingleParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string UserID;

    public required string Token;

    public required ApiEnum<string, ProviderKey> ProviderKey
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("provider_key", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'provider_key' cannot be null",
                    new ArgumentOutOfRangeException("provider_key", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ProviderKey>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["provider_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Full body of the token. Must match token in URL.
    /// </summary>
    public string? Token1
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("token", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["token"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Information about the device the token is associated with.
    /// </summary>
    public Device? Device
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("device", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Device?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["device"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// ISO 8601 formatted date the token expires. Defaults to 2 months. Set to false
    /// to disable expiration.
    /// </summary>
    public ExpiryDate? ExpiryDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("expiry_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ExpiryDate?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["expiry_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Properties sent to the provider along with the token
    /// </summary>
    public JsonElement? Properties
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("properties", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["properties"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Information about the device the token is associated with.
    /// </summary>
    public Tracking? Tracking
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("tracking", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Tracking?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["tracking"] = JsonSerializer.SerializeToElement(
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
