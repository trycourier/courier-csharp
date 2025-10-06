using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Models.Lists.Subscriptions;

namespace Courier.Models.Bulk;

[JsonConverter(typeof(ModelConverter<InboundBulkMessageUser>))]
public sealed record class InboundBulkMessageUser : ModelBase, IFromRaw<InboundBulkMessageUser>
{
    public JsonElement? Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public RecipientPreferences? Preferences
    {
        get
        {
            if (!this.Properties.TryGetValue("preferences", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<RecipientPreferences?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["preferences"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement? Profile
    {
        get
        {
            if (!this.Properties.TryGetValue("profile", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["profile"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Recipient
    {
        get
        {
            if (!this.Properties.TryGetValue("recipient", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["recipient"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public UserRecipient? To
    {
        get
        {
            if (!this.Properties.TryGetValue("to", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<UserRecipient?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["to"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Data;
        this.Preferences?.Validate();
        _ = this.Profile;
        _ = this.Recipient;
        this.To?.Validate();
    }

    public InboundBulkMessageUser() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundBulkMessageUser(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static InboundBulkMessageUser FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
