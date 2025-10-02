using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<WebhookAuthMode>))]
[Serializable]
public readonly record struct WebhookAuthMode : IStringEnum
{
    public static readonly WebhookAuthMode None = new(Values.None);

    public static readonly WebhookAuthMode Basic = new(Values.Basic);

    public static readonly WebhookAuthMode Bearer = new(Values.Bearer);

    public WebhookAuthMode(string value)
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
    public static WebhookAuthMode FromCustom(string value)
    {
        return new WebhookAuthMode(value);
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

    public static bool operator ==(WebhookAuthMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WebhookAuthMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WebhookAuthMode value) => value.Value;

    public static explicit operator WebhookAuthMode(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string None = "none";

        public const string Basic = "basic";

        public const string Bearer = "bearer";
    }
}
