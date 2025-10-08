using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Notifications.NotificationListResponseProperties.ResultProperties.TagsProperties;
using Generic = System.Collections.Generic;

namespace Courier.Models.Notifications.NotificationListResponseProperties.ResultProperties;

[JsonConverter(typeof(ModelConverter<Tags>))]
public sealed record class Tags : ModelBase, IFromRaw<Tags>
{
    public required Generic::List<Data> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Generic::List<Data>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentNullException("data")
                );
        }
        set
        {
            this.Properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public Tags() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tags(Generic::Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Tags FromRawUnchecked(Generic::Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Tags(Generic::List<Data> data)
        : this()
    {
        this.Data = data;
    }
}
