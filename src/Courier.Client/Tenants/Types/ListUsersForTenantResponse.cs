using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record ListUsersForTenantResponse
{
    [JsonPropertyName("items")]
    public IEnumerable<UserTenantAssociation>? Items { get; init; }

    /// <summary>
    /// Set to true when there are more pages that can be retrieved.
    /// </summary>
    [JsonPropertyName("has_more")]
    public required bool HasMore { get; init; }

    /// <summary>
    /// A url that may be used to generate these results.
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; init; }

    /// <summary>
    /// A url that may be used to generate fetch the next set of results.
    /// Defined only when `has_more` is set to true
    /// </summary>
    [JsonPropertyName("next_url")]
    public string? NextUrl { get; init; }

    /// <summary>
    /// A pointer to the next page of results. Defined
    /// only when `has_more` is set to true
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }

    /// <summary>
    /// Always set to `list`. Represents the type of this object.
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }
}
