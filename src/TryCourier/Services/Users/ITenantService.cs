using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Users.Tenants;

namespace TryCourier.Services.Users;

/// <summary>
/// Associate a user with one or more tenants, and read or remove those associations.
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

    /// <summary>
    /// Returns the tenants a user belongs to, with cursor paging. A user can belong to
    /// many tenants, each with its own profile and preferences.
    /// </summary>
    Task<TenantListResponse> List(
        TenantListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TenantListParams, CancellationToken)"/>
    Task<TenantListResponse> List(
        string userID,
        TenantListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Adds a user to several tenants in one call, each optionally with a per-tenant
    /// profile that overrides their workspace profile.
    /// </summary>
    Task AddMultiple(
        TenantAddMultipleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="AddMultiple(TenantAddMultipleParams, CancellationToken)"/>
    Task AddMultiple(
        string userID,
        TenantAddMultipleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Adds a user to one tenant, optionally with a tenant-specific profile that
    /// overrides their workspace profile for sends in that tenant.
    /// </summary>
    Task AddSingle(TenantAddSingleParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="AddSingle(TenantAddSingleParams, CancellationToken)"/>
    Task AddSingle(
        string tenantID,
        TenantAddSingleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes a user from every tenant they belong to in one call. Their
    /// workspace-level profile is a separate resource.
    /// </summary>
    Task RemoveAll(TenantRemoveAllParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="RemoveAll(TenantRemoveAllParams, CancellationToken)"/>
    Task RemoveAll(
        string userID,
        TenantRemoveAllParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes a user from one tenant. Their other tenant memberships and workspace
    /// profile are managed through separate endpoints.
    /// </summary>
    Task RemoveSingle(
        TenantRemoveSingleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RemoveSingle(TenantRemoveSingleParams, CancellationToken)"/>
    Task RemoveSingle(
        string tenantID,
        TenantRemoveSingleParams parameters,
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

    /// <summary>
    /// Returns a raw HTTP response for <c>get /users/{user_id}/tenants</c>, but is otherwise the
    /// same as <see cref="ITenantService.List(TenantListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TenantListResponse>> List(
        TenantListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TenantListParams, CancellationToken)"/>
    Task<HttpResponse<TenantListResponse>> List(
        string userID,
        TenantListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /users/{user_id}/tenants</c>, but is otherwise the
    /// same as <see cref="ITenantService.AddMultiple(TenantAddMultipleParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> AddMultiple(
        TenantAddMultipleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="AddMultiple(TenantAddMultipleParams, CancellationToken)"/>
    Task<HttpResponse> AddMultiple(
        string userID,
        TenantAddMultipleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /users/{user_id}/tenants/{tenant_id}</c>, but is otherwise the
    /// same as <see cref="ITenantService.AddSingle(TenantAddSingleParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> AddSingle(
        TenantAddSingleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="AddSingle(TenantAddSingleParams, CancellationToken)"/>
    Task<HttpResponse> AddSingle(
        string tenantID,
        TenantAddSingleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /users/{user_id}/tenants</c>, but is otherwise the
    /// same as <see cref="ITenantService.RemoveAll(TenantRemoveAllParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> RemoveAll(
        TenantRemoveAllParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RemoveAll(TenantRemoveAllParams, CancellationToken)"/>
    Task<HttpResponse> RemoveAll(
        string userID,
        TenantRemoveAllParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /users/{user_id}/tenants/{tenant_id}</c>, but is otherwise the
    /// same as <see cref="ITenantService.RemoveSingle(TenantRemoveSingleParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> RemoveSingle(
        TenantRemoveSingleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RemoveSingle(TenantRemoveSingleParams, CancellationToken)"/>
    Task<HttpResponse> RemoveSingle(
        string tenantID,
        TenantRemoveSingleParams parameters,
        CancellationToken cancellationToken = default
    );
}
