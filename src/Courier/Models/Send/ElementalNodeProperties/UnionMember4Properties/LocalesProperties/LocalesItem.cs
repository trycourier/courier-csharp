using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Send.ElementalNodeProperties.UnionMember4Properties.LocalesProperties;

[JsonConverter(typeof(ModelConverter<LocalesItem>))]
public sealed record class LocalesItem : ModelBase, IFromRaw<LocalesItem>
{
    public required string Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'content' cannot be null",
                    new ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
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
        _ = this.Content;
    }

    public LocalesItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LocalesItem(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static LocalesItem FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public LocalesItem(string content)
        : this()
    {
        this.Content = content;
    }
}
