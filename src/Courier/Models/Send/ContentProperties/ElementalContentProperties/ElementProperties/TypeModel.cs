using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;
using TypeProperties = Courier.Models.Send.ContentProperties.ElementalContentProperties.ElementProperties.TypeProperties;

namespace Courier.Models.Send.ContentProperties.ElementalContentProperties.ElementProperties;

[JsonConverter(typeof(ModelConverter<TypeModel>))]
public sealed record class TypeModel : ModelBase, IFromRaw<TypeModel>
{
    public required ApiEnum<string, TypeProperties::TypeModel> Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, TypeProperties::TypeModel>>(
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
        this.Type.Validate();
    }

    public TypeModel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TypeModel(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TypeModel FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public TypeModel(ApiEnum<string, TypeProperties::TypeModel> type)
        : this()
    {
        this.Type = type;
    }
}
