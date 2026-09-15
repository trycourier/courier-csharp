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
    /// The cadences this digest delivers on. At least one is required: a digest with
    /// no schedule collects events into an instance that can never fire. Omitting
    /// the key on a replace leaves stored schedules untouched; sending `[]` is a `400`.
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
}

class TopicDigestRequestFromRaw : IFromRawJson<TopicDigestRequest>
{
    /// <inheritdoc/>
    public TopicDigestRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TopicDigestRequest.FromRawUnchecked(rawData);
}
