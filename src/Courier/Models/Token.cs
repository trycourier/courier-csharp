using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<Token, TokenFromRaw>))]
public sealed record class Token : JsonModel
{
    public required string TokenValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("token");
        }
        init { this._rawData.Set("token", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TokenValue;
    }

    public Token() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Token(Token token)
        : base(token) { }
#pragma warning restore CS8618

    public Token(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Token(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TokenFromRaw.FromRawUnchecked"/>
    public static Token FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Token(string tokenValue)
        : this()
    {
        this.TokenValue = tokenValue;
    }
}

class TokenFromRaw : IFromRawJson<Token>
{
    /// <inheritdoc/>
    public Token FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Token.FromRawUnchecked(rawData);
}
