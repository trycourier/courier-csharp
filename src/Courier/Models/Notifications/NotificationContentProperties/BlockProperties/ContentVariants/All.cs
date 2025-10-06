using Courier.Core;
using ContentProperties = Courier.Models.Notifications.NotificationContentProperties.BlockProperties.ContentProperties;

namespace Courier.Models.Notifications.NotificationContentProperties.BlockProperties.ContentVariants;

public sealed record class String(string Value) : Content, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class NotificationContentHierarchy(
    ContentProperties::NotificationContentHierarchy Value
) : Content, IVariant<NotificationContentHierarchy, ContentProperties::NotificationContentHierarchy>
{
    public static NotificationContentHierarchy From(
        ContentProperties::NotificationContentHierarchy value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
