using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Users.Preferences.PreferenceUpdateOrCreateTopicParamsProperties;

namespace Courier.Models.Users.Preferences;

/// <summary>
/// Update or Create user preferences for a specific subscription topic.
/// </summary>
public sealed record class PreferenceUpdateOrCreateTopicParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string UserID;

    public required string TopicID;

    public required Topic Topic
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("topic", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'topic' cannot be null",
                    new ArgumentOutOfRangeException("topic", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Topic>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'topic' cannot be null",
                    new ArgumentNullException("topic")
                );
        }
        set
        {
            this.BodyProperties["topic"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Update the preferences of a user for this specific tenant context.
    /// </summary>
    public string? TenantID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("tenant_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["tenant_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/users/{0}/preferences/{1}", this.UserID, this.TopicID)
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
