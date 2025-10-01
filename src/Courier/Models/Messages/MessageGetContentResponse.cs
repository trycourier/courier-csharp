using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Messages.MessageGetContentResponseProperties;

namespace Courier.Models.Messages;

[JsonConverter(typeof(ModelConverter<MessageGetContentResponse>))]
public sealed record class MessageGetContentResponse
    : ModelBase,
        IFromRaw<MessageGetContentResponse>
{
    /// <summary>
    /// An array of render output of a previously sent message.
    /// </summary>
    public required List<Result> Results
    {
        get
        {
            if (!this.Properties.TryGetValue("results", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'results' cannot be null",
                    new ArgumentOutOfRangeException("results", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Result>>(element, ModelBase.SerializerOptions)
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

    public MessageGetContentResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageGetContentResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MessageGetContentResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public MessageGetContentResponse(List<Result> results)
        : this()
    {
        this.Results = results;
    }
}
