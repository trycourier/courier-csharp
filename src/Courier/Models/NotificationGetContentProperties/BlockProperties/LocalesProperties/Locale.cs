using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.NotificationGetContentProperties.BlockProperties.LocalesProperties.LocaleProperties;
using System = System;

namespace Courier.Models.NotificationGetContentProperties.BlockProperties.LocalesProperties;

[JsonConverter(typeof(LocaleConverter))]
public record class Locale
{
    public object Value { get; private init; }

    public Locale(string value)
    {
        Value = value;
    }

    public Locale(NotificationContentHierarchy value)
    {
        Value = value;
    }

    Locale(UnknownVariant value)
    {
        Value = value;
    }

    public static Locale CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickNotificationContentHierarchy(
        [NotNullWhen(true)] out NotificationContentHierarchy? value
    )
    {
        value = this.Value as NotificationContentHierarchy;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<NotificationContentHierarchy> notificationContentHierarchy
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case NotificationContentHierarchy value:
                notificationContentHierarchy(value);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of Locale");
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<NotificationContentHierarchy, T> notificationContentHierarchy
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            NotificationContentHierarchy value => notificationContentHierarchy(value),
            _ => throw new CourierInvalidDataException("Data did not match any variant of Locale"),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new CourierInvalidDataException("Data did not match any variant of Locale");
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
                deserialized.Validate();
                return new Locale(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'NotificationContentHierarchy'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new Locale(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException("Data does not match union variant 'string'", e)
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Locale value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
