using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Audiences;
using Courier.Models.Notifications.NotificationListResponseProperties;

namespace Courier.Models.Notifications;

[JsonConverter(typeof(ModelConverter<NotificationListResponse>))]
public sealed record class NotificationListResponse : ModelBase, IFromRaw<NotificationListResponse>
{
    public required Paging Paging
    {
        get
        {
            if (!this.Properties.TryGetValue("paging", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'paging' cannot be null",
                    new ArgumentOutOfRangeException("paging", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Paging>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'paging' cannot be null",
                    new ArgumentNullException("paging")
                );
        }
        set
        {
            this.Properties["paging"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
        this.Paging.Validate();
        foreach (var item in this.Results)
        {
            item.Validate();
        }
    }

    public NotificationListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationListResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NotificationListResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
