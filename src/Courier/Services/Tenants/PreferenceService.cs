using System;
using Courier.Core;
using Courier.Services.Tenants.Preferences;

namespace Courier.Services.Tenants;

public sealed class PreferenceService : IPreferenceService
{
    public IPreferenceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PreferenceService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public PreferenceService(ICourierClient client)
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
