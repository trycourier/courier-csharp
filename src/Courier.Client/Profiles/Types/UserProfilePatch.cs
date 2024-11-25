using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record UserProfilePatch
{
    /// <summary>
    /// The operation to perform.
    /// </summary>
    [JsonPropertyName("op")]
    public required string Op { get; set; }

    /// <summary>
    /// The JSON path specifying the part of the profile to operate on.
    /// </summary>
    [JsonPropertyName("path")]
    public required string Path { get; set; }

    /// <summary>
    /// The value for the operation.
    /// </summary>
    [JsonPropertyName("value")]
    public required string Value { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
