using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Automations;

/// <summary>
/// A page of Automation runs.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AutomationRunListResponse, AutomationRunListResponseFromRaw>)
)]
public sealed record class AutomationRunListResponse : JsonModel
{
    public required IReadOnlyList<AutomationRunListItem> Runs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AutomationRunListItem>>("runs");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AutomationRunListItem>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Runs)
        {
            item.Validate();
        }
        _ = this.NextCursor;
    }

    public AutomationRunListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutomationRunListResponse(AutomationRunListResponse automationRunListResponse)
        : base(automationRunListResponse) { }
#pragma warning restore CS8618

    public AutomationRunListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationRunListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutomationRunListResponseFromRaw.FromRawUnchecked"/>
    public static AutomationRunListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AutomationRunListResponse(IReadOnlyList<AutomationRunListItem> runs)
        : this()
    {
        this.Runs = runs;
    }
}

class AutomationRunListResponseFromRaw : IFromRawJson<AutomationRunListResponse>
{
    /// <inheritdoc/>
    public AutomationRunListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutomationRunListResponse.FromRawUnchecked(rawData);
}
