using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneySendNodeToSlackUserIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneySendNodeToSlackUserID { UserID = "x", AccessToken = "x" };

        string expectedUserID = "x";
        string expectedAccessToken = "x";

        Assert.Equal(expectedUserID, model.UserID);
        Assert.Equal(expectedAccessToken, model.AccessToken);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneySendNodeToSlackUserID { UserID = "x", AccessToken = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneySendNodeToSlackUserID>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneySendNodeToSlackUserID { UserID = "x", AccessToken = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneySendNodeToSlackUserID>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedUserID = "x";
        string expectedAccessToken = "x";

        Assert.Equal(expectedUserID, deserialized.UserID);
        Assert.Equal(expectedAccessToken, deserialized.AccessToken);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneySendNodeToSlackUserID { UserID = "x", AccessToken = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneySendNodeToSlackUserID { UserID = "x" };

        Assert.Null(model.AccessToken);
        Assert.False(model.RawData.ContainsKey("access_token"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneySendNodeToSlackUserID { UserID = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneySendNodeToSlackUserID
        {
            UserID = "x",

            // Null should be interpreted as omitted for these properties
            AccessToken = null,
        };

        Assert.Null(model.AccessToken);
        Assert.False(model.RawData.ContainsKey("access_token"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneySendNodeToSlackUserID
        {
            UserID = "x",

            // Null should be interpreted as omitted for these properties
            AccessToken = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneySendNodeToSlackUserID { UserID = "x", AccessToken = "x" };

        JourneySendNodeToSlackUserID copied = new(model);

        Assert.Equal(model, copied);
    }
}
