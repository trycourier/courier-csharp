using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<ChannelClassification>))]
[Serializable]
public readonly record struct ChannelClassification : IStringEnum
{
    public static readonly ChannelClassification DirectMessage = new(Values.DirectMessage);

    public static readonly ChannelClassification Email = new(Values.Email);

    public static readonly ChannelClassification Push = new(Values.Push);

    public static readonly ChannelClassification Sms = new(Values.Sms);

    public static readonly ChannelClassification Webhook = new(Values.Webhook);

    public static readonly ChannelClassification Inbox = new(Values.Inbox);

    public ChannelClassification(string value)
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
    public static ChannelClassification FromCustom(string value)
    {
        return new ChannelClassification(value);
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

    public static bool operator ==(ChannelClassification value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ChannelClassification value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ChannelClassification value) => value.Value;

    public static explicit operator ChannelClassification(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string DirectMessage = "direct_message";

        public const string Email = "email";

        public const string Push = "push";

        public const string Sms = "sms";

        public const string Webhook = "webhook";

        public const string Inbox = "inbox";
    }
}
