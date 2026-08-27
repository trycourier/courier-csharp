using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneySendNodeToSlackTest : TestBase
{
    [Fact]
    public void ChannelValidationWorks()
    {
        JourneySendNodeToSlack value = new JourneySendNodeToSlackChannel()
        {
            Channel = "x",
            AccessToken = "x",
        };
        value.Validate();
    }

    [Fact]
    public void UserIDValidationWorks()
    {
        JourneySendNodeToSlack value = new JourneySendNodeToSlackUserID()
        {
            UserID = "x",
            AccessToken = "x",
        };
        value.Validate();
    }

    [Fact]
    public void EmailValidationWorks()
    {
        JourneySendNodeToSlack value = new JourneySendNodeToSlackEmail()
        {
            Email = "x",
            AccessToken = "x",
        };
        value.Validate();
    }

    [Fact]
    public void ChannelSerializationRoundtripWorks()
    {
        JourneySendNodeToSlack value = new JourneySendNodeToSlackChannel()
        {
            Channel = "x",
            AccessToken = "x",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneySendNodeToSlack>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserIDSerializationRoundtripWorks()
    {
        JourneySendNodeToSlack value = new JourneySendNodeToSlackUserID()
        {
            UserID = "x",
            AccessToken = "x",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneySendNodeToSlack>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EmailSerializationRoundtripWorks()
    {
        JourneySendNodeToSlack value = new JourneySendNodeToSlackEmail()
        {
            Email = "x",
            AccessToken = "x",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneySendNodeToSlack>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
