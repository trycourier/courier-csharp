using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record IProfilePreferences
{
    [JsonPropertyName("categories")]
    public Dictionary<string, Preference>? Categories { get; set; }

    [JsonPropertyName("notifications")]
    public Dictionary<string, Preference> Notifications { get; set; } =
        new Dictionary<string, Preference>();

    [JsonPropertyName("templateId")]
    public string? TemplateId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
