using System.Text.Json;
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
                Filter = new()
                {
                    Operator = Operator.EndsWith,
                    Path = "path",
                    Value = "value",
                },
                Name = "name",
                UpdatedAt = "updated_at",
            },
        };

        Audience expectedAudience = new()
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Filter = new()
            {
                Operator = Operator.EndsWith,
                Path = "path",
                Value = "value",
            },
            Name = "name",
            UpdatedAt = "updated_at",
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
                Filter = new()
                {
                    Operator = Operator.EndsWith,
                    Path = "path",
                    Value = "value",
                },
                Name = "name",
                UpdatedAt = "updated_at",
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AudienceUpdateResponse>(json);

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
                Filter = new()
                {
                    Operator = Operator.EndsWith,
                    Path = "path",
                    Value = "value",
                },
                Name = "name",
                UpdatedAt = "updated_at",
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AudienceUpdateResponse>(json);
        Assert.NotNull(deserialized);

        Audience expectedAudience = new()
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Filter = new()
            {
                Operator = Operator.EndsWith,
                Path = "path",
                Value = "value",
            },
            Name = "name",
            UpdatedAt = "updated_at",
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
                Filter = new()
                {
                    Operator = Operator.EndsWith,
                    Path = "path",
                    Value = "value",
                },
                Name = "name",
                UpdatedAt = "updated_at",
            },
        };

        model.Validate();
    }
}
