using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Users.Preferences;

/// <summary>
/// Update or Create user preferences for a specific subscription topic.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PreferenceUpdateOrCreateTopicParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string UserID { get; init; }

    public string? TopicID { get; init; }

    public required PreferenceUpdateOrCreateTopicParamsTopic Topic
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<PreferenceUpdateOrCreateTopicParamsTopic>(
                "topic"
            );
        }
        init { this._rawBodyData.Set("topic", value); }
    }

    /// <summary>
    /// Update the preferences of a user for this specific tenant context.
    /// </summary>
    public string? TenantID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("tenant_id");
        }
        init { this._rawQueryData.Set("tenant_id", value); }
    }

    public PreferenceUpdateOrCreateTopicParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferenceUpdateOrCreateTopicParams(
        PreferenceUpdateOrCreateTopicParams preferenceUpdateOrCreateTopicParams
    )
        : base(preferenceUpdateOrCreateTopicParams)
    {
        this.UserID = preferenceUpdateOrCreateTopicParams.UserID;
        this.TopicID = preferenceUpdateOrCreateTopicParams.TopicID;

        this._rawBodyData = new(preferenceUpdateOrCreateTopicParams._rawBodyData);
    }
#pragma warning restore CS8618

    public PreferenceUpdateOrCreateTopicParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceUpdateOrCreateTopicParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string userID,
        string topicID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.UserID = userID;
        this.TopicID = topicID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PreferenceUpdateOrCreateTopicParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string userID,
        string topicID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            userID,
            topicID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["UserID"] = JsonSerializer.SerializeToElement(this.UserID),
                    ["TopicID"] = JsonSerializer.SerializeToElement(this.TopicID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(PreferenceUpdateOrCreateTopicParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.UserID.Equals(other.UserID)
            && (this.TopicID?.Equals(other.TopicID) ?? other.TopicID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/users/{0}/preferences/{1}", this.UserID, this.TopicID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        PreferenceUpdateOrCreateTopicParamsTopic,
        PreferenceUpdateOrCreateTopicParamsTopicFromRaw
    >)
)]
public sealed record class PreferenceUpdateOrCreateTopicParamsTopic : JsonModel
{
    /// <summary>
    /// The subscription status to set: OPTED_IN or OPTED_OUT. REQUIRED is a topic-level
    /// default, not a user choice; the API rejects opting a user out of a REQUIRED topic.
    /// </summary>
    public required ApiEnum<string, PreferenceStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PreferenceStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The channels to deliver this topic on when has_custom_routing is true. One
    /// or more of: direct_message, email, push, sms, webhook, inbox.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ChannelClassification>>? CustomRouting
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, ChannelClassification>>
            >("custom_routing");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, ChannelClassification>>?>(
                "custom_routing",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Set to true to route this topic to the channels in custom_routing instead
    /// of the topic's default routing.
    /// </summary>
    public bool? HasCustomRouting
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("has_custom_routing");
        }
        init { this._rawData.Set("has_custom_routing", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
        foreach (var item in this.CustomRouting ?? [])
        {
            item.Validate();
        }
        _ = this.HasCustomRouting;
    }

    public PreferenceUpdateOrCreateTopicParamsTopic() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferenceUpdateOrCreateTopicParamsTopic(
        PreferenceUpdateOrCreateTopicParamsTopic preferenceUpdateOrCreateTopicParamsTopic
    )
        : base(preferenceUpdateOrCreateTopicParamsTopic) { }
#pragma warning restore CS8618

    public PreferenceUpdateOrCreateTopicParamsTopic(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceUpdateOrCreateTopicParamsTopic(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferenceUpdateOrCreateTopicParamsTopicFromRaw.FromRawUnchecked"/>
    public static PreferenceUpdateOrCreateTopicParamsTopic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PreferenceUpdateOrCreateTopicParamsTopic(ApiEnum<string, PreferenceStatus> status)
        : this()
    {
        this.Status = status;
    }
}

class PreferenceUpdateOrCreateTopicParamsTopicFromRaw
    : IFromRawJson<PreferenceUpdateOrCreateTopicParamsTopic>
{
    /// <inheritdoc/>
    public PreferenceUpdateOrCreateTopicParamsTopic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreferenceUpdateOrCreateTopicParamsTopic.FromRawUnchecked(rawData);
}
