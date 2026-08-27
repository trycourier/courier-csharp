using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneySendNodeToSlackChannelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneySendNodeToSlackChannel { Channel = "x", AccessToken = "x" };

        string expectedChannel = "x";
        string expectedAccessToken = "x";

        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedAccessToken, model.AccessToken);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneySendNodeToSlackChannel { Channel = "x", AccessToken = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneySendNodeToSlackChannel>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneySendNodeToSlackChannel { Channel = "x", AccessToken = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneySendNodeToSlackChannel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedChannel = "x";
        string expectedAccessToken = "x";

        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedAccessToken, deserialized.AccessToken);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneySendNodeToSlackChannel { Channel = "x", AccessToken = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneySendNodeToSlackChannel { Channel = "x" };

        Assert.Null(model.AccessToken);
        Assert.False(model.RawData.ContainsKey("access_token"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneySendNodeToSlackChannel { Channel = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneySendNodeToSlackChannel
        {
            Channel = "x",

            // Null should be interpreted as omitted for these properties
            AccessToken = null,
        };

        Assert.Null(model.AccessToken);
        Assert.False(model.RawData.ContainsKey("access_token"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneySendNodeToSlackChannel
        {
            Channel = "x",

            // Null should be interpreted as omitted for these properties
            AccessToken = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneySendNodeToSlackChannel { Channel = "x", AccessToken = "x" };

        JourneySendNodeToSlackChannel copied = new(model);

        Assert.Equal(model, copied);
    }
}
