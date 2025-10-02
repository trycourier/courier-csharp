using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client.Users;

[JsonConverter(typeof(StringEnumSerializer<TokenStatus>))]
[Serializable]
public readonly record struct TokenStatus : IStringEnum
{
    public static readonly TokenStatus Active = new(Values.Active);

    public static readonly TokenStatus Unknown = new(Values.Unknown);

    public static readonly TokenStatus Failed = new(Values.Failed);

    public static readonly TokenStatus Revoked = new(Values.Revoked);

    public TokenStatus(string value)
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
    public static TokenStatus FromCustom(string value)
    {
        return new TokenStatus(value);
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

    public static bool operator ==(TokenStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TokenStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TokenStatus value) => value.Value;

    public static explicit operator TokenStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Active = "active";

        public const string Unknown = "unknown";

        public const string Failed = "failed";

        public const string Revoked = "revoked";
    }
}
