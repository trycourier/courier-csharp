using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<IAlignment>))]
[Serializable]
public readonly record struct IAlignment : IStringEnum
{
    public static readonly IAlignment Center = new(Values.Center);

    public static readonly IAlignment Left = new(Values.Left);

    public static readonly IAlignment Right = new(Values.Right);

    public static readonly IAlignment Full = new(Values.Full);

    public IAlignment(string value)
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
    public static IAlignment FromCustom(string value)
    {
        return new IAlignment(value);
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

    public static bool operator ==(IAlignment value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(IAlignment value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IAlignment value) => value.Value;

    public static explicit operator IAlignment(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Center = "center";

        public const string Left = "left";

        public const string Right = "right";

        public const string Full = "full";
    }
}
