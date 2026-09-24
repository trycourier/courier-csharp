using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Notifications.Previews.Runs;

namespace TryCourier.Services.Notifications.Previews;

/// <inheritdoc/>
public sealed class RunService : IRunService
{
    readonly Lazy<IRunServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRunServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IRunService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RunService(this._client.WithOptions(modifier));
    }

    public RunService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RunServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<PreviewRun> Create(
        RunCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PreviewRun> Create(
        string id,
        RunCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PreviewRunDetail> Retrieve(
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PreviewRunDetail> Retrieve(
        string previewRunID,
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { PreviewRunID = previewRunID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PreviewRunListResponse> List(
        RunListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PreviewRunListResponse> List(
        string id,
        RunListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class RunServiceWithRawResponse : IRunServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRunServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RunServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RunServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PreviewRun>> Create(
        RunCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CourierInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RunCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var previewRun = await response
                    .Deserialize<PreviewRun>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    previewRun.Validate();
                }
                return previewRun;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PreviewRun>> Create(
        string id,
        RunCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PreviewRunDetail>> Retrieve(
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PreviewRunID == null)
        {
            throw new CourierInvalidDataException("'parameters.PreviewRunID' cannot be null");
        }

        HttpRequest<RunRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var previewRunDetail = await response
                    .Deserialize<PreviewRunDetail>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    previewRunDetail.Validate();
                }
                return previewRunDetail;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PreviewRunDetail>> Retrieve(
        string previewRunID,
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { PreviewRunID = previewRunID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PreviewRunListResponse>> List(
        RunListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CourierInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RunListParams> request = new() { Method = HttpMethod.Get, Params = parameters };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var previewRunListResponse = await response
                    .Deserialize<PreviewRunListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    previewRunListResponse.Validate();
                }
                return previewRunListResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PreviewRunListResponse>> List(
        string id,
        RunListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }
}
