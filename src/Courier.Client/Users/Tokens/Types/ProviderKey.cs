using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client.Users;

[JsonConverter(typeof(StringEnumSerializer<ProviderKey>))]
[Serializable]
public readonly record struct ProviderKey : IStringEnum
{
    public static readonly ProviderKey FirebaseFcm = new(Values.FirebaseFcm);

    public static readonly ProviderKey Apn = new(Values.Apn);

    public static readonly ProviderKey Expo = new(Values.Expo);

    public static readonly ProviderKey Onesignal = new(Values.Onesignal);

    public ProviderKey(string value)
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
    public static ProviderKey FromCustom(string value)
    {
        return new ProviderKey(value);
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

    public static bool operator ==(ProviderKey value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProviderKey value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProviderKey value) => value.Value;

    public static explicit operator ProviderKey(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string FirebaseFcm = "firebase-fcm";

        public const string Apn = "apn";

        public const string Expo = "expo";

        public const string Onesignal = "onesignal";
    }
}
