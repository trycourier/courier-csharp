using System;
using Courier.Core;
using Users = Courier.Services.Users;

namespace Courier.Services;

/// <inheritdoc/>
public sealed class UserService : IUserService
{
    readonly Lazy<IUserServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUserServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IUserService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UserService(this._client.WithOptions(modifier));
    }

    public UserService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new UserServiceWithRawResponse(client.WithRawResponse));
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

/// <inheritdoc/>
public sealed class UserServiceWithRawResponse : IUserServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUserServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UserServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UserServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;

        _preferences = new(() => new Users::PreferenceServiceWithRawResponse(client));
        _tenants = new(() => new Users::TenantServiceWithRawResponse(client));
        _tokens = new(() => new Users::TokenServiceWithRawResponse(client));
    }

    readonly Lazy<Users::IPreferenceServiceWithRawResponse> _preferences;
    public Users::IPreferenceServiceWithRawResponse Preferences
    {
        get { return _preferences.Value; }
    }

    readonly Lazy<Users::ITenantServiceWithRawResponse> _tenants;
    public Users::ITenantServiceWithRawResponse Tenants
    {
        get { return _tenants.Value; }
    }

    readonly Lazy<Users::ITokenServiceWithRawResponse> _tokens;
    public Users::ITokenServiceWithRawResponse Tokens
    {
        get { return _tokens.Value; }
    }
}
