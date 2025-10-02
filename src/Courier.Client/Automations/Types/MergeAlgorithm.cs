using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<MergeAlgorithm>))]
[Serializable]
public readonly record struct MergeAlgorithm : IStringEnum
{
    public static readonly MergeAlgorithm Replace = new(Values.Replace);

    public static readonly MergeAlgorithm None = new(Values.None);

    public static readonly MergeAlgorithm Overwrite = new(Values.Overwrite);

    public static readonly MergeAlgorithm SoftMerge = new(Values.SoftMerge);

    public MergeAlgorithm(string value)
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
    public static MergeAlgorithm FromCustom(string value)
    {
        return new MergeAlgorithm(value);
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

    public static bool operator ==(MergeAlgorithm value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MergeAlgorithm value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MergeAlgorithm value) => value.Value;

    public static explicit operator MergeAlgorithm(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Replace = "replace";

        public const string None = "none";

        public const string Overwrite = "overwrite";

        public const string SoftMerge = "soft-merge";
    }
}
