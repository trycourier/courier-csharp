using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client.Users;

[Serializable]
public record UserPreferencesUpdateParams
{
    /// <summary>
    /// Update the preferences of a user for this specific tenant context.
    /// </summary>
    [JsonIgnore]
    public string? TenantId { get; set; }

    [JsonPropertyName("topic")]
    public required TopicPreferenceUpdate Topic { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
