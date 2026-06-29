using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Journeys;

/// <summary>
/// A/B experiment config for a send node. The recipient is deterministically bucketed
/// by `bucketingKey` and routed to one of the `variants` in proportion to its `weight`.
/// Present on a send node INSTEAD OF `message.template`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JourneyExperiment, JourneyExperimentFromRaw>))]
public sealed record class JourneyExperiment : JsonModel
{
    /// <summary>
    /// The value used to deterministically assign a recipient to a variant. Must
    /// be non-empty with no leading or trailing whitespace.
    /// </summary>
    public required string BucketingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("bucketingKey");
        }
        init { this._rawData.Set("bucketingKey", value); }
    }

    /// <summary>
    /// Between 2 and 10 weighted template variants.
    /// </summary>
    public required IReadOnlyList<JourneyExperimentVariant> Variants
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JourneyExperimentVariant>>(
                "variants"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<JourneyExperimentVariant>>(
                "variants",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Server-authoritative experiment id (prefixed `exp_`). Omit to have the server
    /// mint one; when supplied it must be a valid `exp_` id.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Optional, cosmetic display name for the experiment.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BucketingKey;
        foreach (var item in this.Variants)
        {
            item.Validate();
        }
        _ = this.ID;
        _ = this.Name;
    }

    public JourneyExperiment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyExperiment(JourneyExperiment journeyExperiment)
        : base(journeyExperiment) { }
#pragma warning restore CS8618

    public JourneyExperiment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyExperiment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyExperimentFromRaw.FromRawUnchecked"/>
    public static JourneyExperiment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyExperimentFromRaw : IFromRawJson<JourneyExperiment>
{
    /// <inheritdoc/>
    public JourneyExperiment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JourneyExperiment.FromRawUnchecked(rawData);
}
