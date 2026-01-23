using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<AudienceFilter, AudienceFilterFromRaw>))]
public sealed record class AudienceFilter : JsonModel
{
    /// <summary>
    /// Send to users only if they are member of the account
    /// </summary>
    public required ApiEnum<string, Operator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Operator>>("operator");
        }
        init { this._rawData.Set("operator", value); }
    }

    public required ApiEnum<string, Path> Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Path>>("path");
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

    public AudienceFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AudienceFilter(AudienceFilter audienceFilter)
        : base(audienceFilter) { }
#pragma warning restore CS8618

    public AudienceFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudienceFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AudienceFilterFromRaw.FromRawUnchecked"/>
    public static AudienceFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AudienceFilterFromRaw : IFromRawJson<AudienceFilter>
{
    /// <inheritdoc/>
    public AudienceFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AudienceFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Send to users only if they are member of the account
/// </summary>
[JsonConverter(typeof(OperatorConverter))]
public enum Operator
{
    MemberOf,
}

sealed class OperatorConverter : JsonConverter<Operator>
{
    public override Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MEMBER_OF" => Operator.MemberOf,
            _ => (Operator)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Operator value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Operator.MemberOf => "MEMBER_OF",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(PathConverter))]
public enum Path
{
    AccountID,
}

sealed class PathConverter : JsonConverter<Path>
{
    public override Path Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_id" => Path.AccountID,
            _ => (Path)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Path value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Path.AccountID => "account_id",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
