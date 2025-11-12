using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Auth;

namespace Courier.Services;

public interface IAuthService
{
    IAuthService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a new access token.
    /// </summary>
    Task<AuthIssueTokenResponse> IssueToken(
        AuthIssueTokenParams parameters,
        CancellationToken cancellationToken = default
    );
}
