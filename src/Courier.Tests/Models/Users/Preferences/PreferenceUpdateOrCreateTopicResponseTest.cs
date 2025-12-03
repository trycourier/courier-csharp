using System.Text.Json;
using Courier.Models.Users.Preferences;

namespace Courier.Tests.Models.Users.Preferences;

public class PreferenceUpdateOrCreateTopicResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreferenceUpdateOrCreateTopicResponse { Message = "success" };

        string expectedMessage = "success";

        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PreferenceUpdateOrCreateTopicResponse { Message = "success" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PreferenceUpdateOrCreateTopicResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreferenceUpdateOrCreateTopicResponse { Message = "success" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PreferenceUpdateOrCreateTopicResponse>(json);
        Assert.NotNull(deserialized);

        string expectedMessage = "success";

        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PreferenceUpdateOrCreateTopicResponse { Message = "success" };

        model.Validate();
    }
}
