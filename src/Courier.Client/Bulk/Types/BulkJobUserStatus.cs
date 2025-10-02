using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<BulkJobUserStatus>))]
[Serializable]
public readonly record struct BulkJobUserStatus : IStringEnum
{
    public static readonly BulkJobUserStatus Pending = new(Values.Pending);

    public static readonly BulkJobUserStatus Enqueued = new(Values.Enqueued);

    public static readonly BulkJobUserStatus Error = new(Values.Error);

    public BulkJobUserStatus(string value)
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
    public static BulkJobUserStatus FromCustom(string value)
    {
        return new BulkJobUserStatus(value);
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

    public static bool operator ==(BulkJobUserStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BulkJobUserStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BulkJobUserStatus value) => value.Value;

    public static explicit operator BulkJobUserStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Pending = "PENDING";

        public const string Enqueued = "ENQUEUED";

        public const string Error = "ERROR";
    }
}
