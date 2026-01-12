using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Auth;

namespace Courier.Services;

/// <inheritdoc/>
public sealed class AuthService : IAuthService
{
    readonly Lazy<IAuthServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAuthServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IAuthService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AuthService(this._client.WithOptions(modifier));
    }

    public AuthService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AuthServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<AuthIssueTokenResponse> IssueToken(
        AuthIssueTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.IssueToken(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AuthServiceWithRawResponse : IAuthServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAuthServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AuthServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AuthServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AuthIssueTokenResponse>> IssueToken(
        AuthIssueTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AuthIssueTokenParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<AuthIssueTokenResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
