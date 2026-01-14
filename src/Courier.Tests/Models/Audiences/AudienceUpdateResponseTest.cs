using System.Text.Json;
using Courier.Core;
using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class AudienceUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AudienceUpdateResponse
        {
            Audience = new()
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
            },
        };

        Audience expectedAudience = new()
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

        Assert.Equal(expectedAudience, model.Audience);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AudienceUpdateResponse
        {
            Audience = new()
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
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AudienceUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AudienceUpdateResponse
        {
            Audience = new()
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
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AudienceUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Audience expectedAudience = new()
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

        Assert.Equal(expectedAudience, deserialized.Audience);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AudienceUpdateResponse
        {
            Audience = new()
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
            },
        };

        model.Validate();
    }
}
