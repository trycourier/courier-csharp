using Courier.Core;
using SlackProperties = Courier.Models.Send.RecipientProperties.SlackRecipientProperties.SlackProperties;

namespace Courier.Models.Send.RecipientProperties.SlackRecipientProperties.SlackVariants;

public sealed record class SendToSlackChannel(SlackProperties::SendToSlackChannel Value)
    : Slack,
        IVariant<SendToSlackChannel, SlackProperties::SendToSlackChannel>
{
    public static SendToSlackChannel From(SlackProperties::SendToSlackChannel value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class SendToSlackEmail(SlackProperties::SendToSlackEmail Value)
    : Slack,
        IVariant<SendToSlackEmail, SlackProperties::SendToSlackEmail>
{
    public static SendToSlackEmail From(SlackProperties::SendToSlackEmail value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class SendToSlackUserID(SlackProperties::SendToSlackUserID Value)
    : Slack,
        IVariant<SendToSlackUserID, SlackProperties::SendToSlackUserID>
{
    public static SendToSlackUserID From(SlackProperties::SendToSlackUserID value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
