using System.Text.Json.Serialization;

namespace Courier.Net;

public class Preferences
{
    [JsonPropertyName("templateIds")]
    public List<string> TemplateIds { get; init; }
}
