using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class IntercomRecipientTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntercomRecipient { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntercomRecipient { ID = "id" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<IntercomRecipient>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntercomRecipient { ID = "id" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<IntercomRecipient>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";

        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntercomRecipient { ID = "id" };

        model.Validate();
    }
}
