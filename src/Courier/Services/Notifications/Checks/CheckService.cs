using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Notifications.Checks;

namespace Courier.Services.Notifications.Checks;

public sealed class CheckService : ICheckService
{
    readonly ICourierClient _client;

    public CheckService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<CheckUpdateResponse> Update(CheckUpdateParams parameters)
    {
        HttpRequest<CheckUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var check = await response.Deserialize<CheckUpdateResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            check.Validate();
        }
        return check;
    }

    public async Task<CheckListResponse> List(CheckListParams parameters)
    {
        HttpRequest<CheckListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var checks = await response.Deserialize<CheckListResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            checks.Validate();
        }
        return checks;
    }

    public async Task Delete(CheckDeleteParams parameters)
    {
        HttpRequest<CheckDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }
}
