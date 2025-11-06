using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

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

[JsonConverter(typeof(ModelConverter<Topic>))]
public sealed record class Topic : ModelBase, IFromRaw<Topic>
{
    public required ApiEnum<string, PreferenceStatus> Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, PreferenceStatus>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The Channels a user has chosen to receive notifications through for this topic
    /// </summary>
    public List<ApiEnum<string, ChannelClassification>>? CustomRouting
    {
        get
        {
            if (!this.Properties.TryGetValue("custom_routing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ApiEnum<string, ChannelClassification>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["custom_routing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? HasCustomRouting
    {
        get
        {
            if (!this.Properties.TryGetValue("has_custom_routing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["has_custom_routing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Status.Validate();
        foreach (var item in this.CustomRouting ?? [])
        {
            item.Validate();
        }
        _ = this.HasCustomRouting;
    }

    public Topic() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Topic(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Topic FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Topic(ApiEnum<string, PreferenceStatus> status)
        : this()
    {
        this.Status = status;
    }
}
