using System;
using Courier.Core;
using Courier.Services.Tenants.Preferences.Items;

namespace Courier.Services.Tenants.Preferences;

public interface IPreferenceService
{
    IPreferenceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IItemService Items { get; }
}
