using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class SendDirectMessageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SendDirectMessage { UserID = "user_id" };

        string expectedUserID = "user_id";

        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SendDirectMessage { UserID = "user_id" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SendDirectMessage>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SendDirectMessage { UserID = "user_id" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SendDirectMessage>(element);
        Assert.NotNull(deserialized);

        string expectedUserID = "user_id";

        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SendDirectMessage { UserID = "user_id" };

        model.Validate();
    }
}
