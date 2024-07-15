using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier.Users;

public record AddUserToMultipleTenantsParams
{
    [JsonPropertyName("tenants")]
    public IEnumerable<UserTenantAssociation> Tenants { get; init; } =
        new List<UserTenantAssociation>();
}
