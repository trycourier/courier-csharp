using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.WorkspacePreferences;

/// <summary>
/// A topic's digest configuration: the template that renders it, the cadences it
/// delivers on, and how collected events are retained.
///
/// <para>Send `null` for the whole object to turn a digest off, which unlinks the
/// template and removes its schedules. There is no `enabled` flag, and `schedules:
/// []` is rejected, because both states are un-deliverable rather than merely off.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TopicDigestRequest, TopicDigestRequestFromRaw>))]
public sealed record class TopicDigestRequest : JsonModel
{
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
    public IReadOnlyList<TopicDigestScheduleRequest>? Schedules
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TopicDigestScheduleRequest>>(
                "schedules"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TopicDigestScheduleRequest>?>(
                "schedules",
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
        _ = this.TemplateID;
        _ = this.AudienceID;
        foreach (var item in this.Categories ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Schedules ?? [])
        {
            item.Validate();
        }
        _ = this.TriggerEmpty;
    }

    public TopicDigestRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopicDigestRequest(TopicDigestRequest topicDigestRequest)
        : base(topicDigestRequest) { }
#pragma warning restore CS8618

    public TopicDigestRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopicDigestRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopicDigestRequestFromRaw.FromRawUnchecked"/>
    public static TopicDigestRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TopicDigestRequest(string templateID)
        : this()
    {
        this.TemplateID = templateID;
    }
}

class TopicDigestRequestFromRaw : IFromRawJson<TopicDigestRequest>
{
    /// <inheritdoc/>
    public TopicDigestRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TopicDigestRequest.FromRawUnchecked(rawData);
}
