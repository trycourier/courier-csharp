using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.Audiences;

namespace TryCourier.Tests.Models.Audiences;

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
                Filter = new()
                {
                    Filters =
                    [
                        new()
                        {
                            Operator = "operator",
                            Filters = [],
                            Path = "path",
                            Value = "value",
                        },
                    ],
                    Operator = AudienceFilterConfigOperator.And,
                },
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
            Filter = new()
            {
                Filters =
                [
                    new()
                    {
                        Operator = "operator",
                        Filters = [],
                        Path = "path",
                        Value = "value",
                    },
                ],
                Operator = AudienceFilterConfigOperator.And,
            },
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
                Filter = new()
                {
                    Filters =
                    [
                        new()
                        {
                            Operator = "operator",
                            Filters = [],
                            Path = "path",
                            Value = "value",
                        },
                    ],
                    Operator = AudienceFilterConfigOperator.And,
                },
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
                Filter = new()
                {
                    Filters =
                    [
                        new()
                        {
                            Operator = "operator",
                            Filters = [],
                            Path = "path",
                            Value = "value",
                        },
                    ],
                    Operator = AudienceFilterConfigOperator.And,
                },
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
            Filter = new()
            {
                Filters =
                [
                    new()
                    {
                        Operator = "operator",
                        Filters = [],
                        Path = "path",
                        Value = "value",
                    },
                ],
                Operator = AudienceFilterConfigOperator.And,
            },
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
                Filter = new()
                {
                    Filters =
                    [
                        new()
                        {
                            Operator = "operator",
                            Filters = [],
                            Path = "path",
                            Value = "value",
                        },
                    ],
                    Operator = AudienceFilterConfigOperator.And,
                },
                Operator = AudienceOperator.And,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
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
                Filter = new()
                {
                    Filters =
                    [
                        new()
                        {
                            Operator = "operator",
                            Filters = [],
                            Path = "path",
                            Value = "value",
                        },
                    ],
                    Operator = AudienceFilterConfigOperator.And,
                },
                Operator = AudienceOperator.And,
            },
        };

        AudienceUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
