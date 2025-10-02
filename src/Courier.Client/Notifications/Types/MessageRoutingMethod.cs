using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<MessageRoutingMethod>))]
[Serializable]
public readonly record struct MessageRoutingMethod : IStringEnum
{
    public static readonly MessageRoutingMethod All = new(Values.All);

    public static readonly MessageRoutingMethod Single = new(Values.Single);

    public MessageRoutingMethod(string value)
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
    public static MessageRoutingMethod FromCustom(string value)
    {
        return new MessageRoutingMethod(value);
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

    public static bool operator ==(MessageRoutingMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MessageRoutingMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MessageRoutingMethod value) => value.Value;

    public static explicit operator MessageRoutingMethod(string value) => new(value);

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
