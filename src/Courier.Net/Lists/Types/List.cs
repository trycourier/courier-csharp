using System.Text.Json.Serialization;

namespace Courier.Net;

public class List
{
    [JsonPropertyName("id")]
    public string Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("created")]
    public int? Created { get; init; }

    [JsonPropertyName("updated")]
    public int? Updated { get; init; }
}
