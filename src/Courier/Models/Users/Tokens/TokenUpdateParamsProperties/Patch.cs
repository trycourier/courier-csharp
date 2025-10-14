using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Users.Tokens.TokenUpdateParamsProperties;

[JsonConverter(typeof(ModelConverter<Patch>))]
public sealed record class Patch : ModelBase, IFromRaw<Patch>
{
    /// <summary>
    /// The operation to perform.
    /// </summary>
    public required string Op
    {
        get
        {
            if (!this.Properties.TryGetValue("op", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'op' cannot be null",
                    new ArgumentOutOfRangeException("op", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'op' cannot be null",
                    new ArgumentNullException("op")
                );
        }
        set
        {
            this.Properties["op"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The JSON path specifying the part of the profile to operate on.
    /// </summary>
    public required string Path
    {
        get
        {
            if (!this.Properties.TryGetValue("path", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'path' cannot be null",
                    new ArgumentOutOfRangeException("path", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'path' cannot be null",
                    new ArgumentNullException("path")
                );
        }
        set
        {
            this.Properties["path"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The value for the operation.
    /// </summary>
    public string? Value
    {
        get
        {
            if (!this.Properties.TryGetValue("value", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Op;
        _ = this.Path;
        _ = this.Value;
    }

    public Patch() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Patch(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Patch FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
