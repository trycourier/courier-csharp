using Courier.Client.Core;

#nullable enable

namespace Courier.Client.Users;

public record UserPreferencesParams
{
    /// <summary>
    /// Query the preferences of a user for this specific tenant context.
    /// </summary>
    public string? TenantId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
