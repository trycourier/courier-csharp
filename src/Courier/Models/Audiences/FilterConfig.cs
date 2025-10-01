using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Audiences.FilterConfigProperties;
using FilterConfigVariants = Courier.Models.Audiences.FilterConfigVariants;

namespace Courier.Models.Audiences;

/// <summary>
/// The operator to use for filtering
/// </summary>
[JsonConverter(typeof(FilterConfigConverter))]
public abstract record class FilterConfig
{
    internal FilterConfig() { }

    public static implicit operator FilterConfig(UnionMember0 value) =>
        new FilterConfigVariants::UnionMember0(value);

    public static implicit operator FilterConfig(NestedFilterConfig value) =>
        new FilterConfigVariants::NestedFilterConfig(value);

    public bool TryPickUnionMember0([NotNullWhen(true)] out UnionMember0? value)
    {
        value = (this as FilterConfigVariants::UnionMember0)?.Value;
        return value != null;
    }

    public bool TryPickNested([NotNullWhen(true)] out NestedFilterConfig? value)
    {
        value = (this as FilterConfigVariants::NestedFilterConfig)?.Value;
        return value != null;
    }

    public void Switch(
        Action<FilterConfigVariants::UnionMember0> unionMember0,
        Action<FilterConfigVariants::NestedFilterConfig> nested
    )
    {
        switch (this)
        {
            case FilterConfigVariants::UnionMember0 inner:
                unionMember0(inner);
                break;
            case FilterConfigVariants::NestedFilterConfig inner:
                nested(inner);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of FilterConfig"
                );
        }
    }

    public T Match<T>(
        Func<FilterConfigVariants::UnionMember0, T> unionMember0,
        Func<FilterConfigVariants::NestedFilterConfig, T> nested
    )
    {
        return this switch
        {
            FilterConfigVariants::UnionMember0 inner => unionMember0(inner),
            FilterConfigVariants::NestedFilterConfig inner => nested(inner),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of FilterConfig"
            ),
        };
    }

    public abstract void Validate();
}

sealed class FilterConfigConverter : JsonConverter<FilterConfig>
{
    public override FilterConfig? Read(
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
                return new FilterConfigVariants::UnionMember0(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant FilterConfigVariants::UnionMember0",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<NestedFilterConfig>(ref reader, options);
            if (deserialized != null)
            {
                return new FilterConfigVariants::NestedFilterConfig(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant FilterConfigVariants::NestedFilterConfig",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        FilterConfig value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            FilterConfigVariants::UnionMember0(var unionMember0) => unionMember0,
            FilterConfigVariants::NestedFilterConfig(var nested) => nested,
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of FilterConfig"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
