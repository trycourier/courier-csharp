using System;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Tenants;
using Courier.Services.Tenants.Templates;
using Courier.Services.Tenants.TenantDefaultPreferences;

namespace Courier.Services.Tenants;

public interface ITenantService
{
    ITenantService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ITenantDefaultPreferenceService TenantDefaultPreferences { get; }

    ITemplateService Templates { get; }

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
