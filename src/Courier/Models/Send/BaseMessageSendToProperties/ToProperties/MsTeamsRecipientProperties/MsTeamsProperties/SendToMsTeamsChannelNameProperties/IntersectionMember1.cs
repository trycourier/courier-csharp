using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Send.BaseMessageSendToProperties.ToProperties.MsTeamsRecipientProperties.MsTeamsProperties.SendToMsTeamsChannelNameProperties;

[JsonConverter(typeof(ModelConverter<IntersectionMember1>))]
public sealed record class IntersectionMember1 : ModelBase, IFromRaw<IntersectionMember1>
{
    public required string ChannelName
    {
        get
        {
            if (!this.Properties.TryGetValue("channel_name", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'channel_name' cannot be null",
                    new ArgumentOutOfRangeException("channel_name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'channel_name' cannot be null",
                    new ArgumentNullException("channel_name")
                );
        }
        set
        {
            this.Properties["channel_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string TeamID
    {
        get
        {
            if (!this.Properties.TryGetValue("team_id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'team_id' cannot be null",
                    new ArgumentOutOfRangeException("team_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'team_id' cannot be null",
                    new ArgumentNullException("team_id")
                );
        }
        set
        {
            this.Properties["team_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ChannelName;
        _ = this.TeamID;
    }

    public IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static IntersectionMember1 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
