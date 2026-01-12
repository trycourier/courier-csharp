using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Users.Preferences;

/// <summary>
/// Update or Create user preferences for a specific subscription topic.
/// </summary>
public sealed record class PreferenceUpdateOrCreateTopicParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string UserID { get; init; }

    public string? TopicID { get; init; }

    public required Topic Topic
    {
        get { return JsonModel.GetNotNullClass<Topic>(this.RawBodyData, "topic"); }
        init { JsonModel.Set(this._rawBodyData, "topic", value); }
    }

    /// <summary>
    /// Update the preferences of a user for this specific tenant context.
    /// </summary>
    public string? TenantID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "tenant_id"); }
        init { JsonModel.Set(this._rawQueryData, "tenant_id", value); }
    }

    public PreferenceUpdateOrCreateTopicParams() { }

    public PreferenceUpdateOrCreateTopicParams(
        PreferenceUpdateOrCreateTopicParams preferenceUpdateOrCreateTopicParams
    )
        : base(preferenceUpdateOrCreateTopicParams)
    {
        this.UserID = preferenceUpdateOrCreateTopicParams.UserID;
        this.TopicID = preferenceUpdateOrCreateTopicParams.TopicID;

        this._rawBodyData = [.. preferenceUpdateOrCreateTopicParams._rawBodyData];
    }

    public PreferenceUpdateOrCreateTopicParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceUpdateOrCreateTopicParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static PreferenceUpdateOrCreateTopicParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
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
            JsonSerializer.Serialize(this.RawBodyData),
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
}

[JsonConverter(typeof(JsonModelConverter<Topic, TopicFromRaw>))]
public sealed record class Topic : JsonModel
{
    public required ApiEnum<string, PreferenceStatus> Status
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, PreferenceStatus>>(
                this.RawData,
                "status"
            );
        }
        init { JsonModel.Set(this._rawData, "status", value); }
    }

    /// <summary>
    /// The Channels a user has chosen to receive notifications through for this topic
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ChannelClassification>>? CustomRouting
    {
        get
        {
            return JsonModel.GetNullableClass<List<ApiEnum<string, ChannelClassification>>>(
                this.RawData,
                "custom_routing"
            );
        }
        init { JsonModel.Set(this._rawData, "custom_routing", value); }
    }

    public bool? HasCustomRouting
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "has_custom_routing"); }
        init { JsonModel.Set(this._rawData, "has_custom_routing", value); }
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

    public Topic() { }

    public Topic(Topic topic)
        : base(topic) { }

    public Topic(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Topic(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopicFromRaw.FromRawUnchecked"/>
    public static Topic FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Topic(ApiEnum<string, PreferenceStatus> status)
        : this()
    {
        this.Status = status;
    }
}

class TopicFromRaw : IFromRawJson<Topic>
{
    /// <inheritdoc/>
    public Topic FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Topic.FromRawUnchecked(rawData);
}
