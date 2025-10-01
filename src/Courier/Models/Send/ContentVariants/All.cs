using Courier.Core;
using ContentProperties = Courier.Models.Send.ContentProperties;

namespace Courier.Models.Send.ContentVariants;

public sealed record class ElementalContent(ContentProperties::ElementalContent Value)
    : Content,
        IVariant<ElementalContent, ContentProperties::ElementalContent>
{
    public static ElementalContent From(ContentProperties::ElementalContent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// Syntatic Sugar to provide a fast shorthand for Courier Elemental Blocks.
/// </summary>
public sealed record class ElementalContentSugar(ContentProperties::ElementalContentSugar Value)
    : Content,
        IVariant<ElementalContentSugar, ContentProperties::ElementalContentSugar>
{
    public static ElementalContentSugar From(ContentProperties::ElementalContentSugar value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
