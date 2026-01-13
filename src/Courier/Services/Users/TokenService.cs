using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Users.Tokens;

namespace Courier.Services.Users;

/// <inheritdoc/>
public sealed class TokenService : ITokenService
{
    readonly Lazy<ITokenServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITokenServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public ITokenService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TokenService(this._client.WithOptions(modifier));
    }

    public TokenService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TokenServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<TokenRetrieveResponse> Retrieve(
        TokenRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TokenRetrieveResponse> Retrieve(
        string token,
        TokenRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { Token = token }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Update(TokenUpdateParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        string token,
        TokenUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Update(parameters with { Token = token }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TokenListResponse> List(
        TokenListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TokenListResponse> List(
        string userID,
        TokenListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(TokenDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string token,
        TokenDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { Token = token }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task AddMultiple(
        TokenAddMultipleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.AddMultiple(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task AddMultiple(
        string userID,
        TokenAddMultipleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.AddMultiple(parameters with { UserID = userID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task AddSingle(
        TokenAddSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.AddSingle(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task AddSingle(
        string token,
        TokenAddSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.AddSingle(parameters with { Token = token }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TokenServiceWithRawResponse : ITokenServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITokenServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TokenServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TokenServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TokenRetrieveResponse>> Retrieve(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<TokenRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TokenRetrieveResponse>> Retrieve(
        string token,
        TokenRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { Token = token }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        string token,
        TokenUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { Token = token }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TokenListResponse>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var tokens = await response
                    .Deserialize<TokenListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    tokens.Validate();
                }
                return tokens;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TokenListResponse>> List(
        string userID,
        TokenListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string token,
        TokenDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { Token = token }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> AddMultiple(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> AddMultiple(
        string userID,
        TokenAddMultipleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.AddMultiple(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> AddSingle(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> AddSingle(
        string token,
        TokenAddSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.AddSingle(parameters with { Token = token }, cancellationToken);
    }
}
