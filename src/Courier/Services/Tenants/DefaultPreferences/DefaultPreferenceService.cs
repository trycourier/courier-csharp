using System;
using Courier.Services.Tenants.DefaultPreferences.Items;

namespace Courier.Services.Tenants.DefaultPreferences;

public sealed class DefaultPreferenceService : IDefaultPreferenceService
{
    public DefaultPreferenceService(ICourierClient client)
    {
        _items = new(() => new ItemService(client));
    }

    readonly Lazy<IItemService> _items;
    public IItemService Items
    {
        get { return _items.Value; }
    }
}
