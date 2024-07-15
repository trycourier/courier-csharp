using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record MessageContext
{
    /// <summary>
    /// An id of a tenant, see [tenants api docs](https://www.courier.com/docs/reference/tenants/).
    /// Will load brand, default preferences and any other base context data associated with this tenant.
    /// </summary>
    [JsonPropertyName("tenant_id")]
    public string? TenantId { get; init; }
}
