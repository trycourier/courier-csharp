using Courier.Core;
using Models = Courier.Models;
using Templates = Courier.Models.Tenants.Templates;

namespace Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ContentVariants;

/// <summary>
/// Syntactic sugar to provide a fast shorthand for Courier Elemental Blocks.
/// </summary>
public sealed record class ElementalContentSugar(Models::ElementalContentSugar Value)
    : Content,
        IVariant<ElementalContentSugar, Models::ElementalContentSugar>
{
    public static ElementalContentSugar From(Models::ElementalContentSugar value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ElementalContent(Templates::ElementalContent Value)
    : Content,
        IVariant<ElementalContent, Templates::ElementalContent>
{
    public static ElementalContent From(Templates::ElementalContent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
