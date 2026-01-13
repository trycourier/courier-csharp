using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Audiences;

[JsonConverter(typeof(JsonModelConverter<Audience, AudienceFromRaw>))]
public sealed record class Audience : JsonModel
{
    /// <summary>
    /// A unique identifier representing the audience_id
    /// </summary>
    public required string ID
    {
        get { return this._rawData.GetNotNullClass<string>("id"); }
        init { this._rawData.Set("id", value); }
    }

    public required string CreatedAt
    {
        get { return this._rawData.GetNotNullClass<string>("created_at"); }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// A description of the audience
    /// </summary>
    public required string Description
    {
        get { return this._rawData.GetNotNullClass<string>("description"); }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// A single filter to use for filtering
    /// </summary>
    public required Filter Filter
    {
        get { return this._rawData.GetNotNullClass<Filter>("filter"); }
        init { this._rawData.Set("filter", value); }
    }

    /// <summary>
    /// The name of the audience
    /// </summary>
    public required string Name
    {
        get { return this._rawData.GetNotNullClass<string>("name"); }
        init { this._rawData.Set("name", value); }
    }

    public required string UpdatedAt
    {
        get { return this._rawData.GetNotNullClass<string>("updated_at"); }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Description;
        this.Filter.Validate();
        _ = this.Name;
        _ = this.UpdatedAt;
    }

    public Audience() { }

    public Audience(Audience audience)
        : base(audience) { }

    public Audience(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Audience(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AudienceFromRaw.FromRawUnchecked"/>
    public static Audience FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AudienceFromRaw : IFromRawJson<Audience>
{
    /// <inheritdoc/>
    public Audience FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Audience.FromRawUnchecked(rawData);
}
