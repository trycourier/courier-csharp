using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class ChannelMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChannelMetadata
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
        var model = new ChannelMetadata
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
        var deserialized = JsonSerializer.Deserialize<ChannelMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChannelMetadata
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
        var deserialized = JsonSerializer.Deserialize<ChannelMetadata>(
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
        var model = new ChannelMetadata
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
        var model = new ChannelMetadata { };

        Assert.Null(model.Utm);
        Assert.False(model.RawData.ContainsKey("utm"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChannelMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ChannelMetadata { Utm = null };

        Assert.Null(model.Utm);
        Assert.True(model.RawData.ContainsKey("utm"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChannelMetadata { Utm = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChannelMetadata
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

        ChannelMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
