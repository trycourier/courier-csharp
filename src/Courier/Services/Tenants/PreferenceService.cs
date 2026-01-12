using System;
using Courier.Core;
using Courier.Services.Tenants.Preferences;

namespace Courier.Services.Tenants;

/// <inheritdoc/>
public sealed class PreferenceService : IPreferenceService
{
    readonly Lazy<IPreferenceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPreferenceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IPreferenceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PreferenceService(this._client.WithOptions(modifier));
    }

    public PreferenceService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PreferenceServiceWithRawResponse(client.WithRawResponse));
        _items = new(() => new ItemService(client));
    }

    readonly Lazy<IItemService> _items;
    public IItemService Items
    {
        get { return _items.Value; }
    }
}

/// <inheritdoc/>
public sealed class PreferenceServiceWithRawResponse : IPreferenceServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPreferenceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PreferenceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PreferenceServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;

        _items = new(() => new ItemServiceWithRawResponse(client));
    }

    readonly Lazy<IItemServiceWithRawResponse> _items;
    public IItemServiceWithRawResponse Items
    {
        get { return _items.Value; }
    }
}
