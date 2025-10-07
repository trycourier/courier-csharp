using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Models.Tenants.Templates.ElementalContentProperties.ElementProperties.UnionMember4Properties;
using Courier.Models.Tenants.Templates.ElementalContentProperties.ElementProperties.UnionMember4Properties.LocalesProperties;

namespace Courier.Models.Tenants.Templates.ElementalContentProperties.ElementProperties;

[JsonConverter(typeof(ModelConverter<UnionMember4>))]
public sealed record class UnionMember4 : ModelBase, IFromRaw<UnionMember4>
{
    /// <summary>
    /// A unique id used to identify the action when it is executed.
    /// </summary>
    public string? ActionID
    {
        get
        {
            if (!this.Properties.TryGetValue("action_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["action_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The alignment of the action button. Defaults to "center".
    /// </summary>
    public ApiEnum<string, Alignment>? Align
    {
        get
        {
            if (!this.Properties.TryGetValue("align", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Alignment>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["align"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The background color of the action button.
    /// </summary>
    public string? BackgroundColor
    {
        get
        {
            if (!this.Properties.TryGetValue("background_color", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["background_color"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The text content of the action shown to the user.
    /// </summary>
    public string? Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The target URL of the action.
    /// </summary>
    public string? Href
    {
        get
        {
            if (!this.Properties.TryGetValue("href", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["href"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Region specific content. See [locales docs](https://www.courier.com/docs/platform/content/elemental/locales/)
    /// for more details.
    /// </summary>
    public Dictionary<string, LocalesItem>? Locales
    {
        get
        {
            if (!this.Properties.TryGetValue("locales", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, LocalesItem>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["locales"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Defaults to `button`.
    /// </summary>
    public ApiEnum<string, Style>? Style
    {
        get
        {
            if (!this.Properties.TryGetValue("style", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Style>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["style"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, Type>? Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Type>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ActionID;
        this.Align?.Validate();
        _ = this.BackgroundColor;
        _ = this.Content;
        _ = this.Href;
        if (this.Locales != null)
        {
            foreach (var item in this.Locales.Values)
            {
                item.Validate();
            }
        }
        this.Style?.Validate();
        this.Type?.Validate();
    }

    public UnionMember4() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember4(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UnionMember4 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
