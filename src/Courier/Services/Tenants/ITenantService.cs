using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Services.Tenants.Preferences;
using Courier.Services.Tenants.Templates;
using Tenants = Courier.Models.Tenants;

namespace Courier.Services.Tenants;

public interface ITenantService
{
    ITenantService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IPreferenceService Preferences { get; }

    ITemplateService Templates { get; }

    /// <summary>
    /// Get a Tenant
    /// </summary>
    Task<Tenants::Tenant> Retrieve(
        Tenants::TenantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create or Replace a Tenant
    /// </summary>
    Task<Tenants::Tenant> Update(
        Tenants::TenantUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a List of Tenants
    /// </summary>
    Task<Tenants::TenantListResponse> List(
        Tenants::TenantListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a Tenant
    /// </summary>
    Task Delete(
        Tenants::TenantDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Users in Tenant
    /// </summary>
    Task<Tenants::TenantListUsersResponse> ListUsers(
        Tenants::TenantListUsersParams parameters,
        CancellationToken cancellationToken = default
    );
}
