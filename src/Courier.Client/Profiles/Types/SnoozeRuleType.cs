using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<SnoozeRuleType>))]
[Serializable]
public readonly record struct SnoozeRuleType : IStringEnum
{
    public static readonly SnoozeRuleType Snooze = new(Values.Snooze);

    public SnoozeRuleType(string value)
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
    public static SnoozeRuleType FromCustom(string value)
    {
        return new SnoozeRuleType(value);
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

    public static bool operator ==(SnoozeRuleType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SnoozeRuleType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SnoozeRuleType value) => value.Value;

    public static explicit operator SnoozeRuleType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Snooze = "snooze";
    }
}
