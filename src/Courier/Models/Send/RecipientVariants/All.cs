using Courier.Core;
using Models = Courier.Models;

namespace Courier.Models.Send.RecipientVariants;

public sealed record class UserRecipient(Models::UserRecipient Value)
    : Recipient,
        IVariant<UserRecipient, Models::UserRecipient>
{
    public static UserRecipient From(Models::UserRecipient value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ListRecipient(Models::ListRecipient Value)
    : Recipient,
        IVariant<ListRecipient, Models::ListRecipient>
{
    public static ListRecipient From(Models::ListRecipient value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
