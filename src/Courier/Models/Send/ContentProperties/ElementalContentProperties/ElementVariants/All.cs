using Courier.Core;
using ElementProperties = Courier.Models.Send.ContentProperties.ElementalContentProperties.ElementProperties;

namespace Courier.Models.Send.ContentProperties.ElementalContentProperties.ElementVariants;

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

public sealed record class Type(ElementProperties::Type Value)
    : Element,
        IVariant<Type, ElementProperties::Type>
{
    public static Type From(ElementProperties::Type value)
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

public sealed record class TypeModel(ElementProperties::TypeModel Value)
    : Element,
        IVariant<TypeModel, ElementProperties::TypeModel>
{
    public static TypeModel From(ElementProperties::TypeModel value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UnionMember7(ElementProperties::UnionMember7 Value)
    : Element,
        IVariant<UnionMember7, ElementProperties::UnionMember7>
{
    public static UnionMember7 From(ElementProperties::UnionMember7 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
