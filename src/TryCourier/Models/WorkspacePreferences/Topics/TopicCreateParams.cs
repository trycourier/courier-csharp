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
/// Create a subscription preference topic inside a workspace preference. Fails with
/// 404 if the workspace preference does not exist. The topic id is generated and returned.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TopicCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SectionID { get; init; }

    /// <summary>
    /// The default subscription status applied when a recipient has not set their own.
    /// </summary>
    public required ApiEnum<string, DefaultStatus> DefaultStatus
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, DefaultStatus>>(
                "default_status"
            );
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
    /// Preference controls a recipient may customize for this topic. Defaults to
    /// empty if omitted.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, AllowedPreference>>? AllowedPreferences
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, AllowedPreference>>
            >("allowed_preferences");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ApiEnum<string, AllowedPreference>>?>(
                "allowed_preferences",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional description shown under the topic on the hosted preferences page.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
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
    /// Default channels delivered for this topic. Defaults to empty if omitted.
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
    /// Arbitrary metadata associated with the topic.
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

    public TopicCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopicCreateParams(TopicCreateParams topicCreateParams)
        : base(topicCreateParams)
    {
        this.SectionID = topicCreateParams.SectionID;

        this._rawBodyData = new(topicCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TopicCreateParams(
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
    TopicCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string sectionID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.SectionID = sectionID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TopicCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string sectionID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            sectionID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["SectionID"] = JsonSerializer.SerializeToElement(this.SectionID),
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

    public virtual bool Equals(TopicCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.SectionID?.Equals(other.SectionID) ?? other.SectionID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/preferences/sections/{0}/topics", this.SectionID)
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
[JsonConverter(typeof(DefaultStatusConverter))]
public enum DefaultStatus
{
    OptedOut,
    OptedIn,
    Required,
}

sealed class DefaultStatusConverter : JsonConverter<DefaultStatus>
{
    public override DefaultStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPTED_OUT" => DefaultStatus.OptedOut,
            "OPTED_IN" => DefaultStatus.OptedIn,
            "REQUIRED" => DefaultStatus.Required,
            _ => (DefaultStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DefaultStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DefaultStatus.OptedOut => "OPTED_OUT",
                DefaultStatus.OptedIn => "OPTED_IN",
                DefaultStatus.Required => "REQUIRED",
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
[JsonConverter(typeof(AllowedPreferenceConverter))]
public enum AllowedPreference
{
    Snooze,
    ChannelPreferences,
}

sealed class AllowedPreferenceConverter : JsonConverter<AllowedPreference>
{
    public override AllowedPreference Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "snooze" => AllowedPreference.Snooze,
            "channel_preferences" => AllowedPreference.ChannelPreferences,
            _ => (AllowedPreference)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AllowedPreference value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AllowedPreference.Snooze => "snooze",
                AllowedPreference.ChannelPreferences => "channel_preferences",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
