using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record GetListSubscriptionsList
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// List name
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The date/time of when the list was created. Represented as a string in ISO format.
    /// </summary>
    [JsonPropertyName("created")]
    public required string Created { get; set; }

    /// <summary>
    /// The date/time of when the list was updated. Represented as a string in ISO format.
    /// </summary>
    [JsonPropertyName("updated")]
    public required string Updated { get; set; }

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
