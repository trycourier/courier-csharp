using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<BlockType>))]
[Serializable]
public readonly record struct BlockType : IStringEnum
{
    public static readonly BlockType Action = new(Values.Action);

    public static readonly BlockType Divider = new(Values.Divider);

    public static readonly BlockType Image = new(Values.Image);

    public static readonly BlockType Jsonnet = new(Values.Jsonnet);

    public static readonly BlockType List = new(Values.List);

    public static readonly BlockType Markdown = new(Values.Markdown);

    public static readonly BlockType Quote = new(Values.Quote);

    public static readonly BlockType Template = new(Values.Template);

    public static readonly BlockType Text = new(Values.Text);

    public BlockType(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static BlockType FromCustom(string value)
    {
        return new BlockType(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(BlockType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(BlockType value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(BlockType value) => value.Value;

    public static explicit operator BlockType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Action = "action";

        public const string Divider = "divider";

        public const string Image = "image";

        public const string Jsonnet = "jsonnet";

        public const string List = "list";

        public const string Markdown = "markdown";

        public const string Quote = "quote";

        public const string Template = "template";

        public const string Text = "text";
    }
}
