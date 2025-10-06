using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Profiles.Lists.ListSubscribeResponseProperties;

namespace Courier.Models.Profiles.Lists;

[JsonConverter(typeof(ModelConverter<ListSubscribeResponse>))]
public sealed record class ListSubscribeResponse : ModelBase, IFromRaw<ListSubscribeResponse>
{
    public required ApiEnum<string, Status> Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Status>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Status.Validate();
    }

    public ListSubscribeResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListSubscribeResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ListSubscribeResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public ListSubscribeResponse(ApiEnum<string, Status> status)
        : this()
    {
        this.Status = status;
    }
}
