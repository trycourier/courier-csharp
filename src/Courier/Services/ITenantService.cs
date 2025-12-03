using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Tenants;
using Courier.Services.Tenants;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITenantService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
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

    /// <inheritdoc cref="Retrieve(TenantRetrieveParams, CancellationToken)"/>
    Task<Tenant> Retrieve(
        string tenantID,
        TenantRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create or Replace a Tenant
    /// </summary>
    Task<Tenant> Update(
        TenantUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TenantUpdateParams, CancellationToken)"/>
    Task<Tenant> Update(
        string tenantID,
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

    /// <inheritdoc cref="Delete(TenantDeleteParams, CancellationToken)"/>
    Task Delete(
        string tenantID,
        TenantDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Users in Tenant
    /// </summary>
    Task<TenantListUsersResponse> ListUsers(
        TenantListUsersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListUsers(TenantListUsersParams, CancellationToken)"/>
    Task<TenantListUsersResponse> ListUsers(
        string tenantID,
        TenantListUsersParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
