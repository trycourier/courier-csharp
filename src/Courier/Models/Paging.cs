using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<Paging>))]
public sealed record class Paging : ModelBase, IFromRaw<Paging>
{
    public required bool More
    {
        get
        {
            if (!this._rawData.TryGetValue("more", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'more' cannot be null",
                    new ArgumentOutOfRangeException("more", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["more"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Cursor
    {
        get
        {
            if (!this._rawData.TryGetValue("cursor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["cursor"] = JsonSerializer.SerializeToElement(
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

    public Paging(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Paging(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Paging FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Paging(bool more)
        : this()
    {
        this.More = more;
    }
}
