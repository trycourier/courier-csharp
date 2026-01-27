using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Users.Tenants;

namespace Courier.Services.Users;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
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
    /// Returns a paginated list of user tenant associations.
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
    /// This endpoint is used to add a user to multiple tenants in one call. A custom
    /// profile can also be supplied for each tenant.  This profile will be merged
    /// with the user's main  profile when sending to the user with that tenant.
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
    /// This endpoint is used to add a single tenant.
    ///
    /// <para>A custom profile can also be supplied with the tenant.  This profile
    /// will be merged with the user's main profile  when sending to the user with
    /// that tenant.</para>
    /// </summary>
    Task AddSingle(TenantAddSingleParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="AddSingle(TenantAddSingleParams, CancellationToken)"/>
    Task AddSingle(
        string tenantID,
        TenantAddSingleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes a user from any tenants they may have been associated with.
    /// </summary>
    Task RemoveAll(TenantRemoveAllParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="RemoveAll(TenantRemoveAllParams, CancellationToken)"/>
    Task RemoveAll(
        string userID,
        TenantRemoveAllParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes a user from the supplied tenant.
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
    /// Returns a raw HTTP response for `get /users/{user_id}/tenants`, but is otherwise the
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
    /// Returns a raw HTTP response for `put /users/{user_id}/tenants`, but is otherwise the
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
    /// Returns a raw HTTP response for `put /users/{user_id}/tenants/{tenant_id}`, but is otherwise the
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
    /// Returns a raw HTTP response for `delete /users/{user_id}/tenants`, but is otherwise the
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
    /// Returns a raw HTTP response for `delete /users/{user_id}/tenants/{tenant_id}`, but is otherwise the
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
