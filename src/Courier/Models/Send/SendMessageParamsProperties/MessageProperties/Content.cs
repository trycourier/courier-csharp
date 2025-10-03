using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Send.SendMessageParamsProperties.MessageProperties;

/// <summary>
/// Syntactic sugar to provide a fast shorthand for Courier Elemental Blocks.
/// </summary>
[JsonConverter(typeof(ModelConverter<Content>))]
public sealed record class Content : ModelBase, IFromRaw<Content>
{
    /// <summary>
    /// The text content displayed in the notification.
    /// </summary>
    public required string Body
    {
        get
        {
            if (!this.Properties.TryGetValue("body", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'body' cannot be null",
                    new ArgumentOutOfRangeException("body", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'body' cannot be null",
                    new ArgumentNullException("body")
                );
        }
        set
        {
            this.Properties["body"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Title/subject displayed by supported channels.
    /// </summary>
    public required string Title
    {
        get
        {
            if (!this.Properties.TryGetValue("title", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'title' cannot be null",
                    new ArgumentOutOfRangeException("title", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'title' cannot be null",
                    new ArgumentNullException("title")
                );
        }
        set
        {
            this.Properties["title"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Body;
        _ = this.Title;
    }

    public Content() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Content(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Content FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
