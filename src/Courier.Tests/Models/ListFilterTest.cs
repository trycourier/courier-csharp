using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models;

namespace Courier.Tests.Models;

public class ListFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ListFilter
        {
            Operator = ListFilterOperator.MemberOf,
            Path = ListFilterPath.AccountID,
            Value = "value",
        };

        ApiEnum<string, ListFilterOperator> expectedOperator = ListFilterOperator.MemberOf;
        ApiEnum<string, ListFilterPath> expectedPath = ListFilterPath.AccountID;
        string expectedValue = "value";

        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ListFilter
        {
            Operator = ListFilterOperator.MemberOf,
            Path = ListFilterPath.AccountID,
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ListFilter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ListFilter
        {
            Operator = ListFilterOperator.MemberOf,
            Path = ListFilterPath.AccountID,
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ListFilter>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, ListFilterOperator> expectedOperator = ListFilterOperator.MemberOf;
        ApiEnum<string, ListFilterPath> expectedPath = ListFilterPath.AccountID;
        string expectedValue = "value";

        Assert.Equal(expectedOperator, deserialized.Operator);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ListFilter
        {
            Operator = ListFilterOperator.MemberOf,
            Path = ListFilterPath.AccountID,
            Value = "value",
        };

        model.Validate();
    }
}

public class ListFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(ListFilterOperator.MemberOf)]
    public void Validation_Works(ListFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ListFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ListFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ListFilterOperator.MemberOf)]
    public void SerializationRoundtrip_Works(ListFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ListFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ListFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ListFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ListFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ListFilterPathTest : TestBase
{
    [Theory]
    [InlineData(ListFilterPath.AccountID)]
    public void Validation_Works(ListFilterPath rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ListFilterPath> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ListFilterPath>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ListFilterPath.AccountID)]
    public void SerializationRoundtrip_Works(ListFilterPath rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ListFilterPath> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ListFilterPath>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ListFilterPath>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ListFilterPath>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
