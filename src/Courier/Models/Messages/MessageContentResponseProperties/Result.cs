using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Messages.MessageContentResponseProperties.ResultProperties;

namespace Courier.Models.Messages.MessageContentResponseProperties;

[JsonConverter(typeof(ModelConverter<Result>))]
public sealed record class Result : ModelBase, IFromRaw<Result>
{
    /// <summary>
    /// The channel used for rendering the message.
    /// </summary>
    public required string Channel
    {
        get
        {
            if (!this.Properties.TryGetValue("channel", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'channel' cannot be null",
                    new ArgumentOutOfRangeException("channel", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'channel' cannot be null",
                    new ArgumentNullException("channel")
                );
        }
        set
        {
            this.Properties["channel"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The ID of channel used for rendering the message.
    /// </summary>
    public required string ChannelID
    {
        get
        {
            if (!this.Properties.TryGetValue("channel_id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'channel_id' cannot be null",
                    new ArgumentOutOfRangeException("channel_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'channel_id' cannot be null",
                    new ArgumentNullException("channel_id")
                );
        }
        set
        {
            this.Properties["channel_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Content details of the rendered message.
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
        _ = this.Channel;
        _ = this.ChannelID;
        this.Content.Validate();
    }

    public Result() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Result FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
