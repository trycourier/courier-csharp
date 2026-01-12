using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Lists;
using Courier.Services.Lists;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
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
    /// Returns a list based on the list ID provided.
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
    /// Create or replace an existing list with the supplied values.
    /// </summary>
    Task Update(ListUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(ListUpdateParams, CancellationToken)"/>
    Task Update(
        string listID,
        ListUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns all of the lists, with the ability to filter based on a pattern.
    /// </summary>
    Task<ListListResponse> List(
        ListListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a list by list ID.
    /// </summary>
    Task Delete(ListDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(ListDeleteParams, CancellationToken)"/>
    Task Delete(
        string listID,
        ListDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Restore a previously deleted list.
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
    /// Returns a raw HTTP response for `get /lists/{list_id}`, but is otherwise the
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
    /// Returns a raw HTTP response for `put /lists/{list_id}`, but is otherwise the
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
    /// Returns a raw HTTP response for `get /lists`, but is otherwise the
    /// same as <see cref="IListService.List(ListListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ListListResponse>> List(
        ListListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /lists/{list_id}`, but is otherwise the
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
    /// Returns a raw HTTP response for `put /lists/{list_id}/restore`, but is otherwise the
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
