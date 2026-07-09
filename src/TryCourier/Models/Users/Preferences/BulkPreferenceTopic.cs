using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Users.Preferences;

/// <summary>
/// A single topic override echoed in a bulk preference response.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BulkPreferenceTopic, BulkPreferenceTopicFromRaw>))]
public sealed record class BulkPreferenceTopic : JsonModel
{
    public required IReadOnlyList<ApiEnum<string, ChannelClassification>> CustomRouting
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, ChannelClassification>>
            >("custom_routing");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, ChannelClassification>>>(
                "custom_routing",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required bool HasCustomRouting
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_custom_routing");
        }
        init { this._rawData.Set("has_custom_routing", value); }
    }

    /// <summary>
    /// The applied subscription status. Echoes the requested value, so it is always
    /// OPTED_IN or OPTED_OUT.
    /// </summary>
    public required ApiEnum<string, BulkPreferenceTopicStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BulkPreferenceTopicStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required string TopicID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("topic_id");
        }
        init { this._rawData.Set("topic_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.CustomRouting)
        {
            item.Validate();
        }
        _ = this.HasCustomRouting;
        this.Status.Validate();
        _ = this.TopicID;
    }

    public BulkPreferenceTopic() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BulkPreferenceTopic(BulkPreferenceTopic bulkPreferenceTopic)
        : base(bulkPreferenceTopic) { }
#pragma warning restore CS8618

    public BulkPreferenceTopic(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkPreferenceTopic(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BulkPreferenceTopicFromRaw.FromRawUnchecked"/>
    public static BulkPreferenceTopic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BulkPreferenceTopicFromRaw : IFromRawJson<BulkPreferenceTopic>
{
    /// <inheritdoc/>
    public BulkPreferenceTopic FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BulkPreferenceTopic.FromRawUnchecked(rawData);
}

/// <summary>
/// The applied subscription status. Echoes the requested value, so it is always
/// OPTED_IN or OPTED_OUT.
/// </summary>
[JsonConverter(typeof(BulkPreferenceTopicStatusConverter))]
public enum BulkPreferenceTopicStatus
{
    OptedIn,
    OptedOut,
}

sealed class BulkPreferenceTopicStatusConverter : JsonConverter<BulkPreferenceTopicStatus>
{
    public override BulkPreferenceTopicStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPTED_IN" => BulkPreferenceTopicStatus.OptedIn,
            "OPTED_OUT" => BulkPreferenceTopicStatus.OptedOut,
            _ => (BulkPreferenceTopicStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BulkPreferenceTopicStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BulkPreferenceTopicStatus.OptedIn => "OPTED_IN",
                BulkPreferenceTopicStatus.OptedOut => "OPTED_OUT",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
