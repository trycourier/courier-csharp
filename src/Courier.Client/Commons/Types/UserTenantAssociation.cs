using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record UserTenantAssociation
{
    /// <summary>
    /// User ID for the assocation between tenant and user
    /// </summary>
    [JsonPropertyName("user_id")]
    public string? UserId { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Tenant ID for the assocation between tenant and user
    /// </summary>
    [JsonPropertyName("tenant_id")]
    public required string TenantId { get; set; }

    /// <summary>
    /// Additional metadata to be applied to a user profile when used in a tenant context
    /// </summary>
    [JsonPropertyName("profile")]
    public Dictionary<string, object?>? Profile { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
