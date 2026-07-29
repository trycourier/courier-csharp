using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Tenants;
using TryCourier.Services.Tenants;

namespace TryCourier.Services;

/// <summary>
/// Manage tenants — the organizations, teams, or accounts your users belong to —
/// along with their users and default preferences.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITenantService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITenantServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITenantService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IPreferenceService Preferences { get; }

    ITemplateService Templates { get; }

    /// <summary>
    /// Returns one tenant with its name, parent tenant id, default preferences,
    /// properties, and the user profile applied to its members.
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
    /// Creates or replaces a tenant from a name, parent, brand, properties, and default
    /// preferences supplied in the request body.
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
    /// Lists the workspace's tenants, each carrying a name, parent tenant, properties,
    /// and default preferences. Paged.
    /// </summary>
    Task<TenantListResponse> List(
        TenantListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a tenant. Its members' workspace-level profiles and preferences live
    /// outside the tenant and are managed separately.
    /// </summary>
    Task Delete(TenantDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(TenantDeleteParams, CancellationToken)"/>
    Task Delete(
        string tenantID,
        TenantDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the users belonging to a tenant with cursor paging. Use it to see who a
    /// tenant-scoped send will reach.
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

/// <summary>
/// A view of <see cref="ITenantService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITenantServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITenantServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IPreferenceServiceWithRawResponse Preferences { get; }

    ITemplateServiceWithRawResponse Templates { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /tenants/{tenant_id}</c>, but is otherwise the
    /// same as <see cref="ITenantService.Retrieve(TenantRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Tenant>> Retrieve(
        TenantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TenantRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Tenant>> Retrieve(
        string tenantID,
        TenantRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /tenants/{tenant_id}</c>, but is otherwise the
    /// same as <see cref="ITenantService.Update(TenantUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Tenant>> Update(
        TenantUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TenantUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Tenant>> Update(
        string tenantID,
        TenantUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /tenants</c>, but is otherwise the
    /// same as <see cref="ITenantService.List(TenantListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TenantListResponse>> List(
        TenantListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /tenants/{tenant_id}</c>, but is otherwise the
    /// same as <see cref="ITenantService.Delete(TenantDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        TenantDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TenantDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string tenantID,
        TenantDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /tenants/{tenant_id}/users</c>, but is otherwise the
    /// same as <see cref="ITenantService.ListUsers(TenantListUsersParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TenantListUsersResponse>> ListUsers(
        TenantListUsersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListUsers(TenantListUsersParams, CancellationToken)"/>
    Task<HttpResponse<TenantListUsersResponse>> ListUsers(
        string tenantID,
        TenantListUsersParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
