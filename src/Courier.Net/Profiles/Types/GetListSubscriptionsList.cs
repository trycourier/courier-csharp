using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class GetListSubscriptionsList
{
    [JsonPropertyName("id")]
    public string Id { get; init; }

    /// <summary>
    /// List name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; }

    /// <summary>
    /// The date/time of when the list was created. Represented as a string in ISO format.
    /// </summary>
    [JsonPropertyName("created")]
    public string Created { get; init; }

    /// <summary>
    /// The date/time of when the list was updated. Represented as a string in ISO format.
    /// </summary>
    [JsonPropertyName("updated")]
    public string Updated { get; init; }

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; init; }
}
