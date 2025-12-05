using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

/// <summary>
/// Syntactic sugar to provide a fast shorthand for Courier Elemental Blocks.
/// </summary>
[JsonConverter(typeof(ModelConverter<ElementalContentSugar, ElementalContentSugarFromRaw>))]
public sealed record class ElementalContentSugar : ModelBase
{
    /// <summary>
    /// The text content displayed in the notification.
    /// </summary>
    public required string Body
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "body"); }
        init { ModelBase.Set(this._rawData, "body", value); }
    }

    /// <summary>
    /// Title/subject displayed by supported channels.
    /// </summary>
    public required string Title
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "title"); }
        init { ModelBase.Set(this._rawData, "title", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Body;
        _ = this.Title;
    }

    public ElementalContentSugar() { }

    public ElementalContentSugar(ElementalContentSugar elementalContentSugar)
        : base(elementalContentSugar) { }

    public ElementalContentSugar(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalContentSugar(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalContentSugarFromRaw.FromRawUnchecked"/>
    public static ElementalContentSugar FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalContentSugarFromRaw : IFromRaw<ElementalContentSugar>
{
    /// <inheritdoc/>
    public ElementalContentSugar FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalContentSugar.FromRawUnchecked(rawData);
}
