using System.Collections.Generic;
using Courier.Core;
using ToProperties = Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ToProperties;

namespace Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ToVariants;

public sealed record class UnionMember0(ToProperties::UnionMember0 Value)
    : To,
        IVariant<UnionMember0, ToProperties::UnionMember0>
{
    public static UnionMember0 From(ToProperties::UnionMember0 value)
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
