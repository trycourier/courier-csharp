using Courier.Core;
using InboundBulkMessageProperties = Courier.Models.Bulk.InboundBulkMessageProperties;

namespace Courier.Models.Bulk.InboundBulkMessageVariants;

public sealed record class InboundBulkTemplateMessage(
    InboundBulkMessageProperties::InboundBulkTemplateMessage Value
)
    : InboundBulkMessage,
        IVariant<
            InboundBulkTemplateMessage,
            InboundBulkMessageProperties::InboundBulkTemplateMessage
        >
{
    public static InboundBulkTemplateMessage From(
        InboundBulkMessageProperties::InboundBulkTemplateMessage value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class InboundBulkContentMessage(
    InboundBulkMessageProperties::InboundBulkContentMessage Value
)
    : InboundBulkMessage,
        IVariant<InboundBulkContentMessage, InboundBulkMessageProperties::InboundBulkContentMessage>
{
    public static InboundBulkContentMessage From(
        InboundBulkMessageProperties::InboundBulkContentMessage value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
