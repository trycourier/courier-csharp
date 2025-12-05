using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Auth;

[JsonConverter(typeof(ModelConverter<AuthIssueTokenResponse, AuthIssueTokenResponseFromRaw>))]
public sealed record class AuthIssueTokenResponse : ModelBase
{
    public required string Token
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "token"); }
        init { ModelBase.Set(this._rawData, "token", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Token;
    }

    public AuthIssueTokenResponse() { }

    public AuthIssueTokenResponse(AuthIssueTokenResponse authIssueTokenResponse)
        : base(authIssueTokenResponse) { }

    public AuthIssueTokenResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AuthIssueTokenResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AuthIssueTokenResponseFromRaw.FromRawUnchecked"/>
    public static AuthIssueTokenResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AuthIssueTokenResponse(string token)
        : this()
    {
        this.Token = token;
    }
}

class AuthIssueTokenResponseFromRaw : IFromRaw<AuthIssueTokenResponse>
{
    /// <inheritdoc/>
    public AuthIssueTokenResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AuthIssueTokenResponse.FromRawUnchecked(rawData);
}
