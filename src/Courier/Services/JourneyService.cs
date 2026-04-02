using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Journeys;

namespace Courier.Services;

/// <inheritdoc/>
public sealed class JourneyService : IJourneyService
{
    readonly Lazy<IJourneyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IJourneyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IJourneyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new JourneyService(this._client.WithOptions(modifier));
    }

    public JourneyService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new JourneyServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<JourneysListResponse> List(
        JourneyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<JourneysInvokeResponse> Invoke(
        JourneyInvokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Invoke(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JourneysInvokeResponse> Invoke(
        string templateID,
        JourneyInvokeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Invoke(parameters with { TemplateID = templateID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class JourneyServiceWithRawResponse : IJourneyServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IJourneyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new JourneyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public JourneyServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JourneysListResponse>> List(
        JourneyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<JourneyListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var journeysListResponse = await response
                    .Deserialize<JourneysListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    journeysListResponse.Validate();
                }
                return journeysListResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JourneysInvokeResponse>> Invoke(
        JourneyInvokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TemplateID == null)
        {
            throw new CourierInvalidDataException("'parameters.TemplateID' cannot be null");
        }

        HttpRequest<JourneyInvokeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var journeysInvokeResponse = await response
                    .Deserialize<JourneysInvokeResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    journeysInvokeResponse.Validate();
                }
                return journeysInvokeResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<JourneysInvokeResponse>> Invoke(
        string templateID,
        JourneyInvokeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Invoke(parameters with { TemplateID = templateID }, cancellationToken);
    }
}
