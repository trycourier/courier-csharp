using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<ComparisonOperator>))]
[Serializable]
public readonly record struct ComparisonOperator : IStringEnum
{
    public static readonly ComparisonOperator EndsWith = new(Values.EndsWith);

    public static readonly ComparisonOperator Eq = new(Values.Eq);

    public static readonly ComparisonOperator Exists = new(Values.Exists);

    public static readonly ComparisonOperator Gt = new(Values.Gt);

    public static readonly ComparisonOperator Gte = new(Values.Gte);

    public static readonly ComparisonOperator Includes = new(Values.Includes);

    public static readonly ComparisonOperator IsAfter = new(Values.IsAfter);

    public static readonly ComparisonOperator IsBefore = new(Values.IsBefore);

    public static readonly ComparisonOperator Lt = new(Values.Lt);

    public static readonly ComparisonOperator Lte = new(Values.Lte);

    public static readonly ComparisonOperator Neq = new(Values.Neq);

    public static readonly ComparisonOperator Omit = new(Values.Omit);

    public static readonly ComparisonOperator StartsWith = new(Values.StartsWith);

    public ComparisonOperator(string value)
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
    public static ComparisonOperator FromCustom(string value)
    {
        return new ComparisonOperator(value);
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

    public static bool operator ==(ComparisonOperator value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ComparisonOperator value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ComparisonOperator value) => value.Value;

    public static explicit operator ComparisonOperator(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string EndsWith = "ENDS_WITH";

        public const string Eq = "EQ";

        public const string Exists = "EXISTS";

        public const string Gt = "GT";

        public const string Gte = "GTE";

        public const string Includes = "INCLUDES";

        public const string IsAfter = "IS_AFTER";

        public const string IsBefore = "IS_BEFORE";

        public const string Lt = "LT";

        public const string Lte = "LTE";

        public const string Neq = "NEQ";

        public const string Omit = "OMIT";

        public const string StartsWith = "STARTS_WITH";
    }
}
