using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<RoutingMethod>))]
[Serializable]
public readonly record struct RoutingMethod : IStringEnum
{
    public static readonly RoutingMethod All = new(Values.All);

    public static readonly RoutingMethod Single = new(Values.Single);

    public RoutingMethod(string value)
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
    public static RoutingMethod FromCustom(string value)
    {
        return new RoutingMethod(value);
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

    public static bool operator ==(RoutingMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RoutingMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RoutingMethod value) => value.Value;

    public static explicit operator RoutingMethod(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string All = "all";

        public const string Single = "single";
    }
}
