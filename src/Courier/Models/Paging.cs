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
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "more"); }
        init { JsonModel.Set(this._rawData, "more", value); }
    }

    public string? Cursor
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "cursor"); }
        init { JsonModel.Set(this._rawData, "cursor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.More;
        _ = this.Cursor;
    }

    public Paging() { }

    public Paging(Paging paging)
        : base(paging) { }

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
