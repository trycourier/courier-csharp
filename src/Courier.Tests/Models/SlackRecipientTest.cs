using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class SlackRecipientTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SlackRecipient
        {
            Slack = new SendToSlackChannel() { AccessToken = "access_token", Channel = "channel" },
        };

        Slack expectedSlack = new SendToSlackChannel()
        {
            AccessToken = "access_token",
            Channel = "channel",
        };

        Assert.Equal(expectedSlack, model.Slack);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SlackRecipient
        {
            Slack = new SendToSlackChannel() { AccessToken = "access_token", Channel = "channel" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SlackRecipient>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SlackRecipient
        {
            Slack = new SendToSlackChannel() { AccessToken = "access_token", Channel = "channel" },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SlackRecipient>(element);
        Assert.NotNull(deserialized);

        Slack expectedSlack = new SendToSlackChannel()
        {
            AccessToken = "access_token",
            Channel = "channel",
        };

        Assert.Equal(expectedSlack, deserialized.Slack);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SlackRecipient
        {
            Slack = new SendToSlackChannel() { AccessToken = "access_token", Channel = "channel" },
        };

        model.Validate();
    }
}
