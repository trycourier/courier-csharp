using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Auth;

namespace Courier.Services;

/// <inheritdoc />
public sealed class AuthService : IAuthService
{
    /// <inheritdoc/>
    public IAuthService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AuthService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public AuthService(ICourierClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<AuthIssueTokenResponse> IssueToken(
        AuthIssueTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AuthIssueTokenParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<AuthIssueTokenResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
