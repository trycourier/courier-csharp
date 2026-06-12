using System;
using Courier.Core;
using Courier.Services.Digests;

namespace Courier.Services;

/// <inheritdoc/>
public sealed class DigestService : IDigestService
{
    readonly Lazy<IDigestServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDigestServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IDigestService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DigestService(this._client.WithOptions(modifier));
    }

    public DigestService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DigestServiceWithRawResponse(client.WithRawResponse));
        _schedules = new(() => new ScheduleService(client));
    }

    readonly Lazy<IScheduleService> _schedules;
    public IScheduleService Schedules
    {
        get { return _schedules.Value; }
    }
}

/// <inheritdoc/>
public sealed class DigestServiceWithRawResponse : IDigestServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDigestServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DigestServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DigestServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;

        _schedules = new(() => new ScheduleServiceWithRawResponse(client));
    }

    readonly Lazy<IScheduleServiceWithRawResponse> _schedules;
    public IScheduleServiceWithRawResponse Schedules
    {
        get { return _schedules.Value; }
    }
}
