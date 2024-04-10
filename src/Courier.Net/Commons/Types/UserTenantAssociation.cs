using System.Text.Json.Serialization;

namespace Courier.Net;

public class UserTenantAssociation
{
    /// <summary>
    /// User ID for the assocation between tenant and user
    /// </summary>
    [JsonPropertyName("user_id")]
    public string UserId { get; init; }

    [JsonPropertyName("type")]
    public string Type { get; init; }

    /// <summary>
    /// Tenant ID for the assocation between tenant and user
    /// </summary>
    [JsonPropertyName("tenant_id")]
    public string TenantId { get; init; }

    [JsonPropertyName("profile")]
    public Dictionary<string, object> Profile { get; init; }
}
