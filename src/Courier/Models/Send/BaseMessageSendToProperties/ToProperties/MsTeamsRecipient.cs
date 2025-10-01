using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Send.BaseMessageSendToProperties.ToProperties.MsTeamsRecipientProperties;

namespace Courier.Models.Send.BaseMessageSendToProperties.ToProperties;

[JsonConverter(typeof(ModelConverter<MsTeamsRecipient>))]
public sealed record class MsTeamsRecipient : ModelBase, IFromRaw<MsTeamsRecipient>
{
    public required MsTeams MsTeams
    {
        get
        {
            if (!this.Properties.TryGetValue("ms_teams", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'ms_teams' cannot be null",
                    new ArgumentOutOfRangeException("ms_teams", "Missing required argument")
                );

            return JsonSerializer.Deserialize<MsTeams>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'ms_teams' cannot be null",
                    new ArgumentNullException("ms_teams")
                );
        }
        set
        {
            this.Properties["ms_teams"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.MsTeams.Validate();
    }

    public MsTeamsRecipient() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MsTeamsRecipient(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MsTeamsRecipient FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public MsTeamsRecipient(MsTeams msTeams)
        : this()
    {
        this.MsTeams = msTeams;
    }
}
