using System;
using Courier.Core;
using Users = Courier.Services.Users;

namespace Courier.Services;

/// <inheritdoc/>
public sealed class UserService : IUserService
{
    /// <inheritdoc/>
    public IUserService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UserService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public UserService(ICourierClient client)
    {
        _client = client;
        _preferences = new(() => new Users::PreferenceService(client));
        _tenants = new(() => new Users::TenantService(client));
        _tokens = new(() => new Users::TokenService(client));
    }

    readonly Lazy<Users::IPreferenceService> _preferences;
    public Users::IPreferenceService Preferences
    {
        get { return _preferences.Value; }
    }

    readonly Lazy<Users::ITenantService> _tenants;
    public Users::ITenantService Tenants
    {
        get { return _tenants.Value; }
    }

    readonly Lazy<Users::ITokenService> _tokens;
    public Users::ITokenService Tokens
    {
        get { return _tokens.Value; }
    }
}
