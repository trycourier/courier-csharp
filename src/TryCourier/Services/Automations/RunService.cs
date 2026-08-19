using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Automations;
using TryCourier.Models.Automations.Runs;

namespace TryCourier.Services.Automations;

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
    public async Task<AutomationRunListResponse> List(
        RunListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AutomationRunStepsResponse> ListSteps(
        RunListStepsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListSteps(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AutomationRunStepsResponse> ListSteps(
        string id,
        RunListStepsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListSteps(parameters with { ID = id }, cancellationToken);
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
    public async Task<HttpResponse<AutomationRunListResponse>> List(
        RunListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RunListParams> request = new() { Method = HttpMethod.Get, Params = parameters };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var automationRunListResponse = await response
                    .Deserialize<AutomationRunListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    automationRunListResponse.Validate();
                }
                return automationRunListResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AutomationRunStepsResponse>> ListSteps(
        RunListStepsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CourierInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RunListStepsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var automationRunStepsResponse = await response
                    .Deserialize<AutomationRunStepsResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    automationRunStepsResponse.Validate();
                }
                return automationRunStepsResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AutomationRunStepsResponse>> ListSteps(
        string id,
        RunListStepsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListSteps(parameters with { ID = id }, cancellationToken);
    }
}
