using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class IProfilePreferences
{
    [JsonPropertyName("categories")]
    public Dictionary<string, Preference>? Categories { get; init; }

    [JsonPropertyName("notifications")]
    public Dictionary<string, Preference> Notifications { get; init; }

    [JsonPropertyName("templateId")]
    public string? TemplateId { get; init; }
}
