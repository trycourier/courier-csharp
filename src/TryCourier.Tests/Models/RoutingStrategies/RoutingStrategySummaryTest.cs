using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.RoutingStrategies;

namespace TryCourier.Tests.Models.RoutingStrategies;

public class RoutingStrategySummaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RoutingStrategySummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            Description = "description",
            Tags = ["string"],
            Updated = 0,
            Updater = "updater",
        };

        string expectedID = "id";
        long expectedCreated = 0;
        string expectedCreator = "creator";
        string expectedName = "name";
        string expectedDescription = "description";
        List<string> expectedTags = ["string"];
        long expectedUpdated = 0;
        string expectedUpdater = "updater";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedCreator, model.Creator);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedDescription, model.Description);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedUpdated, model.Updated);
        Assert.Equal(expectedUpdater, model.Updater);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RoutingStrategySummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            Description = "description",
            Tags = ["string"],
            Updated = 0,
            Updater = "updater",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RoutingStrategySummary>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RoutingStrategySummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            Description = "description",
            Tags = ["string"],
            Updated = 0,
            Updater = "updater",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RoutingStrategySummary>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedCreated = 0;
        string expectedCreator = "creator";
        string expectedName = "name";
        string expectedDescription = "description";
        List<string> expectedTags = ["string"];
        long expectedUpdated = 0;
        string expectedUpdater = "updater";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedCreator, deserialized.Creator);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.Equal(expectedUpdated, deserialized.Updated);
        Assert.Equal(expectedUpdater, deserialized.Updater);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RoutingStrategySummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            Description = "description",
            Tags = ["string"],
            Updated = 0,
            Updater = "updater",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RoutingStrategySummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Updater);
        Assert.False(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RoutingStrategySummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RoutingStrategySummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",

            Description = null,
            Tags = null,
            Updated = null,
            Updater = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Tags);
        Assert.True(model.RawData.ContainsKey("tags"));
        Assert.Null(model.Updated);
        Assert.True(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Updater);
        Assert.True(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RoutingStrategySummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",

            Description = null,
            Tags = null,
            Updated = null,
            Updater = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RoutingStrategySummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            Description = "description",
            Tags = ["string"],
            Updated = 0,
            Updater = "updater",
        };

        RoutingStrategySummary copied = new(model);

        Assert.Equal(model, copied);
    }
}
