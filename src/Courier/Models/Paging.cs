using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<Paging, PagingFromRaw>))]
public sealed record class Paging : JsonModel
{
    public required bool More
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("more");
        }
        init { this._rawData.Set("more", value); }
    }

    public string? Cursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cursor");
        }
        init { this._rawData.Set("cursor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.More;
        _ = this.Cursor;
    }

    public Paging() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Paging(Paging paging)
        : base(paging) { }
#pragma warning restore CS8618

    public Paging(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Paging(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PagingFromRaw.FromRawUnchecked"/>
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

class PagingFromRaw : IFromRawJson<Paging>
{
    /// <inheritdoc/>
    public Paging FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Paging.FromRawUnchecked(rawData);
}
