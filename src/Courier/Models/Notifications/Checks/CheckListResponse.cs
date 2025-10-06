using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Notifications.Checks;

[JsonConverter(typeof(ModelConverter<CheckListResponse>))]
public sealed record class CheckListResponse : ModelBase, IFromRaw<CheckListResponse>
{
    public required List<Check> Checks
    {
        get
        {
            if (!this.Properties.TryGetValue("checks", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'checks' cannot be null",
                    new ArgumentOutOfRangeException("checks", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Check>>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'checks' cannot be null",
                    new ArgumentNullException("checks")
                );
        }
        set
        {
            this.Properties["checks"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Checks)
        {
            item.Validate();
        }
    }

    public CheckListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckListResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CheckListResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public CheckListResponse(List<Check> checks)
        : this()
    {
        this.Checks = checks;
    }
}
