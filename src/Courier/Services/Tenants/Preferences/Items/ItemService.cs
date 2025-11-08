using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Tenants.Preferences.Items;

namespace Courier.Services.Tenants.Preferences.Items;

public sealed class ItemService : IItemService
{
    public IItemService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ItemService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public ItemService(ICourierClient client)
    {
        _client = client;
    }

    public async Task Update(
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ItemUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task Delete(
        ItemDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ItemDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
