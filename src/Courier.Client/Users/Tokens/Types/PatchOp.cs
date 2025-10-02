using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client.Users;

[JsonConverter(typeof(StringEnumSerializer<PatchOp>))]
[Serializable]
public readonly record struct PatchOp : IStringEnum
{
    public static readonly PatchOp Replace = new(Values.Replace);

    public static readonly PatchOp Add = new(Values.Add);

    public static readonly PatchOp Remove = new(Values.Remove);

    public static readonly PatchOp Copy = new(Values.Copy);

    public static readonly PatchOp Move = new(Values.Move);

    public static readonly PatchOp Test = new(Values.Test);

    public PatchOp(string value)
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
    public static PatchOp FromCustom(string value)
    {
        return new PatchOp(value);
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

    public static bool operator ==(PatchOp value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(PatchOp value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(PatchOp value) => value.Value;

    public static explicit operator PatchOp(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Replace = "replace";

        public const string Add = "add";

        public const string Remove = "remove";

        public const string Copy = "copy";

        public const string Move = "move";

        public const string Test = "test";
    }
}
