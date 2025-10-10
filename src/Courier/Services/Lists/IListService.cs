using System.Threading.Tasks;
using Courier.Models;
using Courier.Models.Lists;
using Courier.Services.Lists.Subscriptions;

namespace Courier.Services.Lists;

public interface IListService
{
    ISubscriptionService Subscriptions { get; }

    /// <summary>
    /// Returns a list based on the list ID provided.
    /// </summary>
    Task<SubscriptionList> Retrieve(ListRetrieveParams parameters);

    /// <summary>
    /// Create or replace an existing list with the supplied values.
    /// </summary>
    Task Update(ListUpdateParams parameters);

    /// <summary>
    /// Returns all of the lists, with the ability to filter based on a pattern.
    /// </summary>
    Task<ListListResponse> List(ListListParams? parameters = null);

    /// <summary>
    /// Delete a list by list ID.
    /// </summary>
    Task Delete(ListDeleteParams parameters);

    /// <summary>
    /// Restore a previously deleted list.
    /// </summary>
    Task Restore(ListRestoreParams parameters);
}
