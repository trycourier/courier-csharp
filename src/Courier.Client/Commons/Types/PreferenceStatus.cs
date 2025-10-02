using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<PreferenceStatus>))]
[Serializable]
public readonly record struct PreferenceStatus : IStringEnum
{
    public static readonly PreferenceStatus OptedIn = new(Values.OptedIn);

    public static readonly PreferenceStatus OptedOut = new(Values.OptedOut);

    public static readonly PreferenceStatus Required = new(Values.Required);

    public PreferenceStatus(string value)
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
    public static PreferenceStatus FromCustom(string value)
    {
        return new PreferenceStatus(value);
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

    public static bool operator ==(PreferenceStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PreferenceStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PreferenceStatus value) => value.Value;

    public static explicit operator PreferenceStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string OptedIn = "OPTED_IN";

        public const string OptedOut = "OPTED_OUT";

        public const string Required = "REQUIRED";
    }
}
