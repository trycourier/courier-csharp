using System;
using Courier.Core;
using Courier.Services.Tenants.TenantDefaultPreferences.Items;

namespace Courier.Services.Tenants.TenantDefaultPreferences;

public sealed class TenantDefaultPreferenceService : ITenantDefaultPreferenceService
{
    public ITenantDefaultPreferenceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TenantDefaultPreferenceService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public TenantDefaultPreferenceService(ICourierClient client)
    {
        _client = client;
        _items = new(() => new ItemService(client));
    }

    readonly Lazy<IItemService> _items;
    public IItemService Items
    {
        get { return _items.Value; }
    }
}
