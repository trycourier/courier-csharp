using System;
using TryCourier.Core;
using TryCourier.Services.Notifications.Previews;

namespace TryCourier.Services.Notifications;

/// <inheritdoc/>
public sealed class PreviewService : IPreviewService
{
    readonly Lazy<IPreviewServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPreviewServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IPreviewService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PreviewService(this._client.WithOptions(modifier));
    }

    public PreviewService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PreviewServiceWithRawResponse(client.WithRawResponse));
        _runs = new(() => new RunService(client));
    }

    readonly Lazy<IRunService> _runs;
    public IRunService Runs
    {
        get { return _runs.Value; }
    }
}

/// <inheritdoc/>
public sealed class PreviewServiceWithRawResponse : IPreviewServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPreviewServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PreviewServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PreviewServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;

        _runs = new(() => new RunServiceWithRawResponse(client));
    }

    readonly Lazy<IRunServiceWithRawResponse> _runs;
    public IRunServiceWithRawResponse Runs
    {
        get { return _runs.Value; }
    }
}
