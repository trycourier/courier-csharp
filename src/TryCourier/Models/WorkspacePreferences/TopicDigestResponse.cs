using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Models.Digests;

namespace TryCourier.Models.WorkspacePreferences;

/// <summary>
/// A topic's digest configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TopicDigestResponse, TopicDigestResponseFromRaw>))]
public sealed record class TopicDigestResponse : JsonModel
{
    /// <summary>
    /// Retention rules per category key.
    /// </summary>
    public required IReadOnlyList<TopicDigestCategory> Categories
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TopicDigestCategory>>(
                "categories"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TopicDigestCategory>>(
                "categories",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The digest's delivery cadences, each with its server-assigned `schedule_id`.
    /// </summary>
    public required IReadOnlyList<TopicDigestScheduleResponse> Schedules
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TopicDigestScheduleResponse>>(
                "schedules"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TopicDigestScheduleResponse>>(
                "schedules",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The notification template that renders the digest.
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
    /// The audience the digest is scoped to, when set.
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
    /// ISO-8601 timestamp of when the digest was configured.
    /// </summary>
    public string? Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("created");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created", value);
        }
    }

    /// <summary>
    /// Whether the digest is delivered even when nothing was collected.
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

    /// <summary>
    /// ISO-8601 timestamp of the last update.
    /// </summary>
    public string? Updated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Categories)
        {
            item.Validate();
        }
        foreach (var item in this.Schedules)
        {
            item.Validate();
        }
        _ = this.TemplateID;
        _ = this.AudienceID;
        _ = this.Created;
        _ = this.TriggerEmpty;
        _ = this.Updated;
    }

    public TopicDigestResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopicDigestResponse(TopicDigestResponse topicDigestResponse)
        : base(topicDigestResponse) { }
#pragma warning restore CS8618

    public TopicDigestResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopicDigestResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopicDigestResponseFromRaw.FromRawUnchecked"/>
    public static TopicDigestResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopicDigestResponseFromRaw : IFromRawJson<TopicDigestResponse>
{
    /// <inheritdoc/>
    public TopicDigestResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TopicDigestResponse.FromRawUnchecked(rawData);
}
