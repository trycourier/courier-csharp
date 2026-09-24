using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Previews;

namespace TryCourier.Tests.Models.Previews;

public class CreateDeviceSetRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreateDeviceSetRequest { DeviceIds = ["string"], Name = "name" };

        List<string> expectedDeviceIds = ["string"];
        string expectedName = "name";

        Assert.Equal(expectedDeviceIds.Count, model.DeviceIds.Count);
        for (int i = 0; i < expectedDeviceIds.Count; i++)
        {
            Assert.Equal(expectedDeviceIds[i], model.DeviceIds[i]);
        }
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreateDeviceSetRequest { DeviceIds = ["string"], Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateDeviceSetRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreateDeviceSetRequest { DeviceIds = ["string"], Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateDeviceSetRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedDeviceIds = ["string"];
        string expectedName = "name";

        Assert.Equal(expectedDeviceIds.Count, deserialized.DeviceIds.Count);
        for (int i = 0; i < expectedDeviceIds.Count; i++)
        {
            Assert.Equal(expectedDeviceIds[i], deserialized.DeviceIds[i]);
        }
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreateDeviceSetRequest { DeviceIds = ["string"], Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreateDeviceSetRequest { DeviceIds = ["string"], Name = "name" };

        CreateDeviceSetRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
