using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Send.MessageProperties.ContentMessageProperties;

[JsonConverter(typeof(ModelConverter<IntersectionMember2>))]
public sealed record class IntersectionMember2 : ModelBase, IFromRaw<IntersectionMember2>
{
    /// <summary>
    /// Describes the content of the message in a way that will work for email, push,
    ///  chat, or any channel. Either this or template must be specified.
    /// </summary>
    public required Content Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'content' cannot be null",
                    new ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Content>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'content' cannot be null",
                    new ArgumentNullException("content")
                );
        }
        set
        {
            this.Properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Content.Validate();
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
    public IntersectionMember2(Content content)
        : this()
    {
        this.Content = content;
    }
}
