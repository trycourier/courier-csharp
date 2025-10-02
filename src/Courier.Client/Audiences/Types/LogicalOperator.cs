using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<LogicalOperator>))]
[Serializable]
public readonly record struct LogicalOperator : IStringEnum
{
    public static readonly LogicalOperator And = new(Values.And);

    public static readonly LogicalOperator Or = new(Values.Or);

    public LogicalOperator(string value)
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
    public static LogicalOperator FromCustom(string value)
    {
        return new LogicalOperator(value);
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

    public static bool operator ==(LogicalOperator value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LogicalOperator value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LogicalOperator value) => value.Value;

    public static explicit operator LogicalOperator(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string And = "AND";

        public const string Or = "OR";
    }
}
