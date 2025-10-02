using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<ChannelSource>))]
[Serializable]
public readonly record struct ChannelSource : IStringEnum
{
    public static readonly ChannelSource Subscription = new(Values.Subscription);

    public static readonly ChannelSource List = new(Values.List);

    public static readonly ChannelSource Recipient = new(Values.Recipient);

    public ChannelSource(string value)
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
    public static ChannelSource FromCustom(string value)
    {
        return new ChannelSource(value);
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

    public static bool operator ==(ChannelSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ChannelSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ChannelSource value) => value.Value;

    public static explicit operator ChannelSource(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Subscription = "subscription";

        public const string List = "list";

        public const string Recipient = "recipient";
    }
}
