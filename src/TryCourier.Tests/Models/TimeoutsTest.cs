using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;

namespace TryCourier.Tests.Models;

public class TimeoutsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Timeouts { Channel = 0, Provider = 0 };

        long expectedChannel = 0;
        long expectedProvider = 0;

        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedProvider, model.Provider);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Timeouts { Channel = 0, Provider = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Timeouts>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Timeouts { Channel = 0, Provider = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Timeouts>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedChannel = 0;
        long expectedProvider = 0;

        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedProvider, deserialized.Provider);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Timeouts { Channel = 0, Provider = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Timeouts { };

        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Timeouts { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Timeouts { Channel = null, Provider = null };

        Assert.Null(model.Channel);
        Assert.True(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Provider);
        Assert.True(model.RawData.ContainsKey("provider"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Timeouts { Channel = null, Provider = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Timeouts { Channel = 0, Provider = 0 };

        Timeouts copied = new(model);

        Assert.Equal(model, copied);
    }
}
