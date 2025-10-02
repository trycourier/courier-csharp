using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record TenantCreateOrReplaceParams
{
    /// <summary>
    /// Name of the tenant.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Tenant's parent id (if any).
    /// </summary>
    [JsonPropertyName("parent_tenant_id")]
    public string? ParentTenantId { get; set; }

    /// <summary>
    /// Defines the preferences used for the tenant when the user hasn't specified their own.
    /// </summary>
    [JsonPropertyName("default_preferences")]
    public DefaultPreferences? DefaultPreferences { get; set; }

    /// <summary>
    /// Arbitrary properties accessible to a template.
    /// </summary>
    [JsonPropertyName("properties")]
    public Dictionary<string, object?>? Properties { get; set; }

    /// <summary>
    /// A user profile object merged with user profile on send.
    /// </summary>
    [JsonPropertyName("user_profile")]
    public Dictionary<string, object?>? UserProfile { get; set; }

    /// <summary>
    /// Brand to be used for the account when one is not specified by the send call.
    /// </summary>
    [JsonPropertyName("brand_id")]
    public string? BrandId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
