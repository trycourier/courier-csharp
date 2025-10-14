using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Models.BrandSettingsEmailProperties;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<BrandSettingsEmail>))]
public sealed record class BrandSettingsEmail : ModelBase, IFromRaw<BrandSettingsEmail>
{
    public EmailFooter? Footer
    {
        get
        {
            if (!this.Properties.TryGetValue("footer", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<EmailFooter?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["footer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public EmailHead? Head
    {
        get
        {
            if (!this.Properties.TryGetValue("head", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<EmailHead?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["head"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public EmailHeader? Header
    {
        get
        {
            if (!this.Properties.TryGetValue("header", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<EmailHeader?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["header"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TemplateOverride? TemplateOverride
    {
        get
        {
            if (!this.Properties.TryGetValue("templateOverride", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<TemplateOverride?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["templateOverride"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Footer?.Validate();
        this.Head?.Validate();
        this.Header?.Validate();
        this.TemplateOverride?.Validate();
    }

    public BrandSettingsEmail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandSettingsEmail(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BrandSettingsEmail FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
