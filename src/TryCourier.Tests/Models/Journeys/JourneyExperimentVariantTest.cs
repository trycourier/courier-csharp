using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyExperimentVariantTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyExperimentVariant
        {
            ID = "x",
            TemplateID = "x",
            Weight = 0,
            Name = "name",
        };

        string expectedID = "x";
        string expectedTemplateID = "x";
        double expectedWeight = 0;
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedTemplateID, model.TemplateID);
        Assert.Equal(expectedWeight, model.Weight);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyExperimentVariant
        {
            ID = "x",
            TemplateID = "x",
            Weight = 0,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyExperimentVariant>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyExperimentVariant
        {
            ID = "x",
            TemplateID = "x",
            Weight = 0,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyExperimentVariant>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "x";
        string expectedTemplateID = "x";
        double expectedWeight = 0;
        string expectedName = "name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedTemplateID, deserialized.TemplateID);
        Assert.Equal(expectedWeight, deserialized.Weight);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyExperimentVariant
        {
            ID = "x",
            TemplateID = "x",
            Weight = 0,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyExperimentVariant
        {
            ID = "x",
            TemplateID = "x",
            Weight = 0,
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyExperimentVariant
        {
            ID = "x",
            TemplateID = "x",
            Weight = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyExperimentVariant
        {
            ID = "x",
            TemplateID = "x",
            Weight = 0,

            // Null should be interpreted as omitted for these properties
            Name = null,
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneyExperimentVariant
        {
            ID = "x",
            TemplateID = "x",
            Weight = 0,

            // Null should be interpreted as omitted for these properties
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyExperimentVariant
        {
            ID = "x",
            TemplateID = "x",
            Weight = 0,
            Name = "name",
        };

        JourneyExperimentVariant copied = new(model);

        Assert.Equal(model, copied);
    }
}
