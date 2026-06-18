using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Journeys;

/// <summary>
/// A leaf condition group. Exactly one of `AND` or `OR` must be present at runtime;
/// each is a list of `JourneyConditionAtom` tuples.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JourneyConditionGroup, JourneyConditionGroupFromRaw>))]
public sealed record class JourneyConditionGroup : JsonModel
{
    public IReadOnlyList<IReadOnlyList<string>>? And
    {
        get
        {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableStruct<ImmutableArray<ImmutableArray<string>>>(
                "AND"
            );
            if (value == null)
            {
                return null;
            }

            return ImmutableArray.ToImmutableArray(
                Enumerable.Select(value.Value, (item) => (IReadOnlyList<string>)item)
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ImmutableArray<string>>?>(
                "AND",
                value == null
                    ? null
                    : ImmutableArray.ToImmutableArray(
                        Enumerable.Select(value, (item) => ImmutableArray.ToImmutableArray(item))
                    )
            );
        }
    }

    public IReadOnlyList<IReadOnlyList<string>>? Or
    {
        get
        {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableStruct<ImmutableArray<ImmutableArray<string>>>(
                "OR"
            );
            if (value == null)
            {
                return null;
            }

            return ImmutableArray.ToImmutableArray(
                Enumerable.Select(value.Value, (item) => (IReadOnlyList<string>)item)
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ImmutableArray<string>>?>(
                "OR",
                value == null
                    ? null
                    : ImmutableArray.ToImmutableArray(
                        Enumerable.Select(value, (item) => ImmutableArray.ToImmutableArray(item))
                    )
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.And;
        _ = this.Or;
    }

    public JourneyConditionGroup() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyConditionGroup(JourneyConditionGroup journeyConditionGroup)
        : base(journeyConditionGroup) { }
#pragma warning restore CS8618

    public JourneyConditionGroup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyConditionGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyConditionGroupFromRaw.FromRawUnchecked"/>
    public static JourneyConditionGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyConditionGroupFromRaw : IFromRawJson<JourneyConditionGroup>
{
    /// <inheritdoc/>
    public JourneyConditionGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyConditionGroup.FromRawUnchecked(rawData);
}
