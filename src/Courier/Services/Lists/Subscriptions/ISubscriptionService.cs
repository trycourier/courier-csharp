using System.Threading.Tasks;
using Courier.Models.Lists.Subscriptions;

namespace Courier.Services.Lists.Subscriptions;

public interface ISubscriptionService
{
    /// <summary>
    /// Get the list's subscriptions.
    /// </summary>
    Task<SubscriptionListResponse> List(SubscriptionListParams parameters);

    /// <summary>
    /// Subscribes additional users to the list, without modifying existing subscriptions.
    /// If the list does not exist, it will be automatically created.
    /// </summary>
    Task Add(SubscriptionAddParams parameters);

    /// <summary>
    /// Subscribes the users to the list, overwriting existing subscriptions. If the
    /// list does not exist, it will be automatically created.
    /// </summary>
    Task Subscribe(SubscriptionSubscribeParams parameters);

    /// <summary>
    /// Subscribe a user to an existing list (note: if the List does not exist, it
    /// will be automatically created).
    /// </summary>
    Task SubscribeUser(SubscriptionSubscribeUserParams parameters);

    /// <summary>
    /// Delete a subscription to a list by list ID and user ID.
    /// </summary>
    Task UnsubscribeUser(SubscriptionUnsubscribeUserParams parameters);
}
