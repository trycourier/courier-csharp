using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<MultipleTokens, MultipleTokensFromRaw>))]
public sealed record class MultipleTokens : JsonModel
{
    public required IReadOnlyList<Token> Tokens
    {
        get { return JsonModel.GetNotNullClass<List<Token>>(this.RawData, "tokens"); }
        init { JsonModel.Set(this._rawData, "tokens", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Tokens)
        {
            item.Validate();
        }
    }

    public MultipleTokens() { }

    public MultipleTokens(MultipleTokens multipleTokens)
        : base(multipleTokens) { }

    public MultipleTokens(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MultipleTokens(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MultipleTokensFromRaw.FromRawUnchecked"/>
    public static MultipleTokens FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MultipleTokens(List<Token> tokens)
        : this()
    {
        this.Tokens = tokens;
    }
}

class MultipleTokensFromRaw : IFromRawJson<MultipleTokens>
{
    /// <inheritdoc/>
    public MultipleTokens FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MultipleTokens.FromRawUnchecked(rawData);
}
