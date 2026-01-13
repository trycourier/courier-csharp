using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class SlackTest : TestBase
{
    [Fact]
    public void SendToSlackChannelValidationWorks()
    {
        Slack value = new SendToSlackChannel()
        {
            AccessToken = "access_token",
            Channel = "channel",
        };
        value.Validate();
    }

    [Fact]
    public void SendToSlackEmailValidationWorks()
    {
        Slack value = new SendToSlackEmail() { AccessToken = "access_token", Email = "email" };
        value.Validate();
    }

    [Fact]
    public void SendToSlackUserIDValidationWorks()
    {
        Slack value = new SendToSlackUserID() { AccessToken = "access_token", UserID = "user_id" };
        value.Validate();
    }

    [Fact]
    public void SendToSlackChannelSerializationRoundtripWorks()
    {
        Slack value = new SendToSlackChannel()
        {
            AccessToken = "access_token",
            Channel = "channel",
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Slack>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SendToSlackEmailSerializationRoundtripWorks()
    {
        Slack value = new SendToSlackEmail() { AccessToken = "access_token", Email = "email" };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Slack>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SendToSlackUserIDSerializationRoundtripWorks()
    {
        Slack value = new SendToSlackUserID() { AccessToken = "access_token", UserID = "user_id" };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Slack>(element);

        Assert.Equal(value, deserialized);
    }
}
