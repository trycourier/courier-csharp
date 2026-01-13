using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<ListFilter, ListFilterFromRaw>))]
public sealed record class ListFilter : JsonModel
{
    /// <summary>
    /// Send to users only if they are member of the account
    /// </summary>
    public required ApiEnum<string, ListFilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ListFilterOperator>>("operator");
        }
        init { this._rawData.Set("operator", value); }
    }

    public required ApiEnum<string, ListFilterPath> Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ListFilterPath>>("path");
        }
        init { this._rawData.Set("path", value); }
    }

    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Operator.Validate();
        this.Path.Validate();
        _ = this.Value;
    }

    public ListFilter() { }

    public ListFilter(ListFilter listFilter)
        : base(listFilter) { }

    public ListFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ListFilterFromRaw.FromRawUnchecked"/>
    public static ListFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ListFilterFromRaw : IFromRawJson<ListFilter>
{
    /// <inheritdoc/>
    public ListFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ListFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Send to users only if they are member of the account
/// </summary>
[JsonConverter(typeof(ListFilterOperatorConverter))]
public enum ListFilterOperator
{
    MemberOf,
}

sealed class ListFilterOperatorConverter : JsonConverter<ListFilterOperator>
{
    public override ListFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MEMBER_OF" => ListFilterOperator.MemberOf,
            _ => (ListFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ListFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ListFilterOperator.MemberOf => "MEMBER_OF",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ListFilterPathConverter))]
public enum ListFilterPath
{
    AccountID,
}

sealed class ListFilterPathConverter : JsonConverter<ListFilterPath>
{
    public override ListFilterPath Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_id" => ListFilterPath.AccountID,
            _ => (ListFilterPath)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ListFilterPath value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ListFilterPath.AccountID => "account_id",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
