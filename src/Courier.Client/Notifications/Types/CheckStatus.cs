using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<CheckStatus>))]
[Serializable]
public readonly record struct CheckStatus : IStringEnum
{
    public static readonly CheckStatus Resolved = new(Values.Resolved);

    public static readonly CheckStatus Failed = new(Values.Failed);

    public static readonly CheckStatus Pending = new(Values.Pending);

    public CheckStatus(string value)
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
    public static CheckStatus FromCustom(string value)
    {
        return new CheckStatus(value);
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

    public static bool operator ==(CheckStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CheckStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CheckStatus value) => value.Value;

    public static explicit operator CheckStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Resolved = "RESOLVED";

        public const string Failed = "FAILED";

        public const string Pending = "PENDING";
    }
}
