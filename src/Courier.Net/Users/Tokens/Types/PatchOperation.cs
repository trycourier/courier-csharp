using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net.Users;

public record PatchOperation
{
    /// <summary>
    /// The operation to perform.
    /// </summary>
    [JsonPropertyName("op")]
    public required string Op { get; init; }

    /// <summary>
    /// The JSON path specifying the part of the profile to operate on.
    /// </summary>
    [JsonPropertyName("path")]
    public required string Path { get; init; }

    /// <summary>
    /// The value for the operation.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value { get; init; }
}
