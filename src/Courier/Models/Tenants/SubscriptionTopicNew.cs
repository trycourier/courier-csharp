using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Tenants;

[JsonConverter(typeof(ModelConverter<SubscriptionTopicNew, SubscriptionTopicNewFromRaw>))]
public sealed record class SubscriptionTopicNew : ModelBase
{
    public required ApiEnum<string, Status> Status
    {
        get { return ModelBase.GetNotNullClass<ApiEnum<string, Status>>(this.RawData, "status"); }
        init { ModelBase.Set(this._rawData, "status", value); }
    }

    /// <summary>
    /// The default channels to send to this tenant when has_custom_routing is enabled
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ChannelClassification>>? CustomRouting
    {
        get
        {
            return ModelBase.GetNullableClass<List<ApiEnum<string, ChannelClassification>>>(
                this.RawData,
                "custom_routing"
            );
        }
        init { ModelBase.Set(this._rawData, "custom_routing", value); }
    }

    /// <summary>
    /// Override channel routing with custom preferences. This will override any
    /// template prefernces that are set, but a user can still customize their preferences
    /// </summary>
    public bool? HasCustomRouting
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "has_custom_routing"); }
        init { ModelBase.Set(this._rawData, "has_custom_routing", value); }
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

    public SubscriptionTopicNew() { }

    public SubscriptionTopicNew(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionTopicNew(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static SubscriptionTopicNew FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionTopicNew(ApiEnum<string, Status> status)
        : this()
    {
        this.Status = status;
    }
}

class SubscriptionTopicNewFromRaw : IFromRaw<SubscriptionTopicNew>
{
    public SubscriptionTopicNew FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionTopicNew.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    OptedOut,
    OptedIn,
    Required,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPTED_OUT" => Status.OptedOut,
            "OPTED_IN" => Status.OptedIn,
            "REQUIRED" => Status.Required,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.OptedOut => "OPTED_OUT",
                Status.OptedIn => "OPTED_IN",
                Status.Required => "REQUIRED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
