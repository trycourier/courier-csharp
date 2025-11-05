using System;
using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Auth;

namespace Courier.Services.Auth;

public sealed class AuthService : IAuthService
{
    public IAuthService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AuthService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public AuthService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<AuthIssueTokenResponse> IssueToken(AuthIssueTokenParams parameters)
    {
        HttpRequest<AuthIssueTokenParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<AuthIssueTokenResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
