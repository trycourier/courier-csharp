using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Journeys;

/// <summary>
/// A page of Journey runs.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JourneyRunListResponse, JourneyRunListResponseFromRaw>))]
public sealed record class JourneyRunListResponse : JsonModel
{
    public required IReadOnlyList<JourneyRunListItem> Runs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JourneyRunListItem>>("runs");
        }
        init
        {
            this._rawData.Set<ImmutableArray<JourneyRunListItem>>(
                "runs",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pass back as `cursor` to fetch the next page. Absent on the last page.
    /// </summary>
    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("next_cursor", value);
        }
    }

    /// <summary>
    /// Pass back as `cursor` to fetch the previous page. Absent on the first page.
    /// </summary>
    public string? PrevCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prev_cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("prev_cursor", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Runs)
        {
            item.Validate();
        }
        _ = this.NextCursor;
        _ = this.PrevCursor;
    }

    public JourneyRunListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyRunListResponse(JourneyRunListResponse journeyRunListResponse)
        : base(journeyRunListResponse) { }
#pragma warning restore CS8618

    public JourneyRunListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyRunListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyRunListResponseFromRaw.FromRawUnchecked"/>
    public static JourneyRunListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public JourneyRunListResponse(IReadOnlyList<JourneyRunListItem> runs)
        : this()
    {
        this.Runs = runs;
    }
}

class JourneyRunListResponseFromRaw : IFromRawJson<JourneyRunListResponse>
{
    /// <inheritdoc/>
    public JourneyRunListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyRunListResponse.FromRawUnchecked(rawData);
}
