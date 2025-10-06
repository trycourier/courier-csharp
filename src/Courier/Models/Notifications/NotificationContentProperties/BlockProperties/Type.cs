using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Notifications.NotificationContentProperties.BlockProperties;

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Action,
    Divider,
    Image,
    Jsonnet,
    List,
    Markdown,
    Quote,
    Template,
    Text,
}

sealed class TypeConverter : JsonConverter<Type>
{
    public override Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "action" => BlockProperties.Type.Action,
            "divider" => BlockProperties.Type.Divider,
            "image" => BlockProperties.Type.Image,
            "jsonnet" => BlockProperties.Type.Jsonnet,
            "list" => BlockProperties.Type.List,
            "markdown" => BlockProperties.Type.Markdown,
            "quote" => BlockProperties.Type.Quote,
            "template" => BlockProperties.Type.Template,
            "text" => BlockProperties.Type.Text,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BlockProperties.Type.Action => "action",
                BlockProperties.Type.Divider => "divider",
                BlockProperties.Type.Image => "image",
                BlockProperties.Type.Jsonnet => "jsonnet",
                BlockProperties.Type.List => "list",
                BlockProperties.Type.Markdown => "markdown",
                BlockProperties.Type.Quote => "quote",
                BlockProperties.Type.Template => "template",
                BlockProperties.Type.Text => "text",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
