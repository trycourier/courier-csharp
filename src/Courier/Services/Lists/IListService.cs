using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Lists;
using Courier.Services.Lists.Subscriptions;

namespace Courier.Services.Lists;

public interface IListService
{
    IListService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISubscriptionService Subscriptions { get; }

    /// <summary>
    /// Returns a list based on the list ID provided.
    /// </summary>
    Task<SubscriptionList> Retrieve(
        ListRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create or replace an existing list with the supplied values.
    /// </summary>
    Task Update(ListUpdateParams parameters, CancellationToken cancellationToken = default);

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

    /// <summary>
    /// Restore a previously deleted list.
    /// </summary>
    Task Restore(ListRestoreParams parameters, CancellationToken cancellationToken = default);
}
