using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models.Journeys;

namespace Courier.Tests.Models.Journeys;

public class JourneyTemplateSummaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyTemplateSummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            State = "state",
            Tags = ["string"],
            Updated = 0,
            Updater = "updater",
        };

        string expectedID = "id";
        long expectedCreated = 0;
        string expectedCreator = "creator";
        string expectedName = "name";
        string expectedState = "state";
        List<string> expectedTags = ["string"];
        long expectedUpdated = 0;
        string expectedUpdater = "updater";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedCreator, model.Creator);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedState, model.State);
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
        var model = new JourneyTemplateSummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            State = "state",
            Tags = ["string"],
            Updated = 0,
            Updater = "updater",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyTemplateSummary>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyTemplateSummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            State = "state",
            Tags = ["string"],
            Updated = 0,
            Updater = "updater",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyTemplateSummary>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedCreated = 0;
        string expectedCreator = "creator";
        string expectedName = "name";
        string expectedState = "state";
        List<string> expectedTags = ["string"];
        long expectedUpdated = 0;
        string expectedUpdater = "updater";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedCreator, deserialized.Creator);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedState, deserialized.State);
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
        var model = new JourneyTemplateSummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            State = "state",
            Tags = ["string"],
            Updated = 0,
            Updater = "updater",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyTemplateSummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            State = "state",
            Tags = ["string"],
        };

        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Updater);
        Assert.False(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyTemplateSummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            State = "state",
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyTemplateSummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            State = "state",
            Tags = ["string"],

            // Null should be interpreted as omitted for these properties
            Updated = null,
            Updater = null,
        };

        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Updater);
        Assert.False(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneyTemplateSummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            State = "state",
            Tags = ["string"],

            // Null should be interpreted as omitted for these properties
            Updated = null,
            Updater = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyTemplateSummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            State = "state",
            Tags = ["string"],
            Updated = 0,
            Updater = "updater",
        };

        JourneyTemplateSummary copied = new(model);

        Assert.Equal(model, copied);
    }
}
