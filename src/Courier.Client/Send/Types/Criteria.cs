using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<Criteria>))]
[Serializable]
public readonly record struct Criteria : IStringEnum
{
    public static readonly Criteria NoEscalation = new(Values.NoEscalation);

    public static readonly Criteria Delivered = new(Values.Delivered);

    public static readonly Criteria Viewed = new(Values.Viewed);

    public static readonly Criteria Engaged = new(Values.Engaged);

    public Criteria(string value)
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
    public static Criteria FromCustom(string value)
    {
        return new Criteria(value);
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

    public static bool operator ==(Criteria value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Criteria value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(Criteria value) => value.Value;

    public static explicit operator Criteria(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string NoEscalation = "no-escalation";

        public const string Delivered = "delivered";

        public const string Viewed = "viewed";

        public const string Engaged = "engaged";
    }
}
