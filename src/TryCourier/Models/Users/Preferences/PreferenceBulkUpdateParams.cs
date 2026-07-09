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

namespace TryCourier.Models.Users.Preferences;

/// <summary>
/// Additively create or update a user's preferences for one or more subscription
/// topics in a single request. Only the topics included in the request body are
/// created or updated; any existing overrides for topics not listed are left untouched.
///
/// <para>Structural validation of the request body fails fast with a single `400`.
/// Beyond that, each topic is processed independently (partial-success, not all-or-nothing):
/// valid topics are written and returned in `items`, while topics that cannot be
/// applied are collected in `errors` with a per-topic `reason` (for example an unknown
/// topic, a `REQUIRED` topic that cannot be opted out, a custom routing request that
/// is not available on the workspace's plan, or a write failure). The request therefore
/// returns `200` with both lists whenever the body is structurally valid.</para>
///
/// <para>Every `topic_id` in the response — in both `items` and `errors` — is returned
/// in Courier's canonical topic id form, regardless of the form supplied in the request.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PreferenceBulkUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? UserID { get; init; }

    /// <summary>
    /// The topics to create or update. Between 1 and 50 topics may be provided in
    /// a single request.
    /// </summary>
    public required IReadOnlyList<PreferenceBulkUpdateParamsTopic> Topics
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<
                ImmutableArray<PreferenceBulkUpdateParamsTopic>
            >("topics");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<PreferenceBulkUpdateParamsTopic>>(
                "topics",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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

    public PreferenceBulkUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferenceBulkUpdateParams(PreferenceBulkUpdateParams preferenceBulkUpdateParams)
        : base(preferenceBulkUpdateParams)
    {
        this.UserID = preferenceBulkUpdateParams.UserID;

        this._rawBodyData = new(preferenceBulkUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public PreferenceBulkUpdateParams(
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
    PreferenceBulkUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string userID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.UserID = userID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PreferenceBulkUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string userID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            userID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["UserID"] = JsonSerializer.SerializeToElement(this.UserID),
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

    public virtual bool Equals(PreferenceBulkUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.UserID?.Equals(other.UserID) ?? other.UserID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/users/{0}/preferences", this.UserID)
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
        PreferenceBulkUpdateParamsTopic,
        PreferenceBulkUpdateParamsTopicFromRaw
    >)
)]
public sealed record class PreferenceBulkUpdateParamsTopic : JsonModel
{
    /// <summary>
    /// The subscription status to apply for this topic.
    /// </summary>
    public required ApiEnum<string, PreferenceBulkUpdateParamsTopicStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PreferenceBulkUpdateParamsTopicStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A unique identifier associated with a subscription topic.
    /// </summary>
    public required string TopicID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("topic_id");
        }
        init { this._rawData.Set("topic_id", value); }
    }

    /// <summary>
    /// The channels a user has chosen to receive notifications through for this topic.
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
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, ChannelClassification>>?>(
                "custom_routing",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether the recipient has chosen specific delivery channels for this topic.
    /// </summary>
    public bool? HasCustomRouting
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("has_custom_routing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("has_custom_routing", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
        _ = this.TopicID;
        foreach (var item in this.CustomRouting ?? [])
        {
            item.Validate();
        }
        _ = this.HasCustomRouting;
    }

    public PreferenceBulkUpdateParamsTopic() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferenceBulkUpdateParamsTopic(
        PreferenceBulkUpdateParamsTopic preferenceBulkUpdateParamsTopic
    )
        : base(preferenceBulkUpdateParamsTopic) { }
#pragma warning restore CS8618

    public PreferenceBulkUpdateParamsTopic(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceBulkUpdateParamsTopic(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferenceBulkUpdateParamsTopicFromRaw.FromRawUnchecked"/>
    public static PreferenceBulkUpdateParamsTopic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PreferenceBulkUpdateParamsTopicFromRaw : IFromRawJson<PreferenceBulkUpdateParamsTopic>
{
    /// <inheritdoc/>
    public PreferenceBulkUpdateParamsTopic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreferenceBulkUpdateParamsTopic.FromRawUnchecked(rawData);
}

/// <summary>
/// The subscription status to apply for this topic.
/// </summary>
[JsonConverter(typeof(PreferenceBulkUpdateParamsTopicStatusConverter))]
public enum PreferenceBulkUpdateParamsTopicStatus
{
    OptedIn,
    OptedOut,
}

sealed class PreferenceBulkUpdateParamsTopicStatusConverter
    : JsonConverter<PreferenceBulkUpdateParamsTopicStatus>
{
    public override PreferenceBulkUpdateParamsTopicStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPTED_IN" => PreferenceBulkUpdateParamsTopicStatus.OptedIn,
            "OPTED_OUT" => PreferenceBulkUpdateParamsTopicStatus.OptedOut,
            _ => (PreferenceBulkUpdateParamsTopicStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PreferenceBulkUpdateParamsTopicStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PreferenceBulkUpdateParamsTopicStatus.OptedIn => "OPTED_IN",
                PreferenceBulkUpdateParamsTopicStatus.OptedOut => "OPTED_OUT",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
