using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<AutomationAddToBatchScope>))]
[Serializable]
public readonly record struct AutomationAddToBatchScope : IStringEnum
{
    public static readonly AutomationAddToBatchScope User = new(Values.User);

    public static readonly AutomationAddToBatchScope Global = new(Values.Global);

    public static readonly AutomationAddToBatchScope Dynamic = new(Values.Dynamic);

    public AutomationAddToBatchScope(string value)
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
    public static AutomationAddToBatchScope FromCustom(string value)
    {
        return new AutomationAddToBatchScope(value);
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

    public static bool operator ==(AutomationAddToBatchScope value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AutomationAddToBatchScope value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AutomationAddToBatchScope value) => value.Value;

    public static explicit operator AutomationAddToBatchScope(string value) => new(value);

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
