using System.Text.Json;
using Courier.Core;
using Courier.Models.Journeys;

namespace Courier.Tests.Models.Journeys;

public class JourneyVersionItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyVersionItem
        {
            Created = 0,
            Creator = "creator",
            Name = "name",
            Published = 0,
            Version = "version",
        };

        long expectedCreated = 0;
        string expectedCreator = "creator";
        string expectedName = "name";
        long expectedPublished = 0;
        string expectedVersion = "version";

        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedCreator, model.Creator);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyVersionItem
        {
            Created = 0,
            Creator = "creator",
            Name = "name",
            Published = 0,
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyVersionItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyVersionItem
        {
            Created = 0,
            Creator = "creator",
            Name = "name",
            Published = 0,
            Version = "version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyVersionItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCreated = 0;
        string expectedCreator = "creator";
        string expectedName = "name";
        long expectedPublished = 0;
        string expectedVersion = "version";

        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedCreator, deserialized.Creator);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyVersionItem
        {
            Created = 0,
            Creator = "creator",
            Name = "name",
            Published = 0,
            Version = "version",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyVersionItem
        {
            Created = 0,
            Creator = "creator",
            Name = "name",
            Published = 0,
            Version = "version",
        };

        JourneyVersionItem copied = new(model);

        Assert.Equal(model, copied);
    }
}
