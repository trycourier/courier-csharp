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
