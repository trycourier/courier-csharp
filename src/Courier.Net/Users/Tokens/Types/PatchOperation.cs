using System.Text.Json.Serialization;

namespace Courier.Net.Users;

public class PatchOperation
{
    /// <summary>
    /// The operation to perform.
    /// </summary>
    [JsonPropertyName("op")]
    public string Op { get; init; }

    /// <summary>
    /// The JSON path specifying the part of the profile to operate on.
    /// </summary>
    [JsonPropertyName("path")]
    public string Path { get; init; }

    /// <summary>
    /// The value for the operation.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value { get; init; }
}
