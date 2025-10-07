using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Models.Brands.BrandSettingsProperties.EmailProperties;

namespace Courier.Models.Brands.BrandSettingsProperties;

[JsonConverter(typeof(ModelConverter<Email>))]
public sealed record class Email : ModelBase, IFromRaw<Email>
{
    public Footer? Footer
    {
        get
        {
            if (!this.Properties.TryGetValue("footer", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Footer?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["footer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Head? Head
    {
        get
        {
            if (!this.Properties.TryGetValue("head", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Head?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["head"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Header? Header
    {
        get
        {
            if (!this.Properties.TryGetValue("header", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Header?>(element, ModelBase.SerializerOptions);
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

    public Email() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Email(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Email FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
