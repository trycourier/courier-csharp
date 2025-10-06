using System.Threading.Tasks;
using Courier.Models.Profiles.Lists;

namespace Courier.Services.Profiles.Lists;

public interface IListService
{
    /// <summary>
    /// Returns the subscribed lists for a specified user.
    /// </summary>
    Task<ListRetrieveResponse> Retrieve(ListRetrieveParams parameters);

    /// <summary>
    /// Removes all list subscriptions for given user.
    /// </summary>
    Task<ListDeleteResponse> Delete(ListDeleteParams parameters);

    /// <summary>
    /// Subscribes the given user to one or more lists. If the list does not exist,
    /// it will be created.
    /// </summary>
    Task<ListSubscribeResponse> Subscribe(ListSubscribeParams parameters);
}
