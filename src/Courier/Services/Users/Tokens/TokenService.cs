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
        var token = await response.Deserialize<TokenRetrieveResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            token.Validate();
        }
        return token;
    }

    public async Task Update(TokenUpdateParams parameters)
    {
        HttpRequest<TokenUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }

    public async Task<List<UserToken>> List(TokenListParams parameters)
    {
        HttpRequest<TokenListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var userTokens = await response.Deserialize<List<UserToken>>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            foreach (var item in userTokens)
            {
                item.Validate();
            }
        }
        return userTokens;
    }

    public async Task Delete(TokenDeleteParams parameters)
    {
        HttpRequest<TokenDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }

    public async Task AddMultiple(TokenAddMultipleParams parameters)
    {
        HttpRequest<TokenAddMultipleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }

    public async Task AddSingle(TokenAddSingleParams parameters)
    {
        HttpRequest<TokenAddSingleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }
}
