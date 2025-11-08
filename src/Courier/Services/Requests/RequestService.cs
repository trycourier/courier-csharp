using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Requests;

namespace Courier.Services.Requests;

public sealed class RequestService : IRequestService
{
    public IRequestService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RequestService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public RequestService(ICourierClient client)
    {
        _client = client;
    }

    public async Task Archive(
        RequestArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RequestArchiveParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
