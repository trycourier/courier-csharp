using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Journeys;

/// <summary>
/// A journey, with its current draft or published nodes and metadata.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JourneyResponse, JourneyResponseFromRaw>))]
public sealed record class JourneyResponse : JsonModel
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

    public required long? Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("created");
        }
        init { this._rawData.Set("created", value); }
    }

    public required string? Creator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("creator");
        }
        init { this._rawData.Set("creator", value); }
    }

    public required bool Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("enabled");
        }
        init { this._rawData.Set("enabled", value); }
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

    public required IReadOnlyList<JourneyNode> Nodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JourneyNode>>("nodes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<JourneyNode>>(
                "nodes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required long? Published
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("published");
        }
        init { this._rawData.Set("published", value); }
    }

    /// <summary>
    /// Lifecycle state of a journey.
    /// </summary>
    public required ApiEnum<string, JourneyState> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneyState>>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    public required long? Updated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("updated");
        }
        init { this._rawData.Set("updated", value); }
    }

    public required string? Updater
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updater");
        }
        init { this._rawData.Set("updater", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Created;
        _ = this.Creator;
        _ = this.Enabled;
        _ = this.Name;
        foreach (var item in this.Nodes)
        {
            item.Validate();
        }
        _ = this.Published;
        this.State.Validate();
        _ = this.Updated;
        _ = this.Updater;
    }

    public JourneyResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyResponse(JourneyResponse journeyResponse)
        : base(journeyResponse) { }
#pragma warning restore CS8618

    public JourneyResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyResponseFromRaw.FromRawUnchecked"/>
    public static JourneyResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyResponseFromRaw : IFromRawJson<JourneyResponse>
{
    /// <inheritdoc/>
    public JourneyResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JourneyResponse.FromRawUnchecked(rawData);
}
