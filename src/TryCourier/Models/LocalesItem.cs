using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models;

[JsonConverter(typeof(JsonModelConverter<LocalesItem, LocalesItemFromRaw>))]
public sealed record class LocalesItem : JsonModel
{
    public required string Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
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
    public LocalesItem(string content)
        : this()
    {
        this.Content = content;
    }
}

class LocalesItemFromRaw : IFromRawJson<LocalesItem>
{
    /// <inheritdoc/>
    public LocalesItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LocalesItem.FromRawUnchecked(rawData);
}
