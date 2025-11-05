using System;
using Courier.Core;
using Courier.Services.Tenants.TenantDefaultPreferences.Items;

namespace Courier.Services.Tenants.TenantDefaultPreferences;

public interface ITenantDefaultPreferenceService
{
    ITenantDefaultPreferenceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IItemService Items { get; }
}
