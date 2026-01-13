using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

/// <summary>
/// Send via Microsoft Teams
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MsTeamsRecipient, MsTeamsRecipientFromRaw>))]
public sealed record class MsTeamsRecipient : JsonModel
{
    public required MsTeams MsTeams
    {
        get { return this._rawData.GetNotNullClass<MsTeams>("ms_teams"); }
        init { this._rawData.Set("ms_teams", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.MsTeams.Validate();
    }

    public MsTeamsRecipient() { }

    public MsTeamsRecipient(MsTeamsRecipient msTeamsRecipient)
        : base(msTeamsRecipient) { }

    public MsTeamsRecipient(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MsTeamsRecipient(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MsTeamsRecipientFromRaw.FromRawUnchecked"/>
    public static MsTeamsRecipient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MsTeamsRecipient(MsTeams msTeams)
        : this()
    {
        this.MsTeams = msTeams;
    }
}

class MsTeamsRecipientFromRaw : IFromRawJson<MsTeamsRecipient>
{
    /// <inheritdoc/>
    public MsTeamsRecipient FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MsTeamsRecipient.FromRawUnchecked(rawData);
}
