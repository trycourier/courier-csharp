using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Send;

[JsonConverter(typeof(ModelConverter<MessageContext>))]
public sealed record class MessageContext : ModelBase, IFromRaw<MessageContext>
{
    /// <summary>
    /// An id of a tenant, see [tenants api docs](https://www.courier.com/docs/reference/tenants/).
    ///  Will load brand, default preferences and any other base context data associated
    /// with this tenant.
    /// </summary>
    public string? TenantID
    {
        get
        {
            if (!this.Properties.TryGetValue("tenant_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["tenant_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.TenantID;
    }

    public MessageContext() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageContext(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MessageContext FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
