using Courier.Client.Core;

#nullable enable

namespace Courier.Client.Users;

public record UserPreferencesUpdateParams
{
    /// <summary>
    /// Update the preferences of a user for this specific tenant context.
    /// </summary>
    public string? TenantId { get; set; }

    public required TopicPreferenceUpdate Topic { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
