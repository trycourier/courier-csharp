using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Requests;

namespace Courier.Services;

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
        if (parameters.RequestID == null)
        {
            throw new CourierInvalidDataException("'parameters.RequestID' cannot be null");
        }

        HttpRequest<RequestArchiveParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task Archive(
        string requestID,
        RequestArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Archive(parameters with { RequestID = requestID }, cancellationToken);
    }
}
