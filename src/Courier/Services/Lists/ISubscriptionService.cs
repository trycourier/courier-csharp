using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Lists.Subscriptions;

namespace Courier.Services.Lists;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISubscriptionService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISubscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the list's subscriptions.
    /// </summary>
    Task<SubscriptionListResponse> List(
        SubscriptionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(SubscriptionListParams, CancellationToken)"/>
    Task<SubscriptionListResponse> List(
        string listID,
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Subscribes additional users to the list, without modifying existing subscriptions.
    /// If the list does not exist, it will be automatically created.
    /// </summary>
    Task Add(SubscriptionAddParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Add(SubscriptionAddParams, CancellationToken)"/>
    Task Add(
        string listID,
        SubscriptionAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Subscribes the users to the list, overwriting existing subscriptions. If
    /// the list does not exist, it will be automatically created.
    /// </summary>
    Task Subscribe(
        SubscriptionSubscribeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Subscribe(SubscriptionSubscribeParams, CancellationToken)"/>
    Task Subscribe(
        string listID,
        SubscriptionSubscribeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Subscribe a user to an existing list (note: if the List does not exist, it
    /// will be automatically created).
    /// </summary>
    Task SubscribeUser(
        SubscriptionSubscribeUserParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SubscribeUser(SubscriptionSubscribeUserParams, CancellationToken)"/>
    Task SubscribeUser(
        string userID,
        SubscriptionSubscribeUserParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a subscription to a list by list ID and user ID.
    /// </summary>
    Task UnsubscribeUser(
        SubscriptionUnsubscribeUserParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UnsubscribeUser(SubscriptionUnsubscribeUserParams, CancellationToken)"/>
    Task UnsubscribeUser(
        string userID,
        SubscriptionUnsubscribeUserParams parameters,
        CancellationToken cancellationToken = default
    );
}
