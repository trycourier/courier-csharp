using Courier.Services.Tenants.DefaultPreferences.Items;

namespace Courier.Services.Tenants.DefaultPreferences;

public interface IDefaultPreferenceService
{
    IItemService Items { get; }
}
