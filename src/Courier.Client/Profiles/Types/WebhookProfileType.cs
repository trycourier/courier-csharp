using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<WebhookProfileType>))]
[Serializable]
public readonly record struct WebhookProfileType : IStringEnum
{
    public static readonly WebhookProfileType Limited = new(Values.Limited);

    public static readonly WebhookProfileType Expanded = new(Values.Expanded);

    public WebhookProfileType(string value)
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
    public static WebhookProfileType FromCustom(string value)
    {
        return new WebhookProfileType(value);
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

    public static bool operator ==(WebhookProfileType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WebhookProfileType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WebhookProfileType value) => value.Value;

    public static explicit operator WebhookProfileType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Limited = "limited";

        public const string Expanded = "expanded";
    }
}
