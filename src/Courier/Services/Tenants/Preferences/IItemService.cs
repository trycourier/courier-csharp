using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Tenants.Preferences.Items;

namespace Courier.Services.Tenants.Preferences;

public interface IItemService
{
    IItemService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create or Replace Default Preferences For Topic
    /// </summary>
    Task Update(ItemUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove Default Preferences For Topic
    /// </summary>
    Task Delete(ItemDeleteParams parameters, CancellationToken cancellationToken = default);
}
