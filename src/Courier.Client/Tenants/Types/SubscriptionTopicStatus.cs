using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<SubscriptionTopicStatus>))]
[Serializable]
public readonly record struct SubscriptionTopicStatus : IStringEnum
{
    public static readonly SubscriptionTopicStatus OptedOut = new(Values.OptedOut);

    public static readonly SubscriptionTopicStatus OptedIn = new(Values.OptedIn);

    public static readonly SubscriptionTopicStatus Required = new(Values.Required);

    public SubscriptionTopicStatus(string value)
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
    public static SubscriptionTopicStatus FromCustom(string value)
    {
        return new SubscriptionTopicStatus(value);
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

    public static bool operator ==(SubscriptionTopicStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubscriptionTopicStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubscriptionTopicStatus value) => value.Value;

    public static explicit operator SubscriptionTopicStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string OptedOut = "OPTED_OUT";

        public const string OptedIn = "OPTED_IN";

        public const string Required = "REQUIRED";
    }
}
