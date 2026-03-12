using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Journeys;

[JsonConverter(typeof(JsonModelConverter<JourneysListResponse, JourneysListResponseFromRaw>))]
public sealed record class JourneysListResponse : JsonModel
{
    /// <summary>
    /// A cursor token for pagination. Present when there are more results available.
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cursor", value);
        }
    }

    public IReadOnlyList<Journey>? Templates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Journey>>("templates");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Journey>?>(
                "templates",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Cursor;
        foreach (var item in this.Templates ?? [])
        {
            item.Validate();
        }
    }

    public JourneysListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneysListResponse(JourneysListResponse journeysListResponse)
        : base(journeysListResponse) { }
#pragma warning restore CS8618

    public JourneysListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneysListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneysListResponseFromRaw.FromRawUnchecked"/>
    public static JourneysListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneysListResponseFromRaw : IFromRawJson<JourneysListResponse>
{
    /// <inheritdoc/>
    public JourneysListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneysListResponse.FromRawUnchecked(rawData);
}
