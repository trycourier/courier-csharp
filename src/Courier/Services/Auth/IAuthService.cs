using System.Threading.Tasks;
using Courier.Models.Auth;

namespace Courier.Services.Auth;

public interface IAuthService
{
    /// <summary>
    /// Returns a new access token.
    /// </summary>
    Task<AuthIssueTokenResponse> IssueToken(AuthIssueTokenParams parameters);
}
