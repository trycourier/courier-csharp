using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<BulkJobStatus>))]
[Serializable]
public readonly record struct BulkJobStatus : IStringEnum
{
    public static readonly BulkJobStatus Created = new(Values.Created);

    public static readonly BulkJobStatus Processing = new(Values.Processing);

    public static readonly BulkJobStatus Completed = new(Values.Completed);

    public static readonly BulkJobStatus Error = new(Values.Error);

    public BulkJobStatus(string value)
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
    public static BulkJobStatus FromCustom(string value)
    {
        return new BulkJobStatus(value);
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

    public static bool operator ==(BulkJobStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BulkJobStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BulkJobStatus value) => value.Value;

    public static explicit operator BulkJobStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Created = "CREATED";

        public const string Processing = "PROCESSING";

        public const string Completed = "COMPLETED";

        public const string Error = "ERROR";
    }
}
