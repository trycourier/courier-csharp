// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(ElementalNode.JsonConverter))]
[Serializable]
public record ElementalNode
{
    internal ElementalNode(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ElementalNode with <see cref="ElementalNode.Text"/>.
    /// </summary>
    public ElementalNode(ElementalNode.Text value)
    {
        Type = "text";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ElementalNode with <see cref="ElementalNode.Meta"/>.
    /// </summary>
    public ElementalNode(ElementalNode.Meta value)
    {
        Type = "meta";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ElementalNode with <see cref="ElementalNode.Channel"/>.
    /// </summary>
    public ElementalNode(ElementalNode.Channel value)
    {
        Type = "channel";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ElementalNode with <see cref="ElementalNode.Image"/>.
    /// </summary>
    public ElementalNode(ElementalNode.Image value)
    {
        Type = "image";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ElementalNode with <see cref="ElementalNode.Action"/>.
    /// </summary>
    public ElementalNode(ElementalNode.Action value)
    {
        Type = "action";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ElementalNode with <see cref="ElementalNode.Divider"/>.
    /// </summary>
    public ElementalNode(ElementalNode.Divider value)
    {
        Type = "divider";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ElementalNode with <see cref="ElementalNode.Group"/>.
    /// </summary>
    public ElementalNode(ElementalNode.Group value)
    {
        Type = "group";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ElementalNode with <see cref="ElementalNode.Quote"/>.
    /// </summary>
    public ElementalNode(ElementalNode.Quote value)
    {
        Type = "quote";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Type"/> is "text"
    /// </summary>
    public bool IsText => Type == "text";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "meta"
    /// </summary>
    public bool IsMeta => Type == "meta";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "channel"
    /// </summary>
    public bool IsChannel => Type == "channel";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "image"
    /// </summary>
    public bool IsImage => Type == "image";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "action"
    /// </summary>
    public bool IsAction => Type == "action";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "divider"
    /// </summary>
    public bool IsDivider => Type == "divider";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "group"
    /// </summary>
    public bool IsGroup => Type == "group";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "quote"
    /// </summary>
    public bool IsQuote => Type == "quote";

    /// <summary>
    /// Returns the value as a <see cref="Courier.Client.ElementalTextNode"/> if <see cref="Type"/> is 'text', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'text'.</exception>
    public Courier.Client.ElementalTextNode AsText() =>
        IsText
            ? (Courier.Client.ElementalTextNode)Value!
            : throw new Exception("ElementalNode.Type is not 'text'");

    /// <summary>
    /// Returns the value as a <see cref="Courier.Client.ElementalMetaNode"/> if <see cref="Type"/> is 'meta', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'meta'.</exception>
    public Courier.Client.ElementalMetaNode AsMeta() =>
        IsMeta
            ? (Courier.Client.ElementalMetaNode)Value!
            : throw new Exception("ElementalNode.Type is not 'meta'");

    /// <summary>
    /// Returns the value as a <see cref="Courier.Client.ElementalChannelNode"/> if <see cref="Type"/> is 'channel', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'channel'.</exception>
    public Courier.Client.ElementalChannelNode AsChannel() =>
        IsChannel
            ? (Courier.Client.ElementalChannelNode)Value!
            : throw new Exception("ElementalNode.Type is not 'channel'");

    /// <summary>
    /// Returns the value as a <see cref="Courier.Client.ElementalImageNode"/> if <see cref="Type"/> is 'image', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'image'.</exception>
    public Courier.Client.ElementalImageNode AsImage() =>
        IsImage
            ? (Courier.Client.ElementalImageNode)Value!
            : throw new Exception("ElementalNode.Type is not 'image'");

    /// <summary>
    /// Returns the value as a <see cref="Courier.Client.ElementalActionNode"/> if <see cref="Type"/> is 'action', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'action'.</exception>
    public Courier.Client.ElementalActionNode AsAction() =>
        IsAction
            ? (Courier.Client.ElementalActionNode)Value!
            : throw new Exception("ElementalNode.Type is not 'action'");

    /// <summary>
    /// Returns the value as a <see cref="Courier.Client.ElementalDividerNode"/> if <see cref="Type"/> is 'divider', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'divider'.</exception>
    public Courier.Client.ElementalDividerNode AsDivider() =>
        IsDivider
            ? (Courier.Client.ElementalDividerNode)Value!
            : throw new Exception("ElementalNode.Type is not 'divider'");

    /// <summary>
    /// Returns the value as a <see cref="Courier.Client.ElementalGroupNode"/> if <see cref="Type"/> is 'group', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'group'.</exception>
    public Courier.Client.ElementalGroupNode AsGroup() =>
        IsGroup
            ? (Courier.Client.ElementalGroupNode)Value!
            : throw new Exception("ElementalNode.Type is not 'group'");

    /// <summary>
    /// Returns the value as a <see cref="Courier.Client.ElementalQuoteNode"/> if <see cref="Type"/> is 'quote', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'quote'.</exception>
    public Courier.Client.ElementalQuoteNode AsQuote() =>
        IsQuote
            ? (Courier.Client.ElementalQuoteNode)Value!
            : throw new Exception("ElementalNode.Type is not 'quote'");

    public T Match<T>(
        Func<Courier.Client.ElementalTextNode, T> onText,
        Func<Courier.Client.ElementalMetaNode, T> onMeta,
        Func<Courier.Client.ElementalChannelNode, T> onChannel,
        Func<Courier.Client.ElementalImageNode, T> onImage,
        Func<Courier.Client.ElementalActionNode, T> onAction,
        Func<Courier.Client.ElementalDividerNode, T> onDivider,
        Func<Courier.Client.ElementalGroupNode, T> onGroup,
        Func<Courier.Client.ElementalQuoteNode, T> onQuote,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "text" => onText(AsText()),
            "meta" => onMeta(AsMeta()),
            "channel" => onChannel(AsChannel()),
            "image" => onImage(AsImage()),
            "action" => onAction(AsAction()),
            "divider" => onDivider(AsDivider()),
            "group" => onGroup(AsGroup()),
            "quote" => onQuote(AsQuote()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<Courier.Client.ElementalTextNode> onText,
        Action<Courier.Client.ElementalMetaNode> onMeta,
        Action<Courier.Client.ElementalChannelNode> onChannel,
        Action<Courier.Client.ElementalImageNode> onImage,
        Action<Courier.Client.ElementalActionNode> onAction,
        Action<Courier.Client.ElementalDividerNode> onDivider,
        Action<Courier.Client.ElementalGroupNode> onGroup,
        Action<Courier.Client.ElementalQuoteNode> onQuote,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "text":
                onText(AsText());
                break;
            case "meta":
                onMeta(AsMeta());
                break;
            case "channel":
                onChannel(AsChannel());
                break;
            case "image":
                onImage(AsImage());
                break;
            case "action":
                onAction(AsAction());
                break;
            case "divider":
                onDivider(AsDivider());
                break;
            case "group":
                onGroup(AsGroup());
                break;
            case "quote":
                onQuote(AsQuote());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Courier.Client.ElementalTextNode"/> and returns true if successful.
    /// </summary>
    public bool TryAsText(out Courier.Client.ElementalTextNode? value)
    {
        if (Type == "text")
        {
            value = (Courier.Client.ElementalTextNode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Courier.Client.ElementalMetaNode"/> and returns true if successful.
    /// </summary>
    public bool TryAsMeta(out Courier.Client.ElementalMetaNode? value)
    {
        if (Type == "meta")
        {
            value = (Courier.Client.ElementalMetaNode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Courier.Client.ElementalChannelNode"/> and returns true if successful.
    /// </summary>
    public bool TryAsChannel(out Courier.Client.ElementalChannelNode? value)
    {
        if (Type == "channel")
        {
            value = (Courier.Client.ElementalChannelNode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Courier.Client.ElementalImageNode"/> and returns true if successful.
    /// </summary>
    public bool TryAsImage(out Courier.Client.ElementalImageNode? value)
    {
        if (Type == "image")
        {
            value = (Courier.Client.ElementalImageNode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Courier.Client.ElementalActionNode"/> and returns true if successful.
    /// </summary>
    public bool TryAsAction(out Courier.Client.ElementalActionNode? value)
    {
        if (Type == "action")
        {
            value = (Courier.Client.ElementalActionNode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Courier.Client.ElementalDividerNode"/> and returns true if successful.
    /// </summary>
    public bool TryAsDivider(out Courier.Client.ElementalDividerNode? value)
    {
        if (Type == "divider")
        {
            value = (Courier.Client.ElementalDividerNode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Courier.Client.ElementalGroupNode"/> and returns true if successful.
    /// </summary>
    public bool TryAsGroup(out Courier.Client.ElementalGroupNode? value)
    {
        if (Type == "group")
        {
            value = (Courier.Client.ElementalGroupNode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Courier.Client.ElementalQuoteNode"/> and returns true if successful.
    /// </summary>
    public bool TryAsQuote(out Courier.Client.ElementalQuoteNode? value)
    {
        if (Type == "quote")
        {
            value = (Courier.Client.ElementalQuoteNode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ElementalNode(ElementalNode.Text value) => new(value);

    public static implicit operator ElementalNode(ElementalNode.Meta value) => new(value);

    public static implicit operator ElementalNode(ElementalNode.Channel value) => new(value);

    public static implicit operator ElementalNode(ElementalNode.Image value) => new(value);

    public static implicit operator ElementalNode(ElementalNode.Action value) => new(value);

    public static implicit operator ElementalNode(ElementalNode.Divider value) => new(value);

    public static implicit operator ElementalNode(ElementalNode.Group value) => new(value);

    public static implicit operator ElementalNode(ElementalNode.Quote value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ElementalNode>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ElementalNode).IsAssignableFrom(typeToConvert);

        public override ElementalNode Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("type", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'type'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'type' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'type' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'type' is null");

            var value = discriminator switch
            {
                "text" => json.Deserialize<Courier.Client.ElementalTextNode>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Courier.Client.ElementalTextNode"
                    ),
                "meta" => json.Deserialize<Courier.Client.ElementalMetaNode>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Courier.Client.ElementalMetaNode"
                    ),
                "channel" => json.Deserialize<Courier.Client.ElementalChannelNode>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Courier.Client.ElementalChannelNode"
                    ),
                "image" => json.Deserialize<Courier.Client.ElementalImageNode>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Courier.Client.ElementalImageNode"
                    ),
                "action" => json.Deserialize<Courier.Client.ElementalActionNode>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Courier.Client.ElementalActionNode"
                    ),
                "divider" => json.Deserialize<Courier.Client.ElementalDividerNode>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Courier.Client.ElementalDividerNode"
                    ),
                "group" => json.Deserialize<Courier.Client.ElementalGroupNode>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Courier.Client.ElementalGroupNode"
                    ),
                "quote" => json.Deserialize<Courier.Client.ElementalQuoteNode>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize Courier.Client.ElementalQuoteNode"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new ElementalNode(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ElementalNode value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "text" => JsonSerializer.SerializeToNode(value.Value, options),
                    "meta" => JsonSerializer.SerializeToNode(value.Value, options),
                    "channel" => JsonSerializer.SerializeToNode(value.Value, options),
                    "image" => JsonSerializer.SerializeToNode(value.Value, options),
                    "action" => JsonSerializer.SerializeToNode(value.Value, options),
                    "divider" => JsonSerializer.SerializeToNode(value.Value, options),
                    "group" => JsonSerializer.SerializeToNode(value.Value, options),
                    "quote" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for text
    /// </summary>
    [Serializable]
    public struct Text
    {
        public Text(Courier.Client.ElementalTextNode value)
        {
            Value = value;
        }

        internal Courier.Client.ElementalTextNode Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator ElementalNode.Text(
            Courier.Client.ElementalTextNode value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for meta
    /// </summary>
    [Serializable]
    public struct Meta
    {
        public Meta(Courier.Client.ElementalMetaNode value)
        {
            Value = value;
        }

        internal Courier.Client.ElementalMetaNode Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator ElementalNode.Meta(
            Courier.Client.ElementalMetaNode value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for channel
    /// </summary>
    [Serializable]
    public struct Channel
    {
        public Channel(Courier.Client.ElementalChannelNode value)
        {
            Value = value;
        }

        internal Courier.Client.ElementalChannelNode Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator ElementalNode.Channel(
            Courier.Client.ElementalChannelNode value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for image
    /// </summary>
    [Serializable]
    public struct Image
    {
        public Image(Courier.Client.ElementalImageNode value)
        {
            Value = value;
        }

        internal Courier.Client.ElementalImageNode Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator ElementalNode.Image(
            Courier.Client.ElementalImageNode value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for action
    /// </summary>
    [Serializable]
    public struct Action
    {
        public Action(Courier.Client.ElementalActionNode value)
        {
            Value = value;
        }

        internal Courier.Client.ElementalActionNode Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator ElementalNode.Action(
            Courier.Client.ElementalActionNode value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for divider
    /// </summary>
    [Serializable]
    public struct Divider
    {
        public Divider(Courier.Client.ElementalDividerNode value)
        {
            Value = value;
        }

        internal Courier.Client.ElementalDividerNode Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator ElementalNode.Divider(
            Courier.Client.ElementalDividerNode value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for group
    /// </summary>
    [Serializable]
    public struct Group
    {
        public Group(Courier.Client.ElementalGroupNode value)
        {
            Value = value;
        }

        internal Courier.Client.ElementalGroupNode Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator ElementalNode.Group(
            Courier.Client.ElementalGroupNode value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for quote
    /// </summary>
    [Serializable]
    public struct Quote
    {
        public Quote(Courier.Client.ElementalQuoteNode value)
        {
            Value = value;
        }

        internal Courier.Client.ElementalQuoteNode Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator ElementalNode.Quote(
            Courier.Client.ElementalQuoteNode value
        ) => new(value);
    }
}
