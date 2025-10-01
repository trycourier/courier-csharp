using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Audiences.NestedFilterConfigProperties;

namespace Courier.Models.Audiences;

[JsonConverter(typeof(ModelConverter<NestedFilterConfig>))]
public sealed record class NestedFilterConfig : ModelBase, IFromRaw<NestedFilterConfig>
{
    /// <summary>
    /// The operator to use for filtering
    /// </summary>
    public required ApiEnum<string, Operator> Operator
    {
        get
        {
            if (!this.Properties.TryGetValue("operator", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'operator' cannot be null",
                    new ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["operator"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required List<FilterConfig> Rules
    {
        get
        {
            if (!this.Properties.TryGetValue("rules", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'rules' cannot be null",
                    new ArgumentOutOfRangeException("rules", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<FilterConfig>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'rules' cannot be null",
                    new ArgumentNullException("rules")
                );
        }
        set
        {
            this.Properties["rules"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Operator.Validate();
        foreach (var item in this.Rules)
        {
            item.Validate();
        }
    }

    public NestedFilterConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NestedFilterConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NestedFilterConfig FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
