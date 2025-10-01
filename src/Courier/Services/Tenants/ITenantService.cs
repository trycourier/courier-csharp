using System.Threading.Tasks;
using Courier.Models.Tenants;
using Courier.Services.Tenants.DefaultPreferences;

namespace Courier.Services.Tenants;

public interface ITenantService
{
    IDefaultPreferenceService DefaultPreferences { get; }

    /// <summary>
    /// Get a Tenant
    /// </summary>
    Task<Tenant> Retrieve(TenantRetrieveParams parameters);

    /// <summary>
    /// Create or Replace a Tenant
    /// </summary>
    Task<Tenant> Update(TenantUpdateParams parameters);

    /// <summary>
    /// Get a List of Tenants
    /// </summary>
    Task<TenantListResponse> List(TenantListParams? parameters = null);

    /// <summary>
    /// Delete a Tenant
    /// </summary>
    Task Delete(TenantDeleteParams parameters);

    /// <summary>
    /// Get Users in Tenant
    /// </summary>
    Task<TenantListUsersResponse> ListUsers(TenantListUsersParams parameters);
}
