using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;

namespace TryCourier.Tests.Models;

public class MetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Metadata
        {
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };

        Utm expectedUtm = new()
        {
            Campaign = "campaign",
            Content = "content",
            Medium = "medium",
            Source = "source",
            Term = "term",
        };

        Assert.Equal(expectedUtm, model.Utm);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Metadata
        {
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Metadata
        {
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Utm expectedUtm = new()
        {
            Campaign = "campaign",
            Content = "content",
            Medium = "medium",
            Source = "source",
            Term = "term",
        };

        Assert.Equal(expectedUtm, deserialized.Utm);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Metadata
        {
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Metadata { };

        Assert.Null(model.Utm);
        Assert.False(model.RawData.ContainsKey("utm"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Metadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Metadata { Utm = null };

        Assert.Null(model.Utm);
        Assert.True(model.RawData.ContainsKey("utm"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Metadata { Utm = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Metadata
        {
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };

        Metadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
