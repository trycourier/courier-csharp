using System;
using Courier.Services.Users.Preferences;
using Courier.Services.Users.Tenants;
using Courier.Services.Users.Tokens;

namespace Courier.Services.Users;

public sealed class UserService : IUserService
{
    public UserService(ICourierClient client)
    {
        _preferences = new(() => new PreferenceService(client));
        _tenants = new(() => new TenantService(client));
        _tokens = new(() => new TokenService(client));
    }

    readonly Lazy<IPreferenceService> _preferences;
    public IPreferenceService Preferences
    {
        get { return _preferences.Value; }
    }

    readonly Lazy<ITenantService> _tenants;
    public ITenantService Tenants
    {
        get { return _tenants.Value; }
    }

    readonly Lazy<ITokenService> _tokens;
    public ITokenService Tokens
    {
        get { return _tokens.Value; }
    }
}
