using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Users.Tokens;

namespace Courier.Services.Users;

/// <inheritdoc />
public sealed class TokenService : ITokenService
{
    /// <inheritdoc/>
    public ITokenService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TokenService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public TokenService(ICourierClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<TokenRetrieveResponse> Retrieve(
        TokenRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Token == null)
        {
            throw new CourierInvalidDataException("'parameters.Token' cannot be null");
        }

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

    /// <inheritdoc/>
    public async Task<TokenRetrieveResponse> Retrieve(
        string token,
        TokenRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Retrieve(parameters with { Token = token }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        TokenUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Token == null)
        {
            throw new CourierInvalidDataException("'parameters.Token' cannot be null");
        }

        HttpRequest<TokenUpdateParams> request = new()
        {
            Method = CourierClient.PatchMethod,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Update(
        string token,
        TokenUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Update(parameters with { Token = token }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<UserToken>> List(
        TokenListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new CourierInvalidDataException("'parameters.UserID' cannot be null");
        }

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

    /// <inheritdoc/>
    public async Task<List<UserToken>> List(
        string userID,
        TokenListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        TokenDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Token == null)
        {
            throw new CourierInvalidDataException("'parameters.Token' cannot be null");
        }

        HttpRequest<TokenDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string token,
        TokenDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { Token = token }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task AddMultiple(
        TokenAddMultipleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new CourierInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<TokenAddMultipleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task AddMultiple(
        string userID,
        TokenAddMultipleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.AddMultiple(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task AddSingle(
        TokenAddSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Token == null)
        {
            throw new CourierInvalidDataException("'parameters.Token' cannot be null");
        }

        HttpRequest<TokenAddSingleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task AddSingle(
        string token,
        TokenAddSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.AddSingle(parameters with { Token = token }, cancellationToken);
    }
}
