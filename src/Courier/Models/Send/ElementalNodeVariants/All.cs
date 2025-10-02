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

public sealed record class Type(ElementalNodeProperties::Type Value)
    : ElementalNode,
        IVariant<Type, ElementalNodeProperties::Type>
{
    public static Type From(ElementalNodeProperties::Type value)
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

/// <summary>
/// Allows you to group elements together. This can be useful when used in combination
/// with "if" or "loop". See [control flow docs](https://www.courier.com/docs/platform/content/elemental/control-flow/)
/// for more details.
/// </summary>
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

public sealed record class UnionMember7(ElementalNodeProperties::UnionMember7 Value)
    : ElementalNode,
        IVariant<UnionMember7, ElementalNodeProperties::UnionMember7>
{
    public static UnionMember7 From(ElementalNodeProperties::UnionMember7 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
