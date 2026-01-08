using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<SendToMsTeamsEmail, SendToMsTeamsEmailFromRaw>))]
public sealed record class SendToMsTeamsEmail : JsonModel
{
    public required string Email
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "email"); }
        init { JsonModel.Set(this._rawData, "email", value); }
    }

    public required string ServiceUrl
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "service_url"); }
        init { JsonModel.Set(this._rawData, "service_url", value); }
    }

    public required string TenantID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "tenant_id"); }
        init { JsonModel.Set(this._rawData, "tenant_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.ServiceUrl;
        _ = this.TenantID;
    }

    public SendToMsTeamsEmail() { }

    public SendToMsTeamsEmail(SendToMsTeamsEmail sendToMsTeamsEmail)
        : base(sendToMsTeamsEmail) { }

    public SendToMsTeamsEmail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToMsTeamsEmail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SendToMsTeamsEmailFromRaw.FromRawUnchecked"/>
    public static SendToMsTeamsEmail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SendToMsTeamsEmailFromRaw : IFromRawJson<SendToMsTeamsEmail>
{
    /// <inheritdoc/>
    public SendToMsTeamsEmail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SendToMsTeamsEmail.FromRawUnchecked(rawData);
}
