using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Tenants.Templates.TemplateListResponseProperties.ItemProperties.IntersectionMember1Properties;

/// <summary>
/// The template's data containing it's routing configs
/// </summary>
[JsonConverter(typeof(ModelConverter<Data>))]
public sealed record class Data : ModelBase, IFromRaw<Data>
{
    public required MessageRouting Routing
    {
        get
        {
            if (!this.Properties.TryGetValue("routing", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'routing' cannot be null",
                    new ArgumentOutOfRangeException("routing", "Missing required argument")
                );

            return JsonSerializer.Deserialize<MessageRouting>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'routing' cannot be null",
                    new ArgumentNullException("routing")
                );
        }
        set
        {
            this.Properties["routing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Routing.Validate();
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Data FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Data(MessageRouting routing)
        : this()
    {
        this.Routing = routing;
    }
}
