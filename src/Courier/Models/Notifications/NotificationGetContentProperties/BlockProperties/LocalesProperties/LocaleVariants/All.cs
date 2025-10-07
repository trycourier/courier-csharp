using Courier.Core;
using LocaleProperties = Courier.Models.Notifications.NotificationGetContentProperties.BlockProperties.LocalesProperties.LocaleProperties;

namespace Courier.Models.Notifications.NotificationGetContentProperties.BlockProperties.LocalesProperties.LocaleVariants;

public sealed record class String(string Value) : Locale, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class NotificationContentHierarchy(
    LocaleProperties::NotificationContentHierarchy Value
) : Locale, IVariant<NotificationContentHierarchy, LocaleProperties::NotificationContentHierarchy>
{
    public static NotificationContentHierarchy From(
        LocaleProperties::NotificationContentHierarchy value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
