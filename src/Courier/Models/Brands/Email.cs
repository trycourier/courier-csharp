using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<Email>))]
public sealed record class Email : ModelBase, IFromRaw<Email>
{
    public required JsonElement Footer
    {
        get
        {
            if (!this.Properties.TryGetValue("footer", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'footer' cannot be null",
                    new ArgumentOutOfRangeException("footer", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["footer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required JsonElement Header
    {
        get
        {
            if (!this.Properties.TryGetValue("header", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'header' cannot be null",
                    new ArgumentOutOfRangeException("header", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["header"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Footer;
        _ = this.Header;
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
