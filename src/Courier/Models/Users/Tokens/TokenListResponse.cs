using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Users.Tokens;

/// <summary>
/// A list of tokens registered with the user.
/// </summary>
[JsonConverter(typeof(ModelConverter<TokenListResponse, TokenListResponseFromRaw>))]
public sealed record class TokenListResponse : ModelBase
{
    public required IReadOnlyList<UserToken> Tokens
    {
        get { return ModelBase.GetNotNullClass<List<UserToken>>(this.RawData, "tokens"); }
        init { ModelBase.Set(this._rawData, "tokens", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Tokens)
        {
            item.Validate();
        }
    }

    public TokenListResponse() { }

    public TokenListResponse(TokenListResponse tokenListResponse)
        : base(tokenListResponse) { }

    public TokenListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TokenListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TokenListResponseFromRaw.FromRawUnchecked"/>
    public static TokenListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TokenListResponse(List<UserToken> tokens)
        : this()
    {
        this.Tokens = tokens;
    }
}

class TokenListResponseFromRaw : IFromRaw<TokenListResponse>
{
    /// <inheritdoc/>
    public TokenListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TokenListResponse.FromRawUnchecked(rawData);
}
