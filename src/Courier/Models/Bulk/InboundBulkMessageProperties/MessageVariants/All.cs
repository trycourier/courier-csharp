using Courier.Core;
using MessageProperties = Courier.Models.Bulk.InboundBulkMessageProperties.MessageProperties;

namespace Courier.Models.Bulk.InboundBulkMessageProperties.MessageVariants;

/// <summary>
/// Describes the content of the message in a way that will  work for email, push,
/// chat, or any channel.
/// </summary>
public sealed record class InboundBulkTemplateMessage(
    MessageProperties::InboundBulkTemplateMessage Value
) : Message, IVariant<InboundBulkTemplateMessage, MessageProperties::InboundBulkTemplateMessage>
{
    public static InboundBulkTemplateMessage From(
        MessageProperties::InboundBulkTemplateMessage value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// A template for a type of message that can be sent more than once.  For example,
/// you might create an "Appointment Reminder" Notification or “Reset Password” Notifications.
/// </summary>
public sealed record class InboundBulkContentMessage(
    MessageProperties::InboundBulkContentMessage Value
) : Message, IVariant<InboundBulkContentMessage, MessageProperties::InboundBulkContentMessage>
{
    public static InboundBulkContentMessage From(MessageProperties::InboundBulkContentMessage value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
