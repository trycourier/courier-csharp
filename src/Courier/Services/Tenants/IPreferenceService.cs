using System;
using Courier.Core;
using Courier.Services.Tenants.Preferences;

namespace Courier.Services.Tenants;

public interface IPreferenceService
{
    IPreferenceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IItemService Items { get; }
}
