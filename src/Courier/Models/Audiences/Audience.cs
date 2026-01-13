using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Audiences;

[JsonConverter(typeof(JsonModelConverter<Audience, AudienceFromRaw>))]
public sealed record class Audience : JsonModel
{
    /// <summary>
    /// A unique identifier representing the audience_id
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// A description of the audience
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The name of the audience
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required string UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Filter that contains an array of FilterConfig items
    /// </summary>
    public Filter? Filter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Filter>("filter");
        }
        init { this._rawData.Set("filter", value); }
    }

    /// <summary>
    /// The logical operator (AND/OR) for the top-level filter
    /// </summary>
    public ApiEnum<string, AudienceOperator>? Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AudienceOperator>>("operator");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("operator", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Name;
        _ = this.UpdatedAt;
        this.Filter?.Validate();
        this.Operator?.Validate();
    }

    public Audience() { }

    public Audience(Audience audience)
        : base(audience) { }

    public Audience(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Audience(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AudienceFromRaw.FromRawUnchecked"/>
    public static Audience FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AudienceFromRaw : IFromRawJson<Audience>
{
    /// <inheritdoc/>
    public Audience FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Audience.FromRawUnchecked(rawData);
}

/// <summary>
/// The logical operator (AND/OR) for the top-level filter
/// </summary>
[JsonConverter(typeof(AudienceOperatorConverter))]
public enum AudienceOperator
{
    And,
    Or,
}

sealed class AudienceOperatorConverter : JsonConverter<AudienceOperator>
{
    public override AudienceOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AND" => AudienceOperator.And,
            "OR" => AudienceOperator.Or,
            _ => (AudienceOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AudienceOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AudienceOperator.And => "AND",
                AudienceOperator.Or => "OR",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
