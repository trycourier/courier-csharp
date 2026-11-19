using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Feedback;

namespace TryCourier.Services;

/// <inheritdoc/>
public sealed class FeedbackService : IFeedbackService
{
    readonly Lazy<IFeedbackServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFeedbackServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IFeedbackService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FeedbackService(this._client.WithOptions(modifier));
    }

    public FeedbackService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FeedbackServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<FeedbackCreateResponse> Create(
        FeedbackCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class FeedbackServiceWithRawResponse : IFeedbackServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFeedbackServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FeedbackServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FeedbackServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FeedbackCreateResponse>> Create(
        FeedbackCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FeedbackCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var feedback = await response
                    .Deserialize<FeedbackCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    feedback.Validate();
                }
                return feedback;
            }
        );
    }
}
