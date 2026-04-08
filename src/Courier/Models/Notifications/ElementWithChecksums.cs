using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Notifications;

/// <summary>
/// An element with its content checksum and optional nested elements and locale checksums.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ElementWithChecksums, ElementWithChecksumsFromRaw>))]
public sealed record class ElementWithChecksums : JsonModel
{
    /// <summary>
    /// MD5 hash of translatable content.
    /// </summary>
    public required string Checksum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("checksum");
        }
        init { this._rawData.Set("checksum", value); }
    }

    /// <summary>
    /// Element type (text, meta, action, etc.).
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Nested child elements (for group-type elements).
    /// </summary>
    public IReadOnlyList<ElementWithChecksums>? Elements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ElementWithChecksums>>(
                "elements"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ElementWithChecksums>?>(
                "elements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Locale-specific content with checksums.
    /// </summary>
    public IReadOnlyDictionary<string, LocalesItem>? Locales
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, LocalesItem>>("locales");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, LocalesItem>?>(
                "locales",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Checksum;
        _ = this.Type;
        _ = this.ID;
        foreach (var item in this.Elements ?? [])
        {
            item.Validate();
        }
        if (this.Locales != null)
        {
            foreach (var item in this.Locales.Values)
            {
                item.Validate();
            }
        }
    }

    public ElementWithChecksums() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementWithChecksums(ElementWithChecksums elementWithChecksums)
        : base(elementWithChecksums) { }
#pragma warning restore CS8618

    public ElementWithChecksums(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementWithChecksums(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementWithChecksumsFromRaw.FromRawUnchecked"/>
    public static ElementWithChecksums FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementWithChecksumsFromRaw : IFromRawJson<ElementWithChecksums>
{
    /// <inheritdoc/>
    public ElementWithChecksums FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementWithChecksums.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<LocalesItem, LocalesItemFromRaw>))]
public sealed record class LocalesItem : JsonModel
{
    public required string Checksum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("checksum");
        }
        init { this._rawData.Set("checksum", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Checksum;
    }

    public LocalesItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LocalesItem(LocalesItem localesItem)
        : base(localesItem) { }
#pragma warning restore CS8618

    public LocalesItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LocalesItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LocalesItemFromRaw.FromRawUnchecked"/>
    public static LocalesItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public LocalesItem(string checksum)
        : this()
    {
        this.Checksum = checksum;
    }
}

class LocalesItemFromRaw : IFromRawJson<LocalesItem>
{
    /// <inheritdoc/>
    public LocalesItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LocalesItem.FromRawUnchecked(rawData);
}
