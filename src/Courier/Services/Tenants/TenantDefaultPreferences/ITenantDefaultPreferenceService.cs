using Courier.Services.Tenants.TenantDefaultPreferences.Items;

namespace Courier.Services.Tenants.TenantDefaultPreferences;

public interface ITenantDefaultPreferenceService
{
    IItemService Items { get; }
}
