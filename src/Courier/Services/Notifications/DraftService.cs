using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Notifications;
using Courier.Models.Notifications.Draft;

namespace Courier.Services.Notifications;

/// <inheritdoc/>
public sealed class DraftService : IDraftService
{
    readonly Lazy<IDraftServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDraftServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IDraftService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DraftService(this._client.WithOptions(modifier));
    }

    public DraftService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DraftServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<NotificationGetContent> RetrieveContent(
        DraftRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveContent(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<NotificationGetContent> RetrieveContent(
        string id,
        DraftRetrieveContentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveContent(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class DraftServiceWithRawResponse : IDraftServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDraftServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DraftServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DraftServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationGetContent>> RetrieveContent(
        DraftRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CourierInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<DraftRetrieveContentParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var notificationGetContent = await response
                    .Deserialize<NotificationGetContent>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    notificationGetContent.Validate();
                }
                return notificationGetContent;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<NotificationGetContent>> RetrieveContent(
        string id,
        DraftRetrieveContentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveContent(parameters with { ID = id }, cancellationToken);
    }
}
