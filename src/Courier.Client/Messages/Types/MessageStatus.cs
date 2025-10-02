using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<MessageStatus>))]
[Serializable]
public readonly record struct MessageStatus : IStringEnum
{
    /// <summary>
    /// The message has been canceled such that it will not be delivered.
    /// </summary>
    public static readonly MessageStatus Canceled = new(Values.Canceled);

    /// <summary>
    /// The recipient has clicked on any link in the message at least one time.
    /// </summary>
    public static readonly MessageStatus Clicked = new(Values.Clicked);

    /// <summary>
    /// The message has been delayed and will be attempted for delivery at a later time.
    /// </summary>
    public static readonly MessageStatus Delayed = new(Values.Delayed);

    /// <summary>
    /// The provider successfully delivered the message to the recipient.
    /// </summary>
    public static readonly MessageStatus Delivered = new(Values.Delivered);

    /// <summary>
    /// The message has been aggregated into a digest and will be sent according to digest rules.
    /// </summary>
    public static readonly MessageStatus Digested = new(Values.Digested);

    /// <summary>
    /// The request has been received to send a message, is waiting in the work queue.
    /// </summary>
    public static readonly MessageStatus Enqueued = new(Values.Enqueued);

    /// <summary>
    /// The message was filtered out based on configured rules or preferences.
    /// </summary>
    public static readonly MessageStatus Filtered = new(Values.Filtered);

    /// <summary>
    /// The recipient has opened the message at least one time.
    /// </summary>
    public static readonly MessageStatus Opened = new(Values.Opened);

    /// <summary>
    /// The message has been successfully routed to a specific channel or provider.
    /// </summary>
    public static readonly MessageStatus Routed = new(Values.Routed);

    /// <summary>
    /// The message has been accepted by the provider.
    /// </summary>
    public static readonly MessageStatus Sent = new(Values.Sent);

    /// <summary>
    /// The message was sent with a mock key and Courier simulated the message lifecycle without sending to the downstream provider.
    /// </summary>
    public static readonly MessageStatus Simulated = new(Values.Simulated);

    /// <summary>
    /// The message was throttled by Courier.
    /// </summary>
    public static readonly MessageStatus Throttled = new(Values.Throttled);

    /// <summary>
    /// The message could not be delivered to at least one provider, or the provider could not deliver the message to the recipient. This can happen for multiple reasons: an error, insufficient profile data, invalid notification setup, invalid integration configuration, etc.
    /// </summary>
    public static readonly MessageStatus Undeliverable = new(Values.Undeliverable);

    /// <summary>
    /// Could not find a corresponding notification or event for the messages.
    /// </summary>
    public static readonly MessageStatus Unmapped = new(Values.Unmapped);

    /// <summary>
    /// The message could not be routed to any channel or provider. This can happen for multiple reasons: insufficient profile data, invalid notification setup, invalid integration configuration, etc.
    /// </summary>
    public static readonly MessageStatus Unroutable = new(Values.Unroutable);

    public MessageStatus(string value)
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
    public static MessageStatus FromCustom(string value)
    {
        return new MessageStatus(value);
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

    public static bool operator ==(MessageStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MessageStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MessageStatus value) => value.Value;

    public static explicit operator MessageStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        /// <summary>
        /// The message has been canceled such that it will not be delivered.
        /// </summary>
        public const string Canceled = "CANCELED";

        /// <summary>
        /// The recipient has clicked on any link in the message at least one time.
        /// </summary>
        public const string Clicked = "CLICKED";

        /// <summary>
        /// The message has been delayed and will be attempted for delivery at a later time.
        /// </summary>
        public const string Delayed = "DELAYED";

        /// <summary>
        /// The provider successfully delivered the message to the recipient.
        /// </summary>
        public const string Delivered = "DELIVERED";

        /// <summary>
        /// The message has been aggregated into a digest and will be sent according to digest rules.
        /// </summary>
        public const string Digested = "DIGESTED";

        /// <summary>
        /// The request has been received to send a message, is waiting in the work queue.
        /// </summary>
        public const string Enqueued = "ENQUEUED";

        /// <summary>
        /// The message was filtered out based on configured rules or preferences.
        /// </summary>
        public const string Filtered = "FILTERED";

        /// <summary>
        /// The recipient has opened the message at least one time.
        /// </summary>
        public const string Opened = "OPENED";

        /// <summary>
        /// The message has been successfully routed to a specific channel or provider.
        /// </summary>
        public const string Routed = "ROUTED";

        /// <summary>
        /// The message has been accepted by the provider.
        /// </summary>
        public const string Sent = "SENT";

        /// <summary>
        /// The message was sent with a mock key and Courier simulated the message lifecycle without sending to the downstream provider.
        /// </summary>
        public const string Simulated = "SIMULATED";

        /// <summary>
        /// The message was throttled by Courier.
        /// </summary>
        public const string Throttled = "THROTTLED";

        /// <summary>
        /// The message could not be delivered to at least one provider, or the provider could not deliver the message to the recipient. This can happen for multiple reasons: an error, insufficient profile data, invalid notification setup, invalid integration configuration, etc.
        /// </summary>
        public const string Undeliverable = "UNDELIVERABLE";

        /// <summary>
        /// Could not find a corresponding notification or event for the messages.
        /// </summary>
        public const string Unmapped = "UNMAPPED";

        /// <summary>
        /// The message could not be routed to any channel or provider. This can happen for multiple reasons: insufficient profile data, invalid notification setup, invalid integration configuration, etc.
        /// </summary>
        public const string Unroutable = "UNROUTABLE";
    }
}
