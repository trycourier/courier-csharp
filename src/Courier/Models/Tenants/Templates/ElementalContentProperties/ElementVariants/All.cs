using Courier.Core;
using ElementProperties = Courier.Models.Tenants.Templates.ElementalContentProperties.ElementProperties;

namespace Courier.Models.Tenants.Templates.ElementalContentProperties.ElementVariants;

public sealed record class UnionMember0(ElementProperties::UnionMember0 Value)
    : Element,
        IVariant<UnionMember0, ElementProperties::UnionMember0>
{
    public static UnionMember0 From(ElementProperties::UnionMember0 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UnionMember1(ElementProperties::UnionMember1 Value)
    : Element,
        IVariant<UnionMember1, ElementProperties::UnionMember1>
{
    public static UnionMember1 From(ElementProperties::UnionMember1 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UnionMember2(ElementProperties::UnionMember2 Value)
    : Element,
        IVariant<UnionMember2, ElementProperties::UnionMember2>
{
    public static UnionMember2 From(ElementProperties::UnionMember2 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UnionMember3(ElementProperties::UnionMember3 Value)
    : Element,
        IVariant<UnionMember3, ElementProperties::UnionMember3>
{
    public static UnionMember3 From(ElementProperties::UnionMember3 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UnionMember4(ElementProperties::UnionMember4 Value)
    : Element,
        IVariant<UnionMember4, ElementProperties::UnionMember4>
{
    public static UnionMember4 From(ElementProperties::UnionMember4 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UnionMember5(ElementProperties::UnionMember5 Value)
    : Element,
        IVariant<UnionMember5, ElementProperties::UnionMember5>
{
    public static UnionMember5 From(ElementProperties::UnionMember5 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UnionMember6(ElementProperties::UnionMember6 Value)
    : Element,
        IVariant<UnionMember6, ElementProperties::UnionMember6>
{
    public static UnionMember6 From(ElementProperties::UnionMember6 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
