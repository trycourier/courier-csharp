using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Profiles.Lists;

namespace Courier.Services.Profiles;

public interface IListService
{
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

    /// <summary>
    /// Removes all list subscriptions for given user.
    /// </summary>
    Task<ListDeleteResponse> Delete(
        ListDeleteParams parameters,
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
}
