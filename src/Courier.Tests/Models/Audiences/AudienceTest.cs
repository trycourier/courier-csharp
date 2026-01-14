using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class AudienceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Audience
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Name = "name",
            UpdatedAt = "updated_at",
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
            Operator = AudienceOperator.And,
        };

        string expectedID = "id";
        string expectedCreatedAt = "created_at";
        string expectedDescription = "description";
        string expectedName = "name";
        string expectedUpdatedAt = "updated_at";
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
        ApiEnum<string, AudienceOperator> expectedOperator = AudienceOperator.And;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedFilter, model.Filter);
        Assert.Equal(expectedOperator, model.Operator);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Audience
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Name = "name",
            UpdatedAt = "updated_at",
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
            Operator = AudienceOperator.And,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Audience>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Audience
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Name = "name",
            UpdatedAt = "updated_at",
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
            Operator = AudienceOperator.And,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Audience>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCreatedAt = "created_at";
        string expectedDescription = "description";
        string expectedName = "name";
        string expectedUpdatedAt = "updated_at";
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
        ApiEnum<string, AudienceOperator> expectedOperator = AudienceOperator.And;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedFilter, deserialized.Filter);
        Assert.Equal(expectedOperator, deserialized.Operator);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Audience
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Name = "name",
            UpdatedAt = "updated_at",
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
            Operator = AudienceOperator.And,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Audience
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Name = "name",
            UpdatedAt = "updated_at",
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
        };

        Assert.Null(model.Operator);
        Assert.False(model.RawData.ContainsKey("operator"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Audience
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Name = "name",
            UpdatedAt = "updated_at",
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Audience
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Name = "name",
            UpdatedAt = "updated_at",
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

            // Null should be interpreted as omitted for these properties
            Operator = null,
        };

        Assert.Null(model.Operator);
        Assert.False(model.RawData.ContainsKey("operator"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Audience
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Name = "name",
            UpdatedAt = "updated_at",
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

            // Null should be interpreted as omitted for these properties
            Operator = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Audience
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Name = "name",
            UpdatedAt = "updated_at",
            Operator = AudienceOperator.And,
        };

        Assert.Null(model.Filter);
        Assert.False(model.RawData.ContainsKey("filter"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Audience
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Name = "name",
            UpdatedAt = "updated_at",
            Operator = AudienceOperator.And,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Audience
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Name = "name",
            UpdatedAt = "updated_at",
            Operator = AudienceOperator.And,

            Filter = null,
        };

        Assert.Null(model.Filter);
        Assert.True(model.RawData.ContainsKey("filter"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Audience
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Name = "name",
            UpdatedAt = "updated_at",
            Operator = AudienceOperator.And,

            Filter = null,
        };

        model.Validate();
    }
}

public class AudienceOperatorTest : TestBase
{
    [Theory]
    [InlineData(AudienceOperator.And)]
    [InlineData(AudienceOperator.Or)]
    public void Validation_Works(AudienceOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AudienceOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AudienceOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AudienceOperator.And)]
    [InlineData(AudienceOperator.Or)]
    public void SerializationRoundtrip_Works(AudienceOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AudienceOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AudienceOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AudienceOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AudienceOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
