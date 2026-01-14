using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<SendToSlackEmail, SendToSlackEmailFromRaw>))]
public sealed record class SendToSlackEmail : JsonModel
{
    public required string AccessToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("access_token");
        }
        init { this._rawData.Set("access_token", value); }
    }

    public required string Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccessToken;
        _ = this.Email;
    }

    public SendToSlackEmail() { }

    public SendToSlackEmail(SendToSlackEmail sendToSlackEmail)
        : base(sendToSlackEmail) { }

    public SendToSlackEmail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToSlackEmail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SendToSlackEmailFromRaw.FromRawUnchecked"/>
    public static SendToSlackEmail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SendToSlackEmailFromRaw : IFromRawJson<SendToSlackEmail>
{
    /// <inheritdoc/>
    public SendToSlackEmail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SendToSlackEmail.FromRawUnchecked(rawData);
}
