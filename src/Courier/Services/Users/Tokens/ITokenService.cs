using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Users.Tokens;

namespace Courier.Services.Users.Tokens;

public interface ITokenService
{
    ITokenService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get single token available for a `:token`
    /// </summary>
    Task<TokenRetrieveResponse> Retrieve(
        TokenRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Apply a JSON Patch (RFC 6902) to the specified token.
    /// </summary>
    Task Update(TokenUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets all tokens available for a :user_id
    /// </summary>
    Task<List<UserToken>> List(
        TokenListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete User Token
    /// </summary>
    Task Delete(TokenDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds multiple tokens to a user and overwrites matching existing tokens.
    /// </summary>
    Task AddMultiple(
        TokenAddMultipleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Adds a single token to a user and overwrites a matching existing token.
    /// </summary>
    Task AddSingle(TokenAddSingleParams parameters, CancellationToken cancellationToken = default);
}
