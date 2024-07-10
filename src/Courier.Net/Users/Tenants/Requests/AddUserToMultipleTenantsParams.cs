using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net.Users;

public record AddUserToMultipleTenantsParams
{
    [JsonPropertyName("tenants")]
    public IEnumerable<UserTenantAssociation> Tenants { get; init; } =
        new List<UserTenantAssociation>();
}
