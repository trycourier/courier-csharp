using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client.Users;

public record AddUserToMultipleTenantsParams
{
    [JsonPropertyName("tenants")]
    public IEnumerable<UserTenantAssociation> Tenants { get; init; } =
        new List<UserTenantAssociation>();
}
