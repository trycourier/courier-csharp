using Courier.Core;
using ContentProperties = Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ContentProperties;

namespace Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ContentVariants;

/// <summary>
/// Syntactic sugar to provide a fast shorthand for Courier Elemental Blocks.
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
