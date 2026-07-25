using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Users.Tokens;

namespace TryCourier.Services.Users;

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
    /// Returns one device token with its provider key, status and status reason, expiry
    /// date, and any properties stored alongside it.
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
    /// Applies a JSON Patch to a device token, changing its status, expiry, or
    /// properties without re-registering it.
    /// </summary>
    Task Update(TokenUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(TokenUpdateParams, CancellationToken)"/>
    Task Update(
        string token,
        TokenUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns every device token registered for a user, each with its provider key,
    /// status, and expiry date.
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
    /// Deletes one device token for a user, addressed by the token value, so push sends
    /// no longer target that device.
    /// </summary>
    Task Delete(TokenDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(TokenDeleteParams, CancellationToken)"/>
    Task Delete(
        string token,
        TokenDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Registers several device tokens for a user in one call, overwriting any stored
    /// token with a matching value.
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
    /// Registers one device token for a user against a provider key, overwriting the
    /// token if it already exists. Push sends resolve tokens per user.
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
    /// Returns a raw HTTP response for <c>get /users/{user_id}/tokens/{token}</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>patch /users/{user_id}/tokens/{token}</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>get /users/{user_id}/tokens</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>delete /users/{user_id}/tokens/{token}</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>put /users/{user_id}/tokens</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>put /users/{user_id}/tokens/{token}</c>, but is otherwise the
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
