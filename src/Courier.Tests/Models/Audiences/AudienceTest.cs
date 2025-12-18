using System.Text.Json;
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
            Filter = new()
            {
                Operator = Operator.EndsWith,
                Path = "path",
                Value = "value",
            },
            Name = "name",
            UpdatedAt = "updated_at",
        };

        string expectedID = "id";
        string expectedCreatedAt = "created_at";
        string expectedDescription = "description";
        Filter expectedFilter = new()
        {
            Operator = Operator.EndsWith,
            Path = "path",
            Value = "value",
        };
        string expectedName = "name";
        string expectedUpdatedAt = "updated_at";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedFilter, model.Filter);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Audience
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Audience>(json);

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
            Filter = new()
            {
                Operator = Operator.EndsWith,
                Path = "path",
                Value = "value",
            },
            Name = "name",
            UpdatedAt = "updated_at",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Audience>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCreatedAt = "created_at";
        string expectedDescription = "description";
        Filter expectedFilter = new()
        {
            Operator = Operator.EndsWith,
            Path = "path",
            Value = "value",
        };
        string expectedName = "name";
        string expectedUpdatedAt = "updated_at";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedFilter, deserialized.Filter);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Audience
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

        model.Validate();
    }
}
