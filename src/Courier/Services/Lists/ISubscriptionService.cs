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
    ISubscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the list's subscriptions.
    /// </summary>
    Task<SubscriptionListResponse> List(
        SubscriptionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Subscribes additional users to the list, without modifying existing subscriptions.
    /// If the list does not exist, it will be automatically created.
    /// </summary>
    Task Add(SubscriptionAddParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Subscribes the users to the list, overwriting existing subscriptions. If
    /// the list does not exist, it will be automatically created.
    /// </summary>
    Task Subscribe(
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

    /// <summary>
    /// Delete a subscription to a list by list ID and user ID.
    /// </summary>
    Task UnsubscribeUser(
        SubscriptionUnsubscribeUserParams parameters,
        CancellationToken cancellationToken = default
    );
}
