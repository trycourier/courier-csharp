using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.WorkspacePreferences.Topics;

/// <summary>
/// Replace a topic within a workspace preference. Full document replacement; missing
/// optional fields are cleared. Same 404 rules as GET.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TopicReplaceParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string SectionID { get; init; }

    public string? TopicID { get; init; }

    /// <summary>
    /// The default subscription status applied when a recipient has not set their own.
    /// </summary>
    public required ApiEnum<string, TopicReplaceParamsDefaultStatus> DefaultStatus
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<
                ApiEnum<string, TopicReplaceParamsDefaultStatus>
            >("default_status");
        }
        init { this._rawBodyData.Set("default_status", value); }
    }

    /// <summary>
    /// Human-readable name for the preference topic.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Preference controls a recipient may customize. Omit to clear.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, TopicReplaceParamsAllowedPreference>>? AllowedPreferences
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, TopicReplaceParamsAllowedPreference>>
            >("allowed_preferences");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<
                ApiEnum<string, TopicReplaceParamsAllowedPreference>
            >?>(
                "allowed_preferences",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether to include a list-unsubscribe header on emails for this topic.
    /// </summary>
    public bool? IncludeUnsubscribeHeader
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("include_unsubscribe_header");
        }
        init { this._rawBodyData.Set("include_unsubscribe_header", value); }
    }

    /// <summary>
    /// Default channels delivered for this topic. Omit to clear.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ChannelClassification>>? RoutingOptions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, ChannelClassification>>
            >("routing_options");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ApiEnum<string, ChannelClassification>>?>(
                "routing_options",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Arbitrary metadata associated with the topic. Omit to clear.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? TopicData
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "topic_data"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "topic_data",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public TopicReplaceParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopicReplaceParams(TopicReplaceParams topicReplaceParams)
        : base(topicReplaceParams)
    {
        this.SectionID = topicReplaceParams.SectionID;
        this.TopicID = topicReplaceParams.TopicID;

        this._rawBodyData = new(topicReplaceParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TopicReplaceParams(
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
    TopicReplaceParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string sectionID,
        string topicID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.SectionID = sectionID;
        this.TopicID = topicID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TopicReplaceParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string sectionID,
        string topicID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            sectionID,
            topicID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["SectionID"] = JsonSerializer.SerializeToElement(this.SectionID),
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

    public virtual bool Equals(TopicReplaceParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.SectionID.Equals(other.SectionID)
            && (this.TopicID?.Equals(other.TopicID) ?? other.TopicID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/preferences/sections/{0}/topics/{1}",
                    this.SectionID,
                    this.TopicID
                )
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

/// <summary>
/// The default subscription status applied when a recipient has not set their own.
/// </summary>
[JsonConverter(typeof(TopicReplaceParamsDefaultStatusConverter))]
public enum TopicReplaceParamsDefaultStatus
{
    OptedOut,
    OptedIn,
    Required,
}

sealed class TopicReplaceParamsDefaultStatusConverter
    : JsonConverter<TopicReplaceParamsDefaultStatus>
{
    public override TopicReplaceParamsDefaultStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPTED_OUT" => TopicReplaceParamsDefaultStatus.OptedOut,
            "OPTED_IN" => TopicReplaceParamsDefaultStatus.OptedIn,
            "REQUIRED" => TopicReplaceParamsDefaultStatus.Required,
            _ => (TopicReplaceParamsDefaultStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TopicReplaceParamsDefaultStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TopicReplaceParamsDefaultStatus.OptedOut => "OPTED_OUT",
                TopicReplaceParamsDefaultStatus.OptedIn => "OPTED_IN",
                TopicReplaceParamsDefaultStatus.Required => "REQUIRED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A preference control a recipient may customize for a topic.
/// </summary>
[JsonConverter(typeof(TopicReplaceParamsAllowedPreferenceConverter))]
public enum TopicReplaceParamsAllowedPreference
{
    Snooze,
    ChannelPreferences,
}

sealed class TopicReplaceParamsAllowedPreferenceConverter
    : JsonConverter<TopicReplaceParamsAllowedPreference>
{
    public override TopicReplaceParamsAllowedPreference Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "snooze" => TopicReplaceParamsAllowedPreference.Snooze,
            "channel_preferences" => TopicReplaceParamsAllowedPreference.ChannelPreferences,
            _ => (TopicReplaceParamsAllowedPreference)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TopicReplaceParamsAllowedPreference value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TopicReplaceParamsAllowedPreference.Snooze => "snooze",
                TopicReplaceParamsAllowedPreference.ChannelPreferences => "channel_preferences",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
