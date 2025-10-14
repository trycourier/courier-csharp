using System;
using Courier.Services.Tenants.TenantDefaultPreferences.Items;

namespace Courier.Services.Tenants.TenantDefaultPreferences;

public sealed class TenantDefaultPreferenceService : ITenantDefaultPreferenceService
{
    public TenantDefaultPreferenceService(ICourierClient client)
    {
        _items = new(() => new ItemService(client));
    }

    readonly Lazy<IItemService> _items;
    public IItemService Items
    {
        get { return _items.Value; }
    }
}
