using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class SendToSlackEmailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SendToSlackEmail { AccessToken = "access_token", Email = "email" };

        string expectedAccessToken = "access_token";
        string expectedEmail = "email";

        Assert.Equal(expectedAccessToken, model.AccessToken);
        Assert.Equal(expectedEmail, model.Email);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SendToSlackEmail { AccessToken = "access_token", Email = "email" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendToSlackEmail>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SendToSlackEmail { AccessToken = "access_token", Email = "email" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendToSlackEmail>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccessToken = "access_token";
        string expectedEmail = "email";

        Assert.Equal(expectedAccessToken, deserialized.AccessToken);
        Assert.Equal(expectedEmail, deserialized.Email);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SendToSlackEmail { AccessToken = "access_token", Email = "email" };

        model.Validate();
    }
}
