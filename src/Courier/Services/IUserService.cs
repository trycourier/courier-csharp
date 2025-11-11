using System;
using Courier.Core;
using Users = Courier.Services.Users;

namespace Courier.Services;

public interface IUserService
{
    IUserService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Users::IPreferenceService Preferences { get; }

    Users::ITenantService Tenants { get; }

    Users::ITokenService Tokens { get; }
}
