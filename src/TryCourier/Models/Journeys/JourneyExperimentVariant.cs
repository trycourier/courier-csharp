using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Journeys;

/// <summary>
/// A single weighted variant of an experiment. Variant ids must be unique within
/// the experiment and the sum of all variant weights must be greater than 0. Weights
/// are relative (no sum-to-100 requirement) — routing normalizes them proportionally.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<JourneyExperimentVariant, JourneyExperimentVariantFromRaw>)
)]
public sealed record class JourneyExperimentVariant : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The notification template sent for this variant.
    /// </summary>
    public required string TemplateID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("templateId");
        }
        init { this._rawData.Set("templateId", value); }
    }

    /// <summary>
    /// Relative routing weight. Must be non-negative.
    /// </summary>
    public required double Weight
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("weight");
        }
        init { this._rawData.Set("weight", value); }
    }

    /// <summary>
    /// Optional display name for the variant.
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
        _ = this.ID;
        _ = this.TemplateID;
        _ = this.Weight;
        _ = this.Name;
    }

    public JourneyExperimentVariant() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyExperimentVariant(JourneyExperimentVariant journeyExperimentVariant)
        : base(journeyExperimentVariant) { }
#pragma warning restore CS8618

    public JourneyExperimentVariant(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyExperimentVariant(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyExperimentVariantFromRaw.FromRawUnchecked"/>
    public static JourneyExperimentVariant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyExperimentVariantFromRaw : IFromRawJson<JourneyExperimentVariant>
{
    /// <inheritdoc/>
    public JourneyExperimentVariant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyExperimentVariant.FromRawUnchecked(rawData);
}
