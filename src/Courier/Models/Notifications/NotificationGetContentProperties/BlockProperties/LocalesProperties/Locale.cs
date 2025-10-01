using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Notifications.NotificationGetContentProperties.BlockProperties.LocalesProperties.LocaleProperties;
using LocaleVariants = Courier.Models.Notifications.NotificationGetContentProperties.BlockProperties.LocalesProperties.LocaleVariants;
using System = System;

namespace Courier.Models.Notifications.NotificationGetContentProperties.BlockProperties.LocalesProperties;

[JsonConverter(typeof(LocaleConverter))]
public abstract record class Locale
{
    internal Locale() { }

    public static implicit operator Locale(string value) => new LocaleVariants::String(value);

    public static implicit operator Locale(NotificationContentHierarchy value) =>
        new LocaleVariants::NotificationContentHierarchy(value);

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as LocaleVariants::String)?.Value;
        return value != null;
    }

    public bool TryPickNotificationContentHierarchy(
        [NotNullWhen(true)] out NotificationContentHierarchy? value
    )
    {
        value = (this as LocaleVariants::NotificationContentHierarchy)?.Value;
        return value != null;
    }

    public void Switch(
        System::Action<LocaleVariants::String> @string,
        System::Action<LocaleVariants::NotificationContentHierarchy> notificationContentHierarchy
    )
    {
        switch (this)
        {
            case LocaleVariants::String inner:
                @string(inner);
                break;
            case LocaleVariants::NotificationContentHierarchy inner:
                notificationContentHierarchy(inner);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of Locale");
        }
    }

    public T Match<T>(
        System::Func<LocaleVariants::String, T> @string,
        System::Func<LocaleVariants::NotificationContentHierarchy, T> notificationContentHierarchy
    )
    {
        return this switch
        {
            LocaleVariants::String inner => @string(inner),
            LocaleVariants::NotificationContentHierarchy inner => notificationContentHierarchy(
                inner
            ),
            _ => throw new CourierInvalidDataException("Data did not match any variant of Locale"),
        };
    }

    public abstract void Validate();
}

sealed class LocaleConverter : JsonConverter<Locale>
{
    public override Locale? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<CourierInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<NotificationContentHierarchy>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new LocaleVariants::NotificationContentHierarchy(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant LocaleVariants::NotificationContentHierarchy",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new LocaleVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant LocaleVariants::String",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Locale value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            LocaleVariants::String(var @string) => @string,
            LocaleVariants::NotificationContentHierarchy(var notificationContentHierarchy) =>
                notificationContentHierarchy,
            _ => throw new CourierInvalidDataException("Data did not match any variant of Locale"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
