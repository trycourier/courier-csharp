using System.Collections.Generic;
using System.Threading.Tasks;
using Courier.Models.Users.Tokens;

namespace Courier.Services.Users.Tokens;

public interface ITokenService
{
    /// <summary>
    /// Apply a JSON Patch (RFC 6902) to the specified token.
    /// </summary>
    Task Update(TokenUpdateParams parameters);

    /// <summary>
    /// Gets all tokens available for a :user_id
    /// </summary>
    Task<List<UserToken>> List(TokenListParams parameters);

    /// <summary>
    /// Delete User Token
    /// </summary>
    Task Delete(TokenDeleteParams parameters);

    /// <summary>
    /// Adds multiple tokens to a user and overwrites matching existing tokens.
    /// </summary>
    Task AddMultiple(TokenAddMultipleParams parameters);

    /// <summary>
    /// Adds a single token to a user and overwrites a matching existing token.
    /// </summary>
    Task AddSingle(TokenAddSingleParams parameters);

    /// <summary>
    /// Get single token available for a `:token`
    /// </summary>
    Task<TokenRetrieveSingleResponse> RetrieveSingle(TokenRetrieveSingleParams parameters);
}
