using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;
using TypeProperties = Courier.Models.Send.ElementalNodeProperties.TypeProperties;

namespace Courier.Models.Send.ElementalNodeProperties;

[JsonConverter(typeof(ModelConverter<Type>))]
public sealed record class Type : ModelBase, IFromRaw<Type>
{
    public required ApiEnum<string, TypeProperties::Type> Type1
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, TypeProperties::Type>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Type1.Validate();
    }

    public Type() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Type(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Type FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Type(ApiEnum<string, TypeProperties::Type> type1)
        : this()
    {
        this.Type1 = type1;
    }
}
