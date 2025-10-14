using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Auth;

namespace Courier.Services.Auth;

public sealed class AuthService : IAuthService
{
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
        return await response.Deserialize<AuthIssueTokenResponse>().ConfigureAwait(false);
    }
}
