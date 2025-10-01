using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Audiences;

[JsonConverter(typeof(ModelConverter<Paging>))]
public sealed record class Paging : ModelBase, IFromRaw<Paging>
{
    public required bool More
    {
        get
        {
            if (!this.Properties.TryGetValue("more", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'more' cannot be null",
                    new ArgumentOutOfRangeException("more", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["more"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Cursor
    {
        get
        {
            if (!this.Properties.TryGetValue("cursor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["cursor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.More;
        _ = this.Cursor;
    }

    public Paging() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Paging(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Paging FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Paging(bool more)
        : this()
    {
        this.More = more;
    }
}
