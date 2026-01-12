using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Users.Tokens;

namespace Courier.Services.Users;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITokenServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITokenService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get single token available for a `:token`
    /// </summary>
    Task<TokenRetrieveResponse> Retrieve(
        TokenRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TokenRetrieveParams, CancellationToken)"/>
    Task<TokenRetrieveResponse> Retrieve(
        string token,
        TokenRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Apply a JSON Patch (RFC 6902) to the specified token.
    /// </summary>
    Task Update(TokenUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(TokenUpdateParams, CancellationToken)"/>
    Task Update(
        string token,
        TokenUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Gets all tokens available for a :user_id
    /// </summary>
    Task<TokenListResponse> List(
        TokenListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TokenListParams, CancellationToken)"/>
    Task<TokenListResponse> List(
        string userID,
        TokenListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete User Token
    /// </summary>
    Task Delete(TokenDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(TokenDeleteParams, CancellationToken)"/>
    Task Delete(
        string token,
        TokenDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Adds multiple tokens to a user and overwrites matching existing tokens.
    /// </summary>
    Task AddMultiple(
        TokenAddMultipleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="AddMultiple(TokenAddMultipleParams, CancellationToken)"/>
    Task AddMultiple(
        string userID,
        TokenAddMultipleParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Adds a single token to a user and overwrites a matching existing token.
    /// </summary>
    Task AddSingle(TokenAddSingleParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="AddSingle(TokenAddSingleParams, CancellationToken)"/>
    Task AddSingle(
        string token,
        TokenAddSingleParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITokenService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITokenServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITokenServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /users/{user_id}/tokens/{token}`, but is otherwise the
    /// same as <see cref="ITokenService.Retrieve(TokenRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TokenRetrieveResponse>> Retrieve(
        TokenRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TokenRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<TokenRetrieveResponse>> Retrieve(
        string token,
        TokenRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /users/{user_id}/tokens/{token}`, but is otherwise the
    /// same as <see cref="ITokenService.Update(TokenUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        TokenUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TokenUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string token,
        TokenUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /users/{user_id}/tokens`, but is otherwise the
    /// same as <see cref="ITokenService.List(TokenListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TokenListResponse>> List(
        TokenListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TokenListParams, CancellationToken)"/>
    Task<HttpResponse<TokenListResponse>> List(
        string userID,
        TokenListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /users/{user_id}/tokens/{token}`, but is otherwise the
    /// same as <see cref="ITokenService.Delete(TokenDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        TokenDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TokenDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string token,
        TokenDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /users/{user_id}/tokens`, but is otherwise the
    /// same as <see cref="ITokenService.AddMultiple(TokenAddMultipleParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> AddMultiple(
        TokenAddMultipleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="AddMultiple(TokenAddMultipleParams, CancellationToken)"/>
    Task<HttpResponse> AddMultiple(
        string userID,
        TokenAddMultipleParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /users/{user_id}/tokens/{token}`, but is otherwise the
    /// same as <see cref="ITokenService.AddSingle(TokenAddSingleParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> AddSingle(
        TokenAddSingleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="AddSingle(TokenAddSingleParams, CancellationToken)"/>
    Task<HttpResponse> AddSingle(
        string token,
        TokenAddSingleParams parameters,
        CancellationToken cancellationToken = default
    );
}
