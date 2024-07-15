using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record Preferences
{
    [JsonPropertyName("templateIds")]
    public IEnumerable<string> TemplateIds { get; init; } = new List<string>();
}
