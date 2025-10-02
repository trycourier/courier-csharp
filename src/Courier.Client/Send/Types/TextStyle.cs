using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<TextStyle>))]
[Serializable]
public readonly record struct TextStyle : IStringEnum
{
    public static readonly TextStyle Text = new(Values.Text);

    public static readonly TextStyle H1 = new(Values.H1);

    public static readonly TextStyle H2 = new(Values.H2);

    public static readonly TextStyle Subtext = new(Values.Subtext);

    public TextStyle(string value)
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
    public static TextStyle FromCustom(string value)
    {
        return new TextStyle(value);
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

    public static bool operator ==(TextStyle value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(TextStyle value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(TextStyle value) => value.Value;

    public static explicit operator TextStyle(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Text = "text";

        public const string H1 = "h1";

        public const string H2 = "h2";

        public const string Subtext = "subtext";
    }
}
