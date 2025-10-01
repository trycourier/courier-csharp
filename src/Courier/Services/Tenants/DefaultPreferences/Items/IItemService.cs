using System.Threading.Tasks;
using Courier.Models.Tenants.DefaultPreferences.Items;

namespace Courier.Services.Tenants.DefaultPreferences.Items;

public interface IItemService
{
    /// <summary>
    /// Create or Replace Default Preferences For Topic
    /// </summary>
    Task Update(ItemUpdateParams parameters);

    /// <summary>
    /// Remove Default Preferences For Topic
    /// </summary>
    Task Delete(ItemDeleteParams parameters);
}
