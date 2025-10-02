using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<TextAlign>))]
[Serializable]
public readonly record struct TextAlign : IStringEnum
{
    public static readonly TextAlign Left = new(Values.Left);

    public static readonly TextAlign Center = new(Values.Center);

    public static readonly TextAlign Right = new(Values.Right);

    public TextAlign(string value)
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
    public static TextAlign FromCustom(string value)
    {
        return new TextAlign(value);
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

    public static bool operator ==(TextAlign value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(TextAlign value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(TextAlign value) => value.Value;

    public static explicit operator TextAlign(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Left = "left";

        public const string Center = "center";

        public const string Right = "right";
    }
}
