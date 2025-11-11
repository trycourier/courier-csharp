using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Tenants;
using Courier.Services.Tenants;

namespace Courier.Services;

public interface ITenantService
{
    ITenantService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IPreferenceService Preferences { get; }

    ITemplateService Templates { get; }

    /// <summary>
    /// Get a Tenant
    /// </summary>
    Task<Tenant> Retrieve(
        TenantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create or Replace a Tenant
    /// </summary>
    Task<Tenant> Update(
        TenantUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a List of Tenants
    /// </summary>
    Task<TenantListResponse> List(
        TenantListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a Tenant
    /// </summary>
    Task Delete(TenantDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Users in Tenant
    /// </summary>
    Task<TenantListUsersResponse> ListUsers(
        TenantListUsersParams parameters,
        CancellationToken cancellationToken = default
    );
}
