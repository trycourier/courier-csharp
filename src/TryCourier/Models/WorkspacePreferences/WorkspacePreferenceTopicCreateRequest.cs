using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.WorkspacePreferences;

/// <summary>
/// Request body for creating a preference topic.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkspacePreferenceTopicCreateRequest,
        WorkspacePreferenceTopicCreateRequestFromRaw
    >)
)]
public sealed record class WorkspacePreferenceTopicCreateRequest : JsonModel
{
    /// <summary>
    /// The default subscription status applied when a recipient has not set their own.
    /// </summary>
    public required ApiEnum<string, DefaultStatus> DefaultStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DefaultStatus>>("default_status");
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
    /// Preference controls a recipient may customize for this topic. Defaults to
    /// empty if omitted.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, AllowedPreference>>? AllowedPreferences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, AllowedPreference>>
            >("allowed_preferences");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, AllowedPreference>>?>(
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
    /// Default channels delivered for this topic. Defaults to empty if omitted.
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
    /// Arbitrary metadata associated with the topic.
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

    public WorkspacePreferenceTopicCreateRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkspacePreferenceTopicCreateRequest(
        WorkspacePreferenceTopicCreateRequest workspacePreferenceTopicCreateRequest
    )
        : base(workspacePreferenceTopicCreateRequest) { }
#pragma warning restore CS8618

    public WorkspacePreferenceTopicCreateRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkspacePreferenceTopicCreateRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkspacePreferenceTopicCreateRequestFromRaw.FromRawUnchecked"/>
    public static WorkspacePreferenceTopicCreateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkspacePreferenceTopicCreateRequestFromRaw
    : IFromRawJson<WorkspacePreferenceTopicCreateRequest>
{
    /// <inheritdoc/>
    public WorkspacePreferenceTopicCreateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkspacePreferenceTopicCreateRequest.FromRawUnchecked(rawData);
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
