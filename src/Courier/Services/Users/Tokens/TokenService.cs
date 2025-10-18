using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Users.Tokens;

namespace Courier.Services.Users.Tokens;

public sealed class TokenService : ITokenService
{
    readonly ICourierClient _client;

    public TokenService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<TokenRetrieveResponse> Retrieve(TokenRetrieveParams parameters)
    {
        HttpRequest<TokenRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<TokenRetrieveResponse>().ConfigureAwait(false);
    }

    public async Task Update(TokenUpdateParams parameters)
    {
        HttpRequest<TokenUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task<List<UserToken>> List(TokenListParams parameters)
    {
        HttpRequest<TokenListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<List<UserToken>>().ConfigureAwait(false);
    }

    public async Task Delete(TokenDeleteParams parameters)
    {
        HttpRequest<TokenDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task AddMultiple(TokenAddMultipleParams parameters)
    {
        HttpRequest<TokenAddMultipleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task AddSingle(TokenAddSingleParams parameters)
    {
        HttpRequest<TokenAddSingleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }
}
