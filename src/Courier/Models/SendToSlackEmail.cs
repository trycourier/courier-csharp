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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "access_token"); }
        init { JsonModel.Set(this._rawData, "access_token", value); }
    }

    public required string Email
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "email"); }
        init { JsonModel.Set(this._rawData, "email", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToSlackEmail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
