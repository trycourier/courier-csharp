using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record UserTenantAssociation
{
    /// <summary>
    /// User ID for the assocation between tenant and user
    /// </summary>
    [JsonPropertyName("user_id")]
    public string? UserId { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Tenant ID for the assocation between tenant and user
    /// </summary>
    [JsonPropertyName("tenant_id")]
    public required string TenantId { get; init; }

    /// <summary>
    /// Additional metadata to be applied to a user profile when used in a tenant context
    /// </summary>
    [JsonPropertyName("profile")]
    public Dictionary<string, object>? Profile { get; init; }
}
