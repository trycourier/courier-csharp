using Courier.Core;
using MsTeamsProperties = Courier.Models.Send.RecipientProperties.MsTeamsRecipientProperties.MsTeamsProperties;

namespace Courier.Models.Send.RecipientProperties.MsTeamsRecipientProperties.MsTeamsVariants;

public sealed record class SendToMsTeamsUserID(MsTeamsProperties::SendToMsTeamsUserID Value)
    : MsTeams,
        IVariant<SendToMsTeamsUserID, MsTeamsProperties::SendToMsTeamsUserID>
{
    public static SendToMsTeamsUserID From(MsTeamsProperties::SendToMsTeamsUserID value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class SendToMsTeamsEmail(MsTeamsProperties::SendToMsTeamsEmail Value)
    : MsTeams,
        IVariant<SendToMsTeamsEmail, MsTeamsProperties::SendToMsTeamsEmail>
{
    public static SendToMsTeamsEmail From(MsTeamsProperties::SendToMsTeamsEmail value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class SendToMsTeamsChannelID(MsTeamsProperties::SendToMsTeamsChannelID Value)
    : MsTeams,
        IVariant<SendToMsTeamsChannelID, MsTeamsProperties::SendToMsTeamsChannelID>
{
    public static SendToMsTeamsChannelID From(MsTeamsProperties::SendToMsTeamsChannelID value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class SendToMsTeamsConversationID(
    MsTeamsProperties::SendToMsTeamsConversationID Value
) : MsTeams, IVariant<SendToMsTeamsConversationID, MsTeamsProperties::SendToMsTeamsConversationID>
{
    public static SendToMsTeamsConversationID From(
        MsTeamsProperties::SendToMsTeamsConversationID value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class SendToMsTeamsChannelName(
    MsTeamsProperties::SendToMsTeamsChannelName Value
) : MsTeams, IVariant<SendToMsTeamsChannelName, MsTeamsProperties::SendToMsTeamsChannelName>
{
    public static SendToMsTeamsChannelName From(MsTeamsProperties::SendToMsTeamsChannelName value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
