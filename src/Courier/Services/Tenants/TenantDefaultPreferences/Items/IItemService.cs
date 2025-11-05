using System;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Tenants.TenantDefaultPreferences.Items;

namespace Courier.Services.Tenants.TenantDefaultPreferences.Items;

public interface IItemService
{
    IItemService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create or Replace Default Preferences For Topic
    /// </summary>
    Task Update(ItemUpdateParams parameters);

    /// <summary>
    /// Remove Default Preferences For Topic
    /// </summary>
    Task Delete(ItemDeleteParams parameters);
}
