using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Tenants.TenantDefaultPreferences.Items;

namespace Courier.Services.Tenants.TenantDefaultPreferences.Items;

public sealed class ItemService : IItemService
{
    readonly ICourierClient _client;

    public ItemService(ICourierClient client)
    {
        _client = client;
    }

    public async Task Update(ItemUpdateParams parameters)
    {
        HttpRequest<ItemUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }

    public async Task Delete(ItemDeleteParams parameters)
    {
        HttpRequest<ItemDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }
}
