using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<IActionButtonStyle>))]
[Serializable]
public readonly record struct IActionButtonStyle : IStringEnum
{
    public static readonly IActionButtonStyle Button = new(Values.Button);

    public static readonly IActionButtonStyle Link = new(Values.Link);

    public IActionButtonStyle(string value)
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
    public static IActionButtonStyle FromCustom(string value)
    {
        return new IActionButtonStyle(value);
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

    public static bool operator ==(IActionButtonStyle value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IActionButtonStyle value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IActionButtonStyle value) => value.Value;

    public static explicit operator IActionButtonStyle(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Button = "button";

        public const string Link = "link";
    }
}
