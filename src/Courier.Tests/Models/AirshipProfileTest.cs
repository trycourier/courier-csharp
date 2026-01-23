using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class AirshipProfileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AirshipProfile { Audience = new("named_user"), DeviceTypes = ["string"] };

        AirshipProfileAudience expectedAudience = new("named_user");
        List<string> expectedDeviceTypes = ["string"];

        Assert.Equal(expectedAudience, model.Audience);
        Assert.Equal(expectedDeviceTypes.Count, model.DeviceTypes.Count);
        for (int i = 0; i < expectedDeviceTypes.Count; i++)
        {
            Assert.Equal(expectedDeviceTypes[i], model.DeviceTypes[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AirshipProfile { Audience = new("named_user"), DeviceTypes = ["string"] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AirshipProfile>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AirshipProfile { Audience = new("named_user"), DeviceTypes = ["string"] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AirshipProfile>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AirshipProfileAudience expectedAudience = new("named_user");
        List<string> expectedDeviceTypes = ["string"];

        Assert.Equal(expectedAudience, deserialized.Audience);
        Assert.Equal(expectedDeviceTypes.Count, deserialized.DeviceTypes.Count);
        for (int i = 0; i < expectedDeviceTypes.Count; i++)
        {
            Assert.Equal(expectedDeviceTypes[i], deserialized.DeviceTypes[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AirshipProfile { Audience = new("named_user"), DeviceTypes = ["string"] };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AirshipProfile { Audience = new("named_user"), DeviceTypes = ["string"] };

        AirshipProfile copied = new(model);

        Assert.Equal(model, copied);
    }
}
