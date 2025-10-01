using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Send.MessageProperties.TemplateMessageProperties;

[JsonConverter(typeof(ModelConverter<IntersectionMember2>))]
public sealed record class IntersectionMember2 : ModelBase, IFromRaw<IntersectionMember2>
{
    /// <summary>
    /// The id of the notification template to be rendered and sent to the recipient(s).
    ///  This field or the content field must be supplied.
    /// </summary>
    public required string Template
    {
        get
        {
            if (!this.Properties.TryGetValue("template", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'template' cannot be null",
                    new ArgumentOutOfRangeException("template", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'template' cannot be null",
                    new ArgumentNullException("template")
                );
        }
        set
        {
            this.Properties["template"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Template;
    }

    public IntersectionMember2() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember2(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static IntersectionMember2 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public IntersectionMember2(string template)
        : this()
    {
        this.Template = template;
    }
}
