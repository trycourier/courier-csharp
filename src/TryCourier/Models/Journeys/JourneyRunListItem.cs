using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Journeys;

/// <summary>
/// A Journey run as it appears in a list response, without `updated_at`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JourneyRunListItem, JourneyRunListItemFromRaw>))]
public sealed record class JourneyRunListItem : JsonModel
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
    /// Internal provenance strings describing what started the run. Diagnostic only.
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
    /// The state of the run. See `JourneyRun.status` for the values it takes.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RunID;
        _ = this.Source;
        _ = this.CreatedAt;
        _ = this.Status;
        _ = this.TemplateID;
    }

    public JourneyRunListItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyRunListItem(JourneyRunListItem journeyRunListItem)
        : base(journeyRunListItem) { }
#pragma warning restore CS8618

    public JourneyRunListItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyRunListItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyRunListItemFromRaw.FromRawUnchecked"/>
    public static JourneyRunListItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyRunListItemFromRaw : IFromRawJson<JourneyRunListItem>
{
    /// <inheritdoc/>
    public JourneyRunListItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JourneyRunListItem.FromRawUnchecked(rawData);
}
