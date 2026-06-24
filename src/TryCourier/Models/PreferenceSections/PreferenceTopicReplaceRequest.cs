using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.PreferenceSections;

/// <summary>
/// Request body for replacing a preference topic. Full document replacement; missing
/// optional fields are cleared.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PreferenceTopicReplaceRequest, PreferenceTopicReplaceRequestFromRaw>)
)]
public sealed record class PreferenceTopicReplaceRequest : JsonModel
{
    /// <summary>
    /// The default subscription status applied when a recipient has not set their own.
    /// </summary>
    public required ApiEnum<string, PreferenceTopicReplaceRequestDefaultStatus> DefaultStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PreferenceTopicReplaceRequestDefaultStatus>
            >("default_status");
        }
        init { this._rawData.Set("default_status", value); }
    }

    /// <summary>
    /// Human-readable name for the preference topic.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Preference controls a recipient may customize. Omit to clear.
    /// </summary>
    public IReadOnlyList<
        ApiEnum<string, PreferenceTopicReplaceRequestAllowedPreference>
    >? AllowedPreferences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, PreferenceTopicReplaceRequestAllowedPreference>>
            >("allowed_preferences");
        }
        init
        {
            this._rawData.Set<ImmutableArray<
                ApiEnum<string, PreferenceTopicReplaceRequestAllowedPreference>
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("include_unsubscribe_header");
        }
        init { this._rawData.Set("include_unsubscribe_header", value); }
    }

    /// <summary>
    /// Default channels delivered for this topic. Omit to clear.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ChannelClassification>>? RoutingOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, ChannelClassification>>
            >("routing_options");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, ChannelClassification>>?>(
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "topic_data"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "topic_data",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DefaultStatus.Validate();
        _ = this.Name;
        foreach (var item in this.AllowedPreferences ?? [])
        {
            item.Validate();
        }
        _ = this.IncludeUnsubscribeHeader;
        foreach (var item in this.RoutingOptions ?? [])
        {
            item.Validate();
        }
        _ = this.TopicData;
    }

    public PreferenceTopicReplaceRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferenceTopicReplaceRequest(
        PreferenceTopicReplaceRequest preferenceTopicReplaceRequest
    )
        : base(preferenceTopicReplaceRequest) { }
#pragma warning restore CS8618

    public PreferenceTopicReplaceRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceTopicReplaceRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferenceTopicReplaceRequestFromRaw.FromRawUnchecked"/>
    public static PreferenceTopicReplaceRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PreferenceTopicReplaceRequestFromRaw : IFromRawJson<PreferenceTopicReplaceRequest>
{
    /// <inheritdoc/>
    public PreferenceTopicReplaceRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreferenceTopicReplaceRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// The default subscription status applied when a recipient has not set their own.
/// </summary>
[JsonConverter(typeof(PreferenceTopicReplaceRequestDefaultStatusConverter))]
public enum PreferenceTopicReplaceRequestDefaultStatus
{
    OptedOut,
    OptedIn,
    Required,
}

sealed class PreferenceTopicReplaceRequestDefaultStatusConverter
    : JsonConverter<PreferenceTopicReplaceRequestDefaultStatus>
{
    public override PreferenceTopicReplaceRequestDefaultStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPTED_OUT" => PreferenceTopicReplaceRequestDefaultStatus.OptedOut,
            "OPTED_IN" => PreferenceTopicReplaceRequestDefaultStatus.OptedIn,
            "REQUIRED" => PreferenceTopicReplaceRequestDefaultStatus.Required,
            _ => (PreferenceTopicReplaceRequestDefaultStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PreferenceTopicReplaceRequestDefaultStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PreferenceTopicReplaceRequestDefaultStatus.OptedOut => "OPTED_OUT",
                PreferenceTopicReplaceRequestDefaultStatus.OptedIn => "OPTED_IN",
                PreferenceTopicReplaceRequestDefaultStatus.Required => "REQUIRED",
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
[JsonConverter(typeof(PreferenceTopicReplaceRequestAllowedPreferenceConverter))]
public enum PreferenceTopicReplaceRequestAllowedPreference
{
    Snooze,
    ChannelPreferences,
}

sealed class PreferenceTopicReplaceRequestAllowedPreferenceConverter
    : JsonConverter<PreferenceTopicReplaceRequestAllowedPreference>
{
    public override PreferenceTopicReplaceRequestAllowedPreference Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "snooze" => PreferenceTopicReplaceRequestAllowedPreference.Snooze,
            "channel_preferences" =>
                PreferenceTopicReplaceRequestAllowedPreference.ChannelPreferences,
            _ => (PreferenceTopicReplaceRequestAllowedPreference)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PreferenceTopicReplaceRequestAllowedPreference value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PreferenceTopicReplaceRequestAllowedPreference.Snooze => "snooze",
                PreferenceTopicReplaceRequestAllowedPreference.ChannelPreferences =>
                    "channel_preferences",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
