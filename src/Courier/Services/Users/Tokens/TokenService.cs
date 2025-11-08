using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Users.Tokens;

namespace Courier.Services.Users.Tokens;

public sealed class TokenService : ITokenService
{
    public ITokenService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TokenService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public TokenService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<TokenRetrieveResponse> Retrieve(
        TokenRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TokenRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var token = await response
            .Deserialize<TokenRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            token.Validate();
        }
        return token;
    }

    public async Task Update(
        TokenUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TokenUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<List<UserToken>> List(
        TokenListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TokenListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var userTokens = await response
            .Deserialize<List<UserToken>>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            foreach (var item in userTokens)
            {
                item.Validate();
            }
        }
        return userTokens;
    }

    public async Task Delete(
        TokenDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TokenDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task AddMultiple(
        TokenAddMultipleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TokenAddMultipleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task AddSingle(
        TokenAddSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TokenAddSingleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
