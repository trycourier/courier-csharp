using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Auth;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAuthServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAuthService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a new access token.
    /// </summary>
    Task<AuthIssueTokenResponse> IssueToken(
        AuthIssueTokenParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAuthService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAuthServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAuthServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /auth/issue-token`, but is otherwise the
    /// same as <see cref="IAuthService.IssueToken(AuthIssueTokenParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AuthIssueTokenResponse>> IssueToken(
        AuthIssueTokenParams parameters,
        CancellationToken cancellationToken = default
    );
}
