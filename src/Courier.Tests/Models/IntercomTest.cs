using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class IntercomTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Intercom { From = "from", To = new("id") };

        string expectedFrom = "from";
        IntercomRecipient expectedTo = new("id");

        Assert.Equal(expectedFrom, model.From);
        Assert.Equal(expectedTo, model.To);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Intercom { From = "from", To = new("id") };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Intercom>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Intercom { From = "from", To = new("id") };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Intercom>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFrom = "from";
        IntercomRecipient expectedTo = new("id");

        Assert.Equal(expectedFrom, deserialized.From);
        Assert.Equal(expectedTo, deserialized.To);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Intercom { From = "from", To = new("id") };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Intercom { From = "from", To = new("id") };

        Intercom copied = new(model);

        Assert.Equal(model, copied);
    }
}
