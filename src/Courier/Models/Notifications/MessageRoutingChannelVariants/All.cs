using Courier.Core;
using Notifications = Courier.Models.Notifications;

namespace Courier.Models.Notifications.MessageRoutingChannelVariants;

public sealed record class String(string Value) : MessageRoutingChannel, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class MessageRouting(Notifications::MessageRouting Value)
    : MessageRoutingChannel,
        IVariant<MessageRouting, Notifications::MessageRouting>
{
    public static MessageRouting From(Notifications::MessageRouting value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
