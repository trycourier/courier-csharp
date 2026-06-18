using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Journeys;

/// <summary>
/// Summary fields of a journey-scoped notification template returned in list responses.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JourneyTemplateSummary, JourneyTemplateSummaryFromRaw>))]
public sealed record class JourneyTemplateSummary : JsonModel
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

    public required long Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("created");
        }
        init { this._rawData.Set("created", value); }
    }

    public required string Creator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creator");
        }
        init { this._rawData.Set("creator", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    public required IReadOnlyList<string> Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "tags",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public long? Updated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("updated");
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

    public string? Updater
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updater");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updater", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Created;
        _ = this.Creator;
        _ = this.Name;
        _ = this.State;
        _ = this.Tags;
        _ = this.Updated;
        _ = this.Updater;
    }

    public JourneyTemplateSummary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyTemplateSummary(JourneyTemplateSummary journeyTemplateSummary)
        : base(journeyTemplateSummary) { }
#pragma warning restore CS8618

    public JourneyTemplateSummary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyTemplateSummary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyTemplateSummaryFromRaw.FromRawUnchecked"/>
    public static JourneyTemplateSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyTemplateSummaryFromRaw : IFromRawJson<JourneyTemplateSummary>
{
    /// <inheritdoc/>
    public JourneyTemplateSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyTemplateSummary.FromRawUnchecked(rawData);
}
