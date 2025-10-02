using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationAddToBatchStepProperties.IntersectionMember1Properties.RetainProperties;
using System = System;

namespace Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationAddToBatchStepProperties.IntersectionMember1Properties;

/// <summary>
/// Defines what items should be retained and passed along to the next steps when
/// the batch is released
/// </summary>
[JsonConverter(typeof(ModelConverter<Retain>))]
public sealed record class Retain : ModelBase, IFromRaw<Retain>
{
    /// <summary>
    /// The number of records to keep in batch. Default is 10 and only configurable
    /// by requesting from support. When configurable minimum is 2 and maximum is 100.
    /// </summary>
    public required long Count
    {
        get
        {
            if (!this.Properties.TryGetValue("count", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'count' cannot be null",
                    new System::ArgumentOutOfRangeException("count", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["count"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Keep N number of notifications based on the type. First/Last N based on notification
    /// received. highest/lowest based on a scoring key providing in the data accessed
    /// by sort_key
    /// </summary>
    public required ApiEnum<string, Type> Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Type>>(
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

    /// <summary>
    /// Defines the data value data[sort_key] that is used to sort the stored items.
    /// Required when type is set to highest or lowest.
    /// </summary>
    public string? SortKey
    {
        get
        {
            if (!this.Properties.TryGetValue("sort_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["sort_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Count;
        this.Type.Validate();
        _ = this.SortKey;
    }

    public Retain() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Retain(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Retain FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
