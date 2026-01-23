using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Users.Tokens;

/// <summary>
/// A list of tokens registered with the user.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TokenListResponse, TokenListResponseFromRaw>))]
public sealed record class TokenListResponse : JsonModel
{
    public required IReadOnlyList<UserToken> Tokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UserToken>>("tokens");
        }
        init
        {
            this._rawData.Set<ImmutableArray<UserToken>>(
                "tokens",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TokenListResponse(TokenListResponse tokenListResponse)
        : base(tokenListResponse) { }
#pragma warning restore CS8618

    public TokenListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TokenListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
    public TokenListResponse(IReadOnlyList<UserToken> tokens)
        : this()
    {
        this.Tokens = tokens;
    }
}

class TokenListResponseFromRaw : IFromRawJson<TokenListResponse>
{
    /// <inheritdoc/>
    public TokenListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TokenListResponse.FromRawUnchecked(rawData);
}
