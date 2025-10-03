using Courier.Core;
using Send = Courier.Models.Send;

namespace Courier.Models.Send.MessageRoutingChannelVariants;

public sealed record class String(string Value) : MessageRoutingChannel, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class MessageRouting(Send::MessageRouting Value)
    : MessageRoutingChannel,
        IVariant<MessageRouting, Send::MessageRouting>
{
    public static MessageRouting From(Send::MessageRouting value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
