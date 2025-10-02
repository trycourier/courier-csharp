using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<AutomationThrottleScope>))]
[Serializable]
public readonly record struct AutomationThrottleScope : IStringEnum
{
    public static readonly AutomationThrottleScope User = new(Values.User);

    public static readonly AutomationThrottleScope Global = new(Values.Global);

    public static readonly AutomationThrottleScope Dynamic = new(Values.Dynamic);

    public AutomationThrottleScope(string value)
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
    public static AutomationThrottleScope FromCustom(string value)
    {
        return new AutomationThrottleScope(value);
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

    public static bool operator ==(AutomationThrottleScope value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AutomationThrottleScope value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AutomationThrottleScope value) => value.Value;

    public static explicit operator AutomationThrottleScope(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string User = "user";

        public const string Global = "global";

        public const string Dynamic = "dynamic";
    }
}
