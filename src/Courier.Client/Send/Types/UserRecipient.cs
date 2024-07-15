using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record UserRecipient
{
    /// <summary>
    /// Use `tenant_id` instad.
    /// </summary>
    [JsonPropertyName("account_id")]
    public string? AccountId { get; init; }

    /// <summary>
    /// Context information such as tenant_id to send the notification with.
    /// </summary>
    [JsonPropertyName("context")]
    public MessageContext? Context { get; init; }

    [JsonPropertyName("data")]
    public Dictionary<string, object>? Data { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// The user's preferred ISO 639-1 language code.
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; init; }

    [JsonPropertyName("user_id")]
    public string? UserId { get; init; }

    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; init; }

    [JsonPropertyName("preferences")]
    public IProfilePreferences? Preferences { get; init; }

    /// <summary>
    /// An id of a tenant, [see tenants api docs](https://www.courier.com/docs/reference/tenants).
    /// Will load brand, default preferences and any other base context data associated with this tenant.
    /// </summary>
    [JsonPropertyName("tenant_id")]
    public string? TenantId { get; init; }
}
