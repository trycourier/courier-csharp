using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneySendNodeToSlackEmailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneySendNodeToSlackEmail { Email = "x", AccessToken = "x" };

        string expectedEmail = "x";
        string expectedAccessToken = "x";

        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedAccessToken, model.AccessToken);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneySendNodeToSlackEmail { Email = "x", AccessToken = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneySendNodeToSlackEmail>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneySendNodeToSlackEmail { Email = "x", AccessToken = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneySendNodeToSlackEmail>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEmail = "x";
        string expectedAccessToken = "x";

        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedAccessToken, deserialized.AccessToken);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneySendNodeToSlackEmail { Email = "x", AccessToken = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneySendNodeToSlackEmail { Email = "x" };

        Assert.Null(model.AccessToken);
        Assert.False(model.RawData.ContainsKey("access_token"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneySendNodeToSlackEmail { Email = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneySendNodeToSlackEmail
        {
            Email = "x",

            // Null should be interpreted as omitted for these properties
            AccessToken = null,
        };

        Assert.Null(model.AccessToken);
        Assert.False(model.RawData.ContainsKey("access_token"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneySendNodeToSlackEmail
        {
            Email = "x",

            // Null should be interpreted as omitted for these properties
            AccessToken = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneySendNodeToSlackEmail { Email = "x", AccessToken = "x" };

        JourneySendNodeToSlackEmail copied = new(model);

        Assert.Equal(model, copied);
    }
}
