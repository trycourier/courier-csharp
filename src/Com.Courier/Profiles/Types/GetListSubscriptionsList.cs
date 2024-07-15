using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record GetListSubscriptionsList
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// List name
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// The date/time of when the list was created. Represented as a string in ISO format.
    /// </summary>
    [JsonPropertyName("created")]
    public required string Created { get; init; }

    /// <summary>
    /// The date/time of when the list was updated. Represented as a string in ISO format.
    /// </summary>
    [JsonPropertyName("updated")]
    public required string Updated { get; init; }

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; init; }
}
