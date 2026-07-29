using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Lists;
using TryCourier.Services.Lists;

namespace TryCourier.Services;

/// <summary>
/// Manage static groups of users that you subscribe explicitly, and send to them
/// by list id or list pattern.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IListService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IListServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IListService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISubscriptionService Subscriptions { get; }

    /// <summary>
    /// Returns one list by id with its name and created and updated timestamps. Fetch
    /// its subscribers separately with the subscriptions endpoint.
    /// </summary>
    Task<SubscriptionList> Retrieve(
        ListRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ListRetrieveParams, CancellationToken)"/>
    Task<SubscriptionList> Retrieve(
        string listID,
        ListRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates or replaces a list from a name and preferences. Subscribers are managed
    /// through the separate subscriptions endpoints.
    /// </summary>
    Task Update(ListUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(ListUpdateParams, CancellationToken)"/>
    Task Update(
        string listID,
        ListUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the workspace's lists, filterable by a pattern to fetch a subset such as
    /// every regional list. Paged by cursor.
    /// </summary>
    Task<ListListResponse> List(
        ListListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a list, halting sends that target it. A previously deleted list can be
    /// brought back with the companion restore endpoint.
    /// </summary>
    Task Delete(ListDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(ListDeleteParams, CancellationToken)"/>
    Task Delete(
        string listID,
        ListDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Restores a previously deleted list along with its subscribers, so a list removed
    /// by mistake can be brought back rather than rebuilt.
    /// </summary>
    Task Restore(ListRestoreParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Restore(ListRestoreParams, CancellationToken)"/>
    Task Restore(
        string listID,
        ListRestoreParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IListService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IListServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IListServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISubscriptionServiceWithRawResponse Subscriptions { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /lists/{list_id}</c>, but is otherwise the
    /// same as <see cref="IListService.Retrieve(ListRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionList>> Retrieve(
        ListRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ListRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SubscriptionList>> Retrieve(
        string listID,
        ListRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /lists/{list_id}</c>, but is otherwise the
    /// same as <see cref="IListService.Update(ListUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        ListUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ListUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string listID,
        ListUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /lists</c>, but is otherwise the
    /// same as <see cref="IListService.List(ListListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ListListResponse>> List(
        ListListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /lists/{list_id}</c>, but is otherwise the
    /// same as <see cref="IListService.Delete(ListDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        ListDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ListDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string listID,
        ListDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /lists/{list_id}/restore</c>, but is otherwise the
    /// same as <see cref="IListService.Restore(ListRestoreParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Restore(
        ListRestoreParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Restore(ListRestoreParams, CancellationToken)"/>
    Task<HttpResponse> Restore(
        string listID,
        ListRestoreParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
