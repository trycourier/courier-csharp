using Courier.Core;
using ContentProperties = Courier.Models.Bulk.InboundBulkMessageProperties.InboundBulkContentMessageProperties.ContentProperties;
using Templates = Courier.Models.Tenants.Templates;

namespace Courier.Models.Bulk.InboundBulkMessageProperties.InboundBulkContentMessageProperties.ContentVariants;

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
