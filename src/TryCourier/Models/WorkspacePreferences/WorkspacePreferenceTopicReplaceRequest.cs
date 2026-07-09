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
/// Request body for replacing a preference topic. Full document replacement; missing
/// optional fields are cleared.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkspacePreferenceTopicReplaceRequest,
        WorkspacePreferenceTopicReplaceRequestFromRaw
    >)
)]
public sealed record class WorkspacePreferenceTopicReplaceRequest : JsonModel
{
    /// <summary>
    /// The default subscription status applied when a recipient has not set their own.
    /// </summary>
    public required ApiEnum<
        string,
        WorkspacePreferenceTopicReplaceRequestDefaultStatus
    > DefaultStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, WorkspacePreferenceTopicReplaceRequestDefaultStatus>
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
        ApiEnum<string, WorkspacePreferenceTopicReplaceRequestAllowedPreference>
    >? AllowedPreferences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<
                    ApiEnum<string, WorkspacePreferenceTopicReplaceRequestAllowedPreference>
                >
            >("allowed_preferences");
        }
        init
        {
            this._rawData.Set<ImmutableArray<
                ApiEnum<string, WorkspacePreferenceTopicReplaceRequestAllowedPreference>
            >?>(
                "allowed_preferences",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional description shown under the topic on the hosted preferences page.
    /// Omit to clear.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
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
        _ = this.Description;
        _ = this.IncludeUnsubscribeHeader;
        foreach (var item in this.RoutingOptions ?? [])
        {
            item.Validate();
        }
        _ = this.TopicData;
    }

    public WorkspacePreferenceTopicReplaceRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkspacePreferenceTopicReplaceRequest(
        WorkspacePreferenceTopicReplaceRequest workspacePreferenceTopicReplaceRequest
    )
        : base(workspacePreferenceTopicReplaceRequest) { }
#pragma warning restore CS8618

    public WorkspacePreferenceTopicReplaceRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkspacePreferenceTopicReplaceRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkspacePreferenceTopicReplaceRequestFromRaw.FromRawUnchecked"/>
    public static WorkspacePreferenceTopicReplaceRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkspacePreferenceTopicReplaceRequestFromRaw
    : IFromRawJson<WorkspacePreferenceTopicReplaceRequest>
{
    /// <inheritdoc/>
    public WorkspacePreferenceTopicReplaceRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkspacePreferenceTopicReplaceRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// The default subscription status applied when a recipient has not set their own.
/// </summary>
[JsonConverter(typeof(WorkspacePreferenceTopicReplaceRequestDefaultStatusConverter))]
public enum WorkspacePreferenceTopicReplaceRequestDefaultStatus
{
    OptedOut,
    OptedIn,
    Required,
}

sealed class WorkspacePreferenceTopicReplaceRequestDefaultStatusConverter
    : JsonConverter<WorkspacePreferenceTopicReplaceRequestDefaultStatus>
{
    public override WorkspacePreferenceTopicReplaceRequestDefaultStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPTED_OUT" => WorkspacePreferenceTopicReplaceRequestDefaultStatus.OptedOut,
            "OPTED_IN" => WorkspacePreferenceTopicReplaceRequestDefaultStatus.OptedIn,
            "REQUIRED" => WorkspacePreferenceTopicReplaceRequestDefaultStatus.Required,
            _ => (WorkspacePreferenceTopicReplaceRequestDefaultStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WorkspacePreferenceTopicReplaceRequestDefaultStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WorkspacePreferenceTopicReplaceRequestDefaultStatus.OptedOut => "OPTED_OUT",
                WorkspacePreferenceTopicReplaceRequestDefaultStatus.OptedIn => "OPTED_IN",
                WorkspacePreferenceTopicReplaceRequestDefaultStatus.Required => "REQUIRED",
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
[JsonConverter(typeof(WorkspacePreferenceTopicReplaceRequestAllowedPreferenceConverter))]
public enum WorkspacePreferenceTopicReplaceRequestAllowedPreference
{
    Snooze,
    ChannelPreferences,
}

sealed class WorkspacePreferenceTopicReplaceRequestAllowedPreferenceConverter
    : JsonConverter<WorkspacePreferenceTopicReplaceRequestAllowedPreference>
{
    public override WorkspacePreferenceTopicReplaceRequestAllowedPreference Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "snooze" => WorkspacePreferenceTopicReplaceRequestAllowedPreference.Snooze,
            "channel_preferences" =>
                WorkspacePreferenceTopicReplaceRequestAllowedPreference.ChannelPreferences,
            _ => (WorkspacePreferenceTopicReplaceRequestAllowedPreference)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WorkspacePreferenceTopicReplaceRequestAllowedPreference value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WorkspacePreferenceTopicReplaceRequestAllowedPreference.Snooze => "snooze",
                WorkspacePreferenceTopicReplaceRequestAllowedPreference.ChannelPreferences =>
                    "channel_preferences",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
