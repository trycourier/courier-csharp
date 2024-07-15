using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record ListPutParams
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; init; }
}
