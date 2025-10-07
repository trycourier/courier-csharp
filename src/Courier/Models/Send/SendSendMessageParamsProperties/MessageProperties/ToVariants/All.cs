using System.Collections.Generic;
using Courier.Core;
using Bulk = Courier.Models.Bulk;

namespace Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ToVariants;

public sealed record class UserRecipient(Bulk::UserRecipient Value)
    : To,
        IVariant<UserRecipient, Bulk::UserRecipient>
{
    public static UserRecipient From(Bulk::UserRecipient value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class Recipients(List<Recipient> Value)
    : To,
        IVariant<Recipients, List<Recipient>>
{
    public static Recipients From(List<Recipient> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
