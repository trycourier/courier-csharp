using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Requests;

namespace Courier.Services.Requests;

public sealed class RequestService : IRequestService
{
    readonly ICourierClient _client;

    public RequestService(ICourierClient client)
    {
        _client = client;
    }

    public async Task Archive(RequestArchiveParams parameters)
    {
        HttpRequest<RequestArchiveParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }
}
