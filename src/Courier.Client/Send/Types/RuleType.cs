using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<RuleType>))]
[Serializable]
public readonly record struct RuleType : IStringEnum
{
    public static readonly RuleType Snooze = new(Values.Snooze);

    public static readonly RuleType ChannelPreferences = new(Values.ChannelPreferences);

    public static readonly RuleType Status = new(Values.Status);

    public RuleType(string value)
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
    public static RuleType FromCustom(string value)
    {
        return new RuleType(value);
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

    public static bool operator ==(RuleType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(RuleType value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(RuleType value) => value.Value;

    public static explicit operator RuleType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Snooze = "snooze";

        public const string ChannelPreferences = "channel_preferences";

        public const string Status = "status";
    }
}
