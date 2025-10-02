using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<AutomationAddToBatchRetainType>))]
[Serializable]
public readonly record struct AutomationAddToBatchRetainType : IStringEnum
{
    public static readonly AutomationAddToBatchRetainType First = new(Values.First);

    public static readonly AutomationAddToBatchRetainType Last = new(Values.Last);

    public static readonly AutomationAddToBatchRetainType Highest = new(Values.Highest);

    public static readonly AutomationAddToBatchRetainType Lowest = new(Values.Lowest);

    public AutomationAddToBatchRetainType(string value)
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
    public static AutomationAddToBatchRetainType FromCustom(string value)
    {
        return new AutomationAddToBatchRetainType(value);
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

    public static bool operator ==(AutomationAddToBatchRetainType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AutomationAddToBatchRetainType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AutomationAddToBatchRetainType value) => value.Value;

    public static explicit operator AutomationAddToBatchRetainType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string First = "first";

        public const string Last = "last";

        public const string Highest = "highest";

        public const string Lowest = "lowest";
    }
}
