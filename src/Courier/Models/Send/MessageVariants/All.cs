using Courier.Core;
using MessageProperties = Courier.Models.Send.MessageProperties;

namespace Courier.Models.Send.MessageVariants;

/// <summary>
/// Describes the content of the message in a way that will work for email, push,
/// chat, or any channel.
/// </summary>
public sealed record class ContentMessage(MessageProperties::ContentMessage Value)
    : Message,
        IVariant<ContentMessage, MessageProperties::ContentMessage>
{
    public static ContentMessage From(MessageProperties::ContentMessage value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// A template for a type of message that can be sent more than once. For example,
/// you might create an "Appointment Reminder" Notification or “Reset Password” Notifications.
/// </summary>
public sealed record class TemplateMessage(MessageProperties::TemplateMessage Value)
    : Message,
        IVariant<TemplateMessage, MessageProperties::TemplateMessage>
{
    public static TemplateMessage From(MessageProperties::TemplateMessage value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
