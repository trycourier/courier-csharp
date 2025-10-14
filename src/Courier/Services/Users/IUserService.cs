using Courier.Services.Users.Preferences;
using Courier.Services.Users.Tenants;
using Courier.Services.Users.Tokens;

namespace Courier.Services.Users;

public interface IUserService
{
    IPreferenceService Preferences { get; }

    ITenantService Tenants { get; }

    ITokenService Tokens { get; }
}
