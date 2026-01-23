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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    public required string ServiceUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("service_url");
        }
        init { this._rawData.Set("service_url", value); }
    }

    public required string TenantID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tenant_id");
        }
        init { this._rawData.Set("tenant_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.ServiceUrl;
        _ = this.TenantID;
    }

    public SendToMsTeamsEmail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SendToMsTeamsEmail(SendToMsTeamsEmail sendToMsTeamsEmail)
        : base(sendToMsTeamsEmail) { }
#pragma warning restore CS8618

    public SendToMsTeamsEmail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToMsTeamsEmail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
