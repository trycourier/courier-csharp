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
/// Creates a subscription topic inside a workspace preference. The default status
/// sets whether users start opted in, opted out, or required.
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
    /// A topic's digest, as supplied when the topic itself is created: the template
    /// that renders it, the cadences it delivers on, and how collected events are retained.
    ///
    /// <para>Identical to `TopicDigestRequest`, which a replace uses, except that
    /// `schedules` is required — a topic being created has no stored schedules for
    /// an absent key to leave alone.</para>
    ///
    /// <para>Send `null` for the whole object to turn a digest off, which unlinks
    /// the template and removes its schedules. There is no `enabled` flag, and `schedules:
    /// []` is rejected, because both states are un-deliverable rather than merely off.</para>
    /// </summary>
    public Digest? Digest
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Digest>("digest");
        }
        init { this._rawBodyData.Set("digest", value); }
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

    public string? IdempotencyKey
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("Idempotency-Key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("Idempotency-Key", value);
        }
    }

    public string? XIdempotencyExpiration
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("x-idempotency-expiration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("x-idempotency-expiration", value);
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

/// <summary>
/// A topic's digest, as supplied when the topic itself is created: the template that
/// renders it, the cadences it delivers on, and how collected events are retained.
///
/// <para>Identical to `TopicDigestRequest`, which a replace uses, except that `schedules`
/// is required — a topic being created has no stored schedules for an absent key
/// to leave alone.</para>
///
/// <para>Send `null` for the whole object to turn a digest off, which unlinks the
/// template and removes its schedules. There is no `enabled` flag, and `schedules:
/// []` is rejected, because both states are un-deliverable rather than merely off.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Digest, DigestFromRaw>))]
public sealed record class Digest : JsonModel
{
    /// <summary>
    /// The cadences this digest delivers on.
    ///
    /// <para>The array replaces the stored schedules wholesale, so a schedule you
    /// leave out of it is deleted along with its delivery rule. Omit the key entirely
    /// to leave the stored schedules untouched — useful for changing `template_id`
    /// or `categories` without restating every schedule.</para>
    ///
    /// <para>A digest must end up with at least one schedule, because one with none
    /// collects events into an instance that can never fire. So sending `[]` is always
    /// a `400`, and so is omitting the key on a topic that has no schedules stored yet.</para>
    ///
    /// <para>On **create** the key is required outright: a topic being created has
    /// nothing stored to leave alone, and the topic row is written before its digest,
    /// so rejecting it any later would leave the topic behind and let a retry duplicate it.</para>
    /// </summary>
    public required IReadOnlyList<TopicDigestScheduleRequest> Schedules
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TopicDigestScheduleRequest>>(
                "schedules"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TopicDigestScheduleRequest>>(
                "schedules",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The notification template that renders the digest. A digest with no template
    /// collects nothing, so this is required.
    /// </summary>
    public required string TemplateID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("template_id");
        }
        init { this._rawData.Set("template_id", value); }
    }

    /// <summary>
    /// Optional audience the digest is scoped to.
    /// </summary>
    public string? AudienceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("audience_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("audience_id", value);
        }
    }

    /// <summary>
    /// Retention rules per category key. Defaults to a single `digest` category retaining `FIRST`.
    /// </summary>
    public IReadOnlyList<TopicDigestCategory>? Categories
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TopicDigestCategory>>(
                "categories"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TopicDigestCategory>?>(
                "categories",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether to deliver the digest even when nothing was collected.
    /// </summary>
    public bool? TriggerEmpty
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("trigger_empty");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("trigger_empty", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Schedules)
        {
            item.Validate();
        }
        _ = this.TemplateID;
        _ = this.AudienceID;
        foreach (var item in this.Categories ?? [])
        {
            item.Validate();
        }
        _ = this.TriggerEmpty;
    }

    public Digest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Digest(Digest digest)
        : base(digest) { }
#pragma warning restore CS8618

    public Digest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Digest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigestFromRaw.FromRawUnchecked"/>
    public static Digest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigestFromRaw : IFromRawJson<Digest>
{
    /// <inheritdoc/>
    public Digest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Digest.FromRawUnchecked(rawData);
}
