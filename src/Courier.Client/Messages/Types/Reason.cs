using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<Reason>))]
[Serializable]
public readonly record struct Reason : IStringEnum
{
    /// <summary>
    /// The message bounced and was not delivered.
    /// </summary>
    public static readonly Reason Bounced = new(Values.Bounced);

    /// <summary>
    /// The message failed to be delivered.
    /// </summary>
    public static readonly Reason Failed = new(Values.Failed);

    /// <summary>
    /// The recipient did not receive the notification because of a condition that passed.
    /// </summary>
    public static readonly Reason Filtered = new(Values.Filtered);

    /// <summary>
    /// The notification did not contain any valid channels.
    /// </summary>
    public static readonly Reason NoChannels = new(Values.NoChannels);

    /// <summary>
    /// The notification did not contain a configured provider for a channel.
    /// </summary>
    public static readonly Reason NoProviders = new(Values.NoProviders);

    /// <summary>
    /// The recipient has not opted in to receive this type of notification.
    /// </summary>
    public static readonly Reason OptInRequired = new(Values.OptInRequired);

    /// <summary>
    /// The Integration provider had an error when sending a notification.
    /// </summary>
    public static readonly Reason ProviderError = new(Values.ProviderError);

    /// <summary>
    /// The notification hasn't been published yet.
    /// </summary>
    public static readonly Reason Unpublished = new(Values.Unpublished);

    /// <summary>
    /// The recipient did not receive the notification because they chose to unsubscribe from it.
    /// </summary>
    public static readonly Reason Unsubscribed = new(Values.Unsubscribed);

    public Reason(string value)
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
    public static Reason FromCustom(string value)
    {
        return new Reason(value);
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

    public static bool operator ==(Reason value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Reason value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(Reason value) => value.Value;

    public static explicit operator Reason(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        /// <summary>
        /// The message bounced and was not delivered.
        /// </summary>
        public const string Bounced = "BOUNCED";

        /// <summary>
        /// The message failed to be delivered.
        /// </summary>
        public const string Failed = "FAILED";

        /// <summary>
        /// The recipient did not receive the notification because of a condition that passed.
        /// </summary>
        public const string Filtered = "FILTERED";

        /// <summary>
        /// The notification did not contain any valid channels.
        /// </summary>
        public const string NoChannels = "NO_CHANNELS";

        /// <summary>
        /// The notification did not contain a configured provider for a channel.
        /// </summary>
        public const string NoProviders = "NO_PROVIDERS";

        /// <summary>
        /// The recipient has not opted in to receive this type of notification.
        /// </summary>
        public const string OptInRequired = "OPT_IN_REQUIRED";

        /// <summary>
        /// The Integration provider had an error when sending a notification.
        /// </summary>
        public const string ProviderError = "PROVIDER_ERROR";

        /// <summary>
        /// The notification hasn't been published yet.
        /// </summary>
        public const string Unpublished = "UNPUBLISHED";

        /// <summary>
        /// The recipient did not receive the notification because they chose to unsubscribe from it.
        /// </summary>
        public const string Unsubscribed = "UNSUBSCRIBED";
    }
}
