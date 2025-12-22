using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class SlackBasePropertiesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SlackBaseProperties { AccessToken = "access_token" };

        string expectedAccessToken = "access_token";

        Assert.Equal(expectedAccessToken, model.AccessToken);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SlackBaseProperties { AccessToken = "access_token" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SlackBaseProperties>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SlackBaseProperties { AccessToken = "access_token" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SlackBaseProperties>(element);
        Assert.NotNull(deserialized);

        string expectedAccessToken = "access_token";

        Assert.Equal(expectedAccessToken, deserialized.AccessToken);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SlackBaseProperties { AccessToken = "access_token" };

        model.Validate();
    }
}
