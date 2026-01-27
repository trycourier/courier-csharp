using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class SendToSlackUserIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SendToSlackUserID { AccessToken = "access_token", UserID = "user_id" };

        string expectedAccessToken = "access_token";
        string expectedUserID = "user_id";

        Assert.Equal(expectedAccessToken, model.AccessToken);
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SendToSlackUserID { AccessToken = "access_token", UserID = "user_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendToSlackUserID>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SendToSlackUserID { AccessToken = "access_token", UserID = "user_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendToSlackUserID>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccessToken = "access_token";
        string expectedUserID = "user_id";

        Assert.Equal(expectedAccessToken, deserialized.AccessToken);
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SendToSlackUserID { AccessToken = "access_token", UserID = "user_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SendToSlackUserID { AccessToken = "access_token", UserID = "user_id" };

        SendToSlackUserID copied = new(model);

        Assert.Equal(model, copied);
    }
}
