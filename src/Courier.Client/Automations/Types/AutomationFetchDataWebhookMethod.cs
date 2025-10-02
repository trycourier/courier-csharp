using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<AutomationFetchDataWebhookMethod>))]
[Serializable]
public readonly record struct AutomationFetchDataWebhookMethod : IStringEnum
{
    public static readonly AutomationFetchDataWebhookMethod Get = new(Values.Get);

    public static readonly AutomationFetchDataWebhookMethod Post = new(Values.Post);

    public AutomationFetchDataWebhookMethod(string value)
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
    public static AutomationFetchDataWebhookMethod FromCustom(string value)
    {
        return new AutomationFetchDataWebhookMethod(value);
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

    public static bool operator ==(AutomationFetchDataWebhookMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AutomationFetchDataWebhookMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AutomationFetchDataWebhookMethod value) => value.Value;

    public static explicit operator AutomationFetchDataWebhookMethod(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Get = "GET";

        public const string Post = "POST";
    }
}
