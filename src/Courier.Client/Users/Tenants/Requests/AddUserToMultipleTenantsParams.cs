using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;

namespace Courier.Client.Users;

[Serializable]
public record AddUserToMultipleTenantsParams
{
    [JsonPropertyName("tenants")]
    public IEnumerable<UserTenantAssociation> Tenants { get; set; } =
        new List<UserTenantAssociation>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
