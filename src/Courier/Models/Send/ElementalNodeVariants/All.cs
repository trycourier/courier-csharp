using Courier.Core;
using ElementalNodeProperties = Courier.Models.Send.ElementalNodeProperties;

namespace Courier.Models.Send.ElementalNodeVariants;

public sealed record class UnionMember0(ElementalNodeProperties::UnionMember0 Value)
    : ElementalNode,
        IVariant<UnionMember0, ElementalNodeProperties::UnionMember0>
{
    public static UnionMember0 From(ElementalNodeProperties::UnionMember0 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UnionMember1(ElementalNodeProperties::UnionMember1 Value)
    : ElementalNode,
        IVariant<UnionMember1, ElementalNodeProperties::UnionMember1>
{
    public static UnionMember1 From(ElementalNodeProperties::UnionMember1 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// The channel element allows a notification to be customized based on which channel
/// it is sent through.  For example, you may want to display a detailed message
/// when the notification is sent through email,  and a more concise message in a
/// push notification. Channel elements are only valid as top-level  elements; you
/// cannot nest channel elements. If there is a channel element specified at the
/// top-level  of the document, all sibling elements must be channel elements. Note:
/// As an alternative, most elements support a `channel` property. Which allows you
/// to selectively  display an individual element on a per channel basis. See the
///  [control flow docs](https://www.courier.com/docs/platform/content/elemental/control-flow/)
/// for more details.
/// </summary>
public sealed record class UnionMember2(ElementalNodeProperties::UnionMember2 Value)
    : ElementalNode,
        IVariant<UnionMember2, ElementalNodeProperties::UnionMember2>
{
    public static UnionMember2 From(ElementalNodeProperties::UnionMember2 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UnionMember3(ElementalNodeProperties::UnionMember3 Value)
    : ElementalNode,
        IVariant<UnionMember3, ElementalNodeProperties::UnionMember3>
{
    public static UnionMember3 From(ElementalNodeProperties::UnionMember3 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UnionMember4(ElementalNodeProperties::UnionMember4 Value)
    : ElementalNode,
        IVariant<UnionMember4, ElementalNodeProperties::UnionMember4>
{
    public static UnionMember4 From(ElementalNodeProperties::UnionMember4 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UnionMember5(ElementalNodeProperties::UnionMember5 Value)
    : ElementalNode,
        IVariant<UnionMember5, ElementalNodeProperties::UnionMember5>
{
    public static UnionMember5 From(ElementalNodeProperties::UnionMember5 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UnionMember6(ElementalNodeProperties::UnionMember6 Value)
    : ElementalNode,
        IVariant<UnionMember6, ElementalNodeProperties::UnionMember6>
{
    public static UnionMember6 From(ElementalNodeProperties::UnionMember6 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
