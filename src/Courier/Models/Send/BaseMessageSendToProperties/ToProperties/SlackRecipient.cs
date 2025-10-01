using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Send.BaseMessageSendToProperties.ToProperties.SlackRecipientProperties;

namespace Courier.Models.Send.BaseMessageSendToProperties.ToProperties;

[JsonConverter(typeof(ModelConverter<SlackRecipient>))]
public sealed record class SlackRecipient : ModelBase, IFromRaw<SlackRecipient>
{
    public required Slack Slack
    {
        get
        {
            if (!this.Properties.TryGetValue("slack", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'slack' cannot be null",
                    new ArgumentOutOfRangeException("slack", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Slack>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'slack' cannot be null",
                    new ArgumentNullException("slack")
                );
        }
        set
        {
            this.Properties["slack"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Slack.Validate();
    }

    public SlackRecipient() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SlackRecipient(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SlackRecipient FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public SlackRecipient(Slack slack)
        : this()
    {
        this.Slack = slack;
    }
}
