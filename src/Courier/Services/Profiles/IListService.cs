using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Profiles.Lists;

namespace Courier.Services.Profiles;

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
    global::Courier.Services.Profiles.IListServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    global::Courier.Services.Profiles.IListService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns the subscribed lists for a specified user.
    /// </summary>
    Task<ListRetrieveResponse> Retrieve(
        ListRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ListRetrieveParams, CancellationToken)"/>
    Task<ListRetrieveResponse> Retrieve(
        string userID,
        ListRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes all list subscriptions for given user.
    /// </summary>
    Task<ListDeleteResponse> Delete(
        ListDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ListDeleteParams, CancellationToken)"/>
    Task<ListDeleteResponse> Delete(
        string userID,
        ListDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Subscribes the given user to one or more lists. If the list does not exist,
    /// it will be created.
    /// </summary>
    Task<ListSubscribeResponse> Subscribe(
        ListSubscribeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Subscribe(ListSubscribeParams, CancellationToken)"/>
    Task<ListSubscribeResponse> Subscribe(
        string userID,
        ListSubscribeParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="global::Courier.Services.Profiles.IListService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IListServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    global::Courier.Services.Profiles.IListServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /profiles/{user_id}/lists`, but is otherwise the
    /// same as <see cref="global::Courier.Services.Profiles.IListService.Retrieve(ListRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ListRetrieveResponse>> Retrieve(
        ListRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ListRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ListRetrieveResponse>> Retrieve(
        string userID,
        ListRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /profiles/{user_id}/lists`, but is otherwise the
    /// same as <see cref="global::Courier.Services.Profiles.IListService.Delete(ListDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ListDeleteResponse>> Delete(
        ListDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ListDeleteParams, CancellationToken)"/>
    Task<HttpResponse<ListDeleteResponse>> Delete(
        string userID,
        ListDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /profiles/{user_id}/lists`, but is otherwise the
    /// same as <see cref="global::Courier.Services.Profiles.IListService.Subscribe(ListSubscribeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ListSubscribeResponse>> Subscribe(
        ListSubscribeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Subscribe(ListSubscribeParams, CancellationToken)"/>
    Task<HttpResponse<ListSubscribeResponse>> Subscribe(
        string userID,
        ListSubscribeParams parameters,
        CancellationToken cancellationToken = default
    );
}
