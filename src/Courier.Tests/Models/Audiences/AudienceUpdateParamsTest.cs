using System;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class AudienceUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AudienceUpdateParams
        {
            AudienceID = "audience_id",
            Description = "description",
            Filter = new(
                [
                    new SingleFilterConfig()
                    {
                        Operator = SingleFilterConfigOperator.EndsWith,
                        Path = "path",
                        Value = "value",
                    },
                ]
            ),
            Name = "name",
            Operator = Operator.And,
        };

        string expectedAudienceID = "audience_id";
        string expectedDescription = "description";
        Filter expectedFilter = new(
            [
                new SingleFilterConfig()
                {
                    Operator = SingleFilterConfigOperator.EndsWith,
                    Path = "path",
                    Value = "value",
                },
            ]
        );
        string expectedName = "name";
        ApiEnum<string, Operator> expectedOperator = Operator.And;

        Assert.Equal(expectedAudienceID, parameters.AudienceID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedFilter, parameters.Filter);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedOperator, parameters.Operator);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AudienceUpdateParams { AudienceID = "audience_id" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Filter);
        Assert.False(parameters.RawBodyData.ContainsKey("filter"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Operator);
        Assert.False(parameters.RawBodyData.ContainsKey("operator"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AudienceUpdateParams
        {
            AudienceID = "audience_id",

            Description = null,
            Filter = null,
            Name = null,
            Operator = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Filter);
        Assert.True(parameters.RawBodyData.ContainsKey("filter"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Operator);
        Assert.True(parameters.RawBodyData.ContainsKey("operator"));
    }

    [Fact]
    public void Url_Works()
    {
        AudienceUpdateParams parameters = new() { AudienceID = "audience_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/audiences/audience_id"), url);
    }
}

public class OperatorTest : TestBase
{
    [Theory]
    [InlineData(Operator.And)]
    [InlineData(Operator.Or)]
    public void Validation_Works(Operator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Operator.And)]
    [InlineData(Operator.Or)]
    public void SerializationRoundtrip_Works(Operator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
