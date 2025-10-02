using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<WebhookMethod>))]
[Serializable]
public readonly record struct WebhookMethod : IStringEnum
{
    public static readonly WebhookMethod Post = new(Values.Post);

    public static readonly WebhookMethod Put = new(Values.Put);

    public WebhookMethod(string value)
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
    public static WebhookMethod FromCustom(string value)
    {
        return new WebhookMethod(value);
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

    public static bool operator ==(WebhookMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WebhookMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WebhookMethod value) => value.Value;

    public static explicit operator WebhookMethod(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Post = "POST";

        public const string Put = "PUT";
    }
}
