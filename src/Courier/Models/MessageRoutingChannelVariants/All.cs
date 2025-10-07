using Courier.Core;
using Models = Courier.Models;

namespace Courier.Models.MessageRoutingChannelVariants;

public sealed record class String(string Value) : MessageRoutingChannel, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class MessageRouting(Models::MessageRouting Value)
    : MessageRoutingChannel,
        IVariant<MessageRouting, Models::MessageRouting>
{
    public static MessageRouting From(Models::MessageRouting value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
