using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Profiles.Lists.ListDeleteResponseProperties;

namespace Courier.Models.Profiles.Lists;

[JsonConverter(typeof(ModelConverter<ListDeleteResponse>))]
public sealed record class ListDeleteResponse : ModelBase, IFromRaw<ListDeleteResponse>
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

    public ListDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListDeleteResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ListDeleteResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public ListDeleteResponse(ApiEnum<string, Status> status)
        : this()
    {
        this.Status = status;
    }
}
