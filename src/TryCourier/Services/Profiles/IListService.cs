using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Profiles.Lists;

namespace TryCourier.Services.Profiles;

/// <summary>
/// Store the contact information Courier delivers to for each user — email, phone
/// number, push tokens, and any custom data you send to.
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

    /// <summary>
    /// Returns the lists a user is subscribed to, with paging. Use it to check what a
    /// recipient will receive before sending to a list.
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
    /// Removes every list subscription for a user at once. Their profile and
    /// preferences are untouched, so this only affects list-targeted sends.
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
    /// Subscribes a user to one or more lists, creating any list that does not yet
    /// exist. Optional preferences apply to each subscription.
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

    /// <summary>
    /// Returns a raw HTTP response for <c>get /profiles/{user_id}/lists</c>, but is otherwise the
    /// same as <see cref="IListService.Retrieve(ListRetrieveParams, CancellationToken)"/>.
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
    /// Returns a raw HTTP response for <c>delete /profiles/{user_id}/lists</c>, but is otherwise the
    /// same as <see cref="IListService.Delete(ListDeleteParams, CancellationToken)"/>.
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
    /// Returns a raw HTTP response for <c>post /profiles/{user_id}/lists</c>, but is otherwise the
    /// same as <see cref="IListService.Subscribe(ListSubscribeParams, CancellationToken)"/>.
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
