using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Audiences.FilterProperties;
using FilterVariants = Courier.Models.Audiences.FilterVariants;

namespace Courier.Models.Audiences;

/// <summary>
/// The operator to use for filtering
/// </summary>
[JsonConverter(typeof(FilterConverter))]
public abstract record class Filter
{
    internal Filter() { }

    public static implicit operator Filter(UnionMember0 value) =>
        new FilterVariants::UnionMember0(value);

    public static implicit operator Filter(NestedFilterConfig value) =>
        new FilterVariants::NestedFilterConfig(value);

    public bool TryPickUnionMember0([NotNullWhen(true)] out UnionMember0? value)
    {
        value = (this as FilterVariants::UnionMember0)?.Value;
        return value != null;
    }

    public bool TryPickNestedFilterConfig([NotNullWhen(true)] out NestedFilterConfig? value)
    {
        value = (this as FilterVariants::NestedFilterConfig)?.Value;
        return value != null;
    }

    public void Switch(
        Action<FilterVariants::UnionMember0> unionMember0,
        Action<FilterVariants::NestedFilterConfig> nestedFilterConfig
    )
    {
        switch (this)
        {
            case FilterVariants::UnionMember0 inner:
                unionMember0(inner);
                break;
            case FilterVariants::NestedFilterConfig inner:
                nestedFilterConfig(inner);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of Filter");
        }
    }

    public T Match<T>(
        Func<FilterVariants::UnionMember0, T> unionMember0,
        Func<FilterVariants::NestedFilterConfig, T> nestedFilterConfig
    )
    {
        return this switch
        {
            FilterVariants::UnionMember0 inner => unionMember0(inner),
            FilterVariants::NestedFilterConfig inner => nestedFilterConfig(inner),
            _ => throw new CourierInvalidDataException("Data did not match any variant of Filter"),
        };
    }

    public abstract void Validate();
}

sealed class FilterConverter : JsonConverter<Filter>
{
    public override Filter? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<CourierInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember0>(ref reader, options);
            if (deserialized != null)
            {
                return new FilterVariants::UnionMember0(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant FilterVariants::UnionMember0",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<NestedFilterConfig>(ref reader, options);
            if (deserialized != null)
            {
                return new FilterVariants::NestedFilterConfig(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant FilterVariants::NestedFilterConfig",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Filter value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            FilterVariants::UnionMember0(var unionMember0) => unionMember0,
            FilterVariants::NestedFilterConfig(var nestedFilterConfig) => nestedFilterConfig,
            _ => throw new CourierInvalidDataException("Data did not match any variant of Filter"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
