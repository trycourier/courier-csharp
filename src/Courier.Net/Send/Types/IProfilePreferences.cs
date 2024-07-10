using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record IProfilePreferences
{
    [JsonPropertyName("categories")]
    public Dictionary<string, Preference>? Categories { get; init; }

    [JsonPropertyName("notifications")]
    public Dictionary<string, Preference> Notifications { get; init; } =
        new Dictionary<string, Preference>();

    [JsonPropertyName("templateId")]
    public string? TemplateId { get; init; }
}
