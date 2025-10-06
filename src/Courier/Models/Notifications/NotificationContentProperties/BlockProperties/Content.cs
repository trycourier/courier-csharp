using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Notifications.NotificationContentProperties.BlockProperties.ContentProperties;
using ContentVariants = Courier.Models.Notifications.NotificationContentProperties.BlockProperties.ContentVariants;
using System = System;

namespace Courier.Models.Notifications.NotificationContentProperties.BlockProperties;

[JsonConverter(typeof(ContentConverter))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(string value) => new ContentVariants::String(value);

    public static implicit operator Content(NotificationContentHierarchy value) =>
        new ContentVariants::NotificationContentHierarchy(value);

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as ContentVariants::String)?.Value;
        return value != null;
    }

    public bool TryPickNotificationContentHierarchy(
        [NotNullWhen(true)] out NotificationContentHierarchy? value
    )
    {
        value = (this as ContentVariants::NotificationContentHierarchy)?.Value;
        return value != null;
    }

    public void Switch(
        System::Action<ContentVariants::String> @string,
        System::Action<ContentVariants::NotificationContentHierarchy> notificationContentHierarchy
    )
    {
        switch (this)
        {
            case ContentVariants::String inner:
                @string(inner);
                break;
            case ContentVariants::NotificationContentHierarchy inner:
                notificationContentHierarchy(inner);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of Content");
        }
    }

    public T Match<T>(
        System::Func<ContentVariants::String, T> @string,
        System::Func<ContentVariants::NotificationContentHierarchy, T> notificationContentHierarchy
    )
    {
        return this switch
        {
            ContentVariants::String inner => @string(inner),
            ContentVariants::NotificationContentHierarchy inner => notificationContentHierarchy(
                inner
            ),
            _ => throw new CourierInvalidDataException("Data did not match any variant of Content"),
        };
    }

    public abstract void Validate();
}

sealed class ContentConverter : JsonConverter<Content?>
{
    public override Content? Read(
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
                return new ContentVariants::NotificationContentHierarchy(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ContentVariants::NotificationContentHierarchy",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new ContentVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ContentVariants::String",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content? value, JsonSerializerOptions options)
    {
        object? variant = value switch
        {
            null => null,
            ContentVariants::String(var @string) => @string,
            ContentVariants::NotificationContentHierarchy(var notificationContentHierarchy) =>
                notificationContentHierarchy,
            _ => throw new CourierInvalidDataException("Data did not match any variant of Content"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
