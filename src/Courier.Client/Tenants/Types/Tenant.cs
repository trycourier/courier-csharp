using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record Tenant
{
    /// <summary>
    /// Id of the tenant.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// Name of the tenant.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Tenant's parent id (if any).
    /// </summary>
    [JsonPropertyName("parent_tenant_id")]
    public string? ParentTenantId { get; init; }

    /// <summary>
    /// Defines the preferences used for the account when the user hasn't specified their own.
    /// </summary>
    [JsonPropertyName("default_preferences")]
    public DefaultPreferences? DefaultPreferences { get; init; }

    /// <summary>
    /// Arbitrary properties accessible to a template.
    /// </summary>
    [JsonPropertyName("properties")]
    public Dictionary<string, object>? Properties { get; init; }

    /// <summary>
    /// A user profile object merged with user profile on send.
    /// </summary>
    [JsonPropertyName("user_profile")]
    public Dictionary<string, object>? UserProfile { get; init; }

    /// <summary>
    /// Brand to be used for the account when one is not specified by the send call.
    /// </summary>
    [JsonPropertyName("brand_id")]
    public string? BrandId { get; init; }
}
