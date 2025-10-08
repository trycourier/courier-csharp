using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Messages.MessageContentResponseProperties;
using Generic = System.Collections.Generic;

namespace Courier.Models.Messages;

[JsonConverter(typeof(ModelConverter<MessageContentResponse>))]
public sealed record class MessageContentResponse : ModelBase, IFromRaw<MessageContentResponse>
{
    /// <summary>
    /// An array of render output of a previously sent message.
    /// </summary>
    public required Generic::List<Result> Results
    {
        get
        {
            if (!this.Properties.TryGetValue("results", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'results' cannot be null",
                    new ArgumentOutOfRangeException("results", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Generic::List<Result>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'results' cannot be null",
                    new ArgumentNullException("results")
                );
        }
        set
        {
            this.Properties["results"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Results)
        {
            item.Validate();
        }
    }

    public MessageContentResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageContentResponse(Generic::Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MessageContentResponse FromRawUnchecked(
        Generic::Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public MessageContentResponse(Generic::List<Result> results)
        : this()
    {
        this.Results = results;
    }
}
