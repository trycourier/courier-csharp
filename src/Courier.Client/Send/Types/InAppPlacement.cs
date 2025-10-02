using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<InAppPlacement>))]
[Serializable]
public readonly record struct InAppPlacement : IStringEnum
{
    public static readonly InAppPlacement Top = new(Values.Top);

    public static readonly InAppPlacement Bottom = new(Values.Bottom);

    public static readonly InAppPlacement Left = new(Values.Left);

    public static readonly InAppPlacement Right = new(Values.Right);

    public InAppPlacement(string value)
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
    public static InAppPlacement FromCustom(string value)
    {
        return new InAppPlacement(value);
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

    public static bool operator ==(InAppPlacement value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InAppPlacement value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InAppPlacement value) => value.Value;

    public static explicit operator InAppPlacement(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Top = "top";

        public const string Bottom = "bottom";

        public const string Left = "left";

        public const string Right = "right";
    }
}
