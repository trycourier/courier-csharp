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
/// A subscription preference topic in your workspace.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PreferenceTopicGetResponse, PreferenceTopicGetResponseFromRaw>)
)]
public sealed record class PreferenceTopicGetResponse : JsonModel
{
    /// <summary>
    /// The preference topic id.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Preference controls a recipient may customize. May be empty.
    /// </summary>
    public required IReadOnlyList<
        ApiEnum<string, PreferenceTopicGetResponseAllowedPreference>
    > AllowedPreferences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, PreferenceTopicGetResponseAllowedPreference>>
            >("allowed_preferences");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ApiEnum<string, PreferenceTopicGetResponseAllowedPreference>>
            >("allowed_preferences", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// ISO-8601 timestamp of when the topic was created.
    /// </summary>
    public required string Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("created");
        }
        init { this._rawData.Set("created", value); }
    }

    /// <summary>
    /// The default subscription status applied when a recipient has not set their own.
    /// </summary>
    public required ApiEnum<string, PreferenceTopicGetResponseDefaultStatus> DefaultStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PreferenceTopicGetResponseDefaultStatus>
            >("default_status");
        }
        init { this._rawData.Set("default_status", value); }
    }

    /// <summary>
    /// Whether a list-unsubscribe header is included on emails for this topic.
    /// </summary>
    public required bool IncludeUnsubscribeHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("include_unsubscribe_header");
        }
        init { this._rawData.Set("include_unsubscribe_header", value); }
    }

    /// <summary>
    /// Human-readable name.
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
    /// Default channels delivered for this topic. May be empty.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, ChannelClassification>> RoutingOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, ChannelClassification>>
            >("routing_options");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, ChannelClassification>>>(
                "routing_options",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Arbitrary metadata associated with the topic.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> TopicData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "topic_data"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "topic_data",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// ISO-8601 timestamp of the last update.
    /// </summary>
    public required string Updated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("updated");
        }
        init { this._rawData.Set("updated", value); }
    }

    /// <summary>
    /// Id of the creator.
    /// </summary>
    public string? Creator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("creator");
        }
        init { this._rawData.Set("creator", value); }
    }

    /// <summary>
    /// Id of the last updater.
    /// </summary>
    public string? Updater
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updater");
        }
        init { this._rawData.Set("updater", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.AllowedPreferences)
        {
            item.Validate();
        }
        _ = this.Created;
        this.DefaultStatus.Validate();
        _ = this.IncludeUnsubscribeHeader;
        _ = this.Name;
        foreach (var item in this.RoutingOptions)
        {
            item.Validate();
        }
        _ = this.TopicData;
        _ = this.Updated;
        _ = this.Creator;
        _ = this.Updater;
    }

    public PreferenceTopicGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferenceTopicGetResponse(PreferenceTopicGetResponse preferenceTopicGetResponse)
        : base(preferenceTopicGetResponse) { }
#pragma warning restore CS8618

    public PreferenceTopicGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceTopicGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferenceTopicGetResponseFromRaw.FromRawUnchecked"/>
    public static PreferenceTopicGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PreferenceTopicGetResponseFromRaw : IFromRawJson<PreferenceTopicGetResponse>
{
    /// <inheritdoc/>
    public PreferenceTopicGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreferenceTopicGetResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A preference control a recipient may customize for a topic.
/// </summary>
[JsonConverter(typeof(PreferenceTopicGetResponseAllowedPreferenceConverter))]
public enum PreferenceTopicGetResponseAllowedPreference
{
    Snooze,
    ChannelPreferences,
}

sealed class PreferenceTopicGetResponseAllowedPreferenceConverter
    : JsonConverter<PreferenceTopicGetResponseAllowedPreference>
{
    public override PreferenceTopicGetResponseAllowedPreference Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "snooze" => PreferenceTopicGetResponseAllowedPreference.Snooze,
            "channel_preferences" => PreferenceTopicGetResponseAllowedPreference.ChannelPreferences,
            _ => (PreferenceTopicGetResponseAllowedPreference)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PreferenceTopicGetResponseAllowedPreference value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PreferenceTopicGetResponseAllowedPreference.Snooze => "snooze",
                PreferenceTopicGetResponseAllowedPreference.ChannelPreferences =>
                    "channel_preferences",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The default subscription status applied when a recipient has not set their own.
/// </summary>
[JsonConverter(typeof(PreferenceTopicGetResponseDefaultStatusConverter))]
public enum PreferenceTopicGetResponseDefaultStatus
{
    OptedOut,
    OptedIn,
    Required,
}

sealed class PreferenceTopicGetResponseDefaultStatusConverter
    : JsonConverter<PreferenceTopicGetResponseDefaultStatus>
{
    public override PreferenceTopicGetResponseDefaultStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPTED_OUT" => PreferenceTopicGetResponseDefaultStatus.OptedOut,
            "OPTED_IN" => PreferenceTopicGetResponseDefaultStatus.OptedIn,
            "REQUIRED" => PreferenceTopicGetResponseDefaultStatus.Required,
            _ => (PreferenceTopicGetResponseDefaultStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PreferenceTopicGetResponseDefaultStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PreferenceTopicGetResponseDefaultStatus.OptedOut => "OPTED_OUT",
                PreferenceTopicGetResponseDefaultStatus.OptedIn => "OPTED_IN",
                PreferenceTopicGetResponseDefaultStatus.Required => "REQUIRED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
