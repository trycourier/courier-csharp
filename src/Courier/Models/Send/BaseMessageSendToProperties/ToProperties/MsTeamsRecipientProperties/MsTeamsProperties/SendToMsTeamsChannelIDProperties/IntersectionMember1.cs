using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Send.BaseMessageSendToProperties.ToProperties.MsTeamsRecipientProperties.MsTeamsProperties.SendToMsTeamsChannelIDProperties;

[JsonConverter(typeof(ModelConverter<IntersectionMember1>))]
public sealed record class IntersectionMember1 : ModelBase, IFromRaw<IntersectionMember1>
{
    public required string ChannelID
    {
        get
        {
            if (!this.Properties.TryGetValue("channel_id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'channel_id' cannot be null",
                    new ArgumentOutOfRangeException("channel_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'channel_id' cannot be null",
                    new ArgumentNullException("channel_id")
                );
        }
        set
        {
            this.Properties["channel_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ChannelID;
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

    [SetsRequiredMembers]
    public IntersectionMember1(string channelID)
        : this()
    {
        this.ChannelID = channelID;
    }
}
