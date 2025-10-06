using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Bulk;

namespace Courier.Services.Bulk;

public sealed class BulkService : IBulkService
{
    readonly ICourierClient _client;

    public BulkService(ICourierClient client)
    {
        _client = client;
    }

    public async Task AddUsers(BulkAddUsersParams parameters)
    {
        HttpRequest<BulkAddUsersParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task<BulkCreateJobResponse> CreateJob(BulkCreateJobParams parameters)
    {
        HttpRequest<BulkCreateJobParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<BulkCreateJobResponse>().ConfigureAwait(false);
    }

    public async Task<BulkListUsersResponse> ListUsers(BulkListUsersParams parameters)
    {
        HttpRequest<BulkListUsersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<BulkListUsersResponse>().ConfigureAwait(false);
    }

    public async Task<BulkRetrieveJobResponse> RetrieveJob(BulkRetrieveJobParams parameters)
    {
        HttpRequest<BulkRetrieveJobParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<BulkRetrieveJobResponse>().ConfigureAwait(false);
    }

    public async Task RunJob(BulkRunJobParams parameters)
    {
        HttpRequest<BulkRunJobParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }
}
