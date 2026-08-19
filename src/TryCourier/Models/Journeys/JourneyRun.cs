using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Journeys;

/// <summary>
/// One run of a Journey. `status` and `created_at` are absent on a small number
/// of legacy runs stored without them.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JourneyRun, JourneyRunFromRaw>))]
public sealed record class JourneyRun : JsonModel
{
    /// <summary>
    /// A unique identifier representing the run.
    /// </summary>
    public required string RunID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("run_id");
        }
        init { this._rawData.Set("run_id", value); }
    }

    /// <summary>
    /// Internal provenance strings describing what started the run, e.g. `invoke/&lt;journey_id&gt;`
    /// or `segment/page/Pricing Page`. Diagnostic only — the format is unstable
    /// and should not be parsed.
    /// </summary>
    public required IReadOnlyList<string> Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("source");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "source",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// When the run started, as an ISO 8601 timestamp.
    /// </summary>
    public string? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// The state of the run: `PROCESSING`, `PROCESSED`, `WAITING`, `CANCELED`, `ERROR`,
    /// `THROTTLED`, or `NOT PROCESSED`. Not an enum — new values have been added before.
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// The id of the Journey this run belongs to.
    /// </summary>
    public string? TemplateID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("template_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("template_id", value);
        }
    }

    /// <summary>
    /// When the run last changed state, as an ISO 8601 timestamp.
    /// </summary>
    public string? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updated_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RunID;
        _ = this.Source;
        _ = this.CreatedAt;
        _ = this.Status;
        _ = this.TemplateID;
        _ = this.UpdatedAt;
    }

    public JourneyRun() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyRun(JourneyRun journeyRun)
        : base(journeyRun) { }
#pragma warning restore CS8618

    public JourneyRun(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyRun(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyRunFromRaw.FromRawUnchecked"/>
    public static JourneyRun FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyRunFromRaw : IFromRawJson<JourneyRun>
{
    /// <inheritdoc/>
    public JourneyRun FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JourneyRun.FromRawUnchecked(rawData);
}
