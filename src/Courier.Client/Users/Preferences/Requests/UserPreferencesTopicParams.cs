using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client.Users;

[Serializable]
public record UserPreferencesTopicParams
{
    /// <summary>
    /// Query the preferences of a user for this specific tenant context.
    /// </summary>
    [JsonIgnore]
    public string? TenantId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
