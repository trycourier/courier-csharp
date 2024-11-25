using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client.Users;

public record AddUserToMultipleTenantsParams
{
    [JsonPropertyName("tenants")]
    public IEnumerable<UserTenantAssociation> Tenants { get; set; } =
        new List<UserTenantAssociation>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
