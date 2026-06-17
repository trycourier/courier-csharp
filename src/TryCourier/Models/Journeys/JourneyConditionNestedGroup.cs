using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Journeys;

/// <summary>
/// A nested condition group. Exactly one of `AND` or `OR` must be present at runtime;
/// each is a list of `JourneyConditionGroup` items.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<JourneyConditionNestedGroup, JourneyConditionNestedGroupFromRaw>)
)]
public sealed record class JourneyConditionNestedGroup : JsonModel
{
    public IReadOnlyList<JourneyConditionGroup>? And
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<JourneyConditionGroup>>("AND");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<JourneyConditionGroup>?>(
                "AND",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<JourneyConditionGroup>? Or
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<JourneyConditionGroup>>("OR");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<JourneyConditionGroup>?>(
                "OR",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.And ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Or ?? [])
        {
            item.Validate();
        }
    }

    public JourneyConditionNestedGroup() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyConditionNestedGroup(JourneyConditionNestedGroup journeyConditionNestedGroup)
        : base(journeyConditionNestedGroup) { }
#pragma warning restore CS8618

    public JourneyConditionNestedGroup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyConditionNestedGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyConditionNestedGroupFromRaw.FromRawUnchecked"/>
    public static JourneyConditionNestedGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyConditionNestedGroupFromRaw : IFromRawJson<JourneyConditionNestedGroup>
{
    /// <inheritdoc/>
    public JourneyConditionNestedGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyConditionNestedGroup.FromRawUnchecked(rawData);
}
