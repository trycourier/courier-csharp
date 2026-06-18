using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Digests;
using TryCourier.Models.Digests.Schedules;

namespace TryCourier.Services.Digests;

/// <inheritdoc/>
public sealed class ScheduleService : IScheduleService
{
    readonly Lazy<IScheduleServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IScheduleServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IScheduleService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ScheduleService(this._client.WithOptions(modifier));
    }

    public ScheduleService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ScheduleServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<DigestInstanceListResponse> ListInstances(
        ScheduleListInstancesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListInstances(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DigestInstanceListResponse> ListInstances(
        string scheduleID,
        ScheduleListInstancesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListInstances(parameters with { ScheduleID = scheduleID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Release(
        ScheduleReleaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Release(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Release(
        string scheduleID,
        ScheduleReleaseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Release(parameters with { ScheduleID = scheduleID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ScheduleServiceWithRawResponse : IScheduleServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IScheduleServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ScheduleServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ScheduleServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DigestInstanceListResponse>> ListInstances(
        ScheduleListInstancesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ScheduleID == null)
        {
            throw new CourierInvalidDataException("'parameters.ScheduleID' cannot be null");
        }

        HttpRequest<ScheduleListInstancesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var digestInstanceListResponse = await response
                    .Deserialize<DigestInstanceListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    digestInstanceListResponse.Validate();
                }
                return digestInstanceListResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DigestInstanceListResponse>> ListInstances(
        string scheduleID,
        ScheduleListInstancesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListInstances(parameters with { ScheduleID = scheduleID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Release(
        ScheduleReleaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ScheduleID == null)
        {
            throw new CourierInvalidDataException("'parameters.ScheduleID' cannot be null");
        }

        HttpRequest<ScheduleReleaseParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Release(
        string scheduleID,
        ScheduleReleaseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Release(parameters with { ScheduleID = scheduleID }, cancellationToken);
    }
}
