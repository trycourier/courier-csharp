using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<EmailHead>))]
public sealed record class EmailHead : ModelBase, IFromRaw<EmailHead>
{
    public required bool InheritDefault
    {
        get
        {
            if (!this.Properties.TryGetValue("inheritDefault", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'inheritDefault' cannot be null",
                    new ArgumentOutOfRangeException("inheritDefault", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["inheritDefault"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public override void Validate()
    {
        _ = this.InheritDefault;
        _ = this.Content;
    }

    public EmailHead() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailHead(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static EmailHead FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public EmailHead(bool inheritDefault)
        : this()
    {
        this.InheritDefault = inheritDefault;
    }
}
