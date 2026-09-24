using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Notifications.Previews.Runs;

namespace TryCourier.Tests.Models.Notifications.Previews.Runs;

public class CreatePreviewRunRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreatePreviewRunRequest
        {
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            DeviceIds = ["string"],
            DeviceSetID = "device_set_id",
            Locale = "locale",
            TemplateVersion = "draft",
        };

        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<string> expectedDeviceIds = ["string"];
        string expectedDeviceSetID = "device_set_id";
        string expectedLocale = "locale";
        string expectedTemplateVersion = "draft";

        Assert.NotNull(model.Data);
        Assert.Equal(expectedData.Count, model.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(model.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Data[item.Key]));
        }
        Assert.NotNull(model.DeviceIds);
        Assert.Equal(expectedDeviceIds.Count, model.DeviceIds.Count);
        for (int i = 0; i < expectedDeviceIds.Count; i++)
        {
            Assert.Equal(expectedDeviceIds[i], model.DeviceIds[i]);
        }
        Assert.Equal(expectedDeviceSetID, model.DeviceSetID);
        Assert.Equal(expectedLocale, model.Locale);
        Assert.Equal(expectedTemplateVersion, model.TemplateVersion);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreatePreviewRunRequest
        {
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            DeviceIds = ["string"],
            DeviceSetID = "device_set_id",
            Locale = "locale",
            TemplateVersion = "draft",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreatePreviewRunRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreatePreviewRunRequest
        {
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            DeviceIds = ["string"],
            DeviceSetID = "device_set_id",
            Locale = "locale",
            TemplateVersion = "draft",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreatePreviewRunRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<string> expectedDeviceIds = ["string"];
        string expectedDeviceSetID = "device_set_id";
        string expectedLocale = "locale";
        string expectedTemplateVersion = "draft";

        Assert.NotNull(deserialized.Data);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(deserialized.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Data[item.Key]));
        }
        Assert.NotNull(deserialized.DeviceIds);
        Assert.Equal(expectedDeviceIds.Count, deserialized.DeviceIds.Count);
        for (int i = 0; i < expectedDeviceIds.Count; i++)
        {
            Assert.Equal(expectedDeviceIds[i], deserialized.DeviceIds[i]);
        }
        Assert.Equal(expectedDeviceSetID, deserialized.DeviceSetID);
        Assert.Equal(expectedLocale, deserialized.Locale);
        Assert.Equal(expectedTemplateVersion, deserialized.TemplateVersion);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreatePreviewRunRequest
        {
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            DeviceIds = ["string"],
            DeviceSetID = "device_set_id",
            Locale = "locale",
            TemplateVersion = "draft",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreatePreviewRunRequest { };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.DeviceIds);
        Assert.False(model.RawData.ContainsKey("device_ids"));
        Assert.Null(model.DeviceSetID);
        Assert.False(model.RawData.ContainsKey("device_set_id"));
        Assert.Null(model.Locale);
        Assert.False(model.RawData.ContainsKey("locale"));
        Assert.Null(model.TemplateVersion);
        Assert.False(model.RawData.ContainsKey("template_version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreatePreviewRunRequest { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreatePreviewRunRequest
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
            DeviceIds = null,
            DeviceSetID = null,
            Locale = null,
            TemplateVersion = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.DeviceIds);
        Assert.False(model.RawData.ContainsKey("device_ids"));
        Assert.Null(model.DeviceSetID);
        Assert.False(model.RawData.ContainsKey("device_set_id"));
        Assert.Null(model.Locale);
        Assert.False(model.RawData.ContainsKey("locale"));
        Assert.Null(model.TemplateVersion);
        Assert.False(model.RawData.ContainsKey("template_version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreatePreviewRunRequest
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
            DeviceIds = null,
            DeviceSetID = null,
            Locale = null,
            TemplateVersion = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreatePreviewRunRequest
        {
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            DeviceIds = ["string"],
            DeviceSetID = "device_set_id",
            Locale = "locale",
            TemplateVersion = "draft",
        };

        CreatePreviewRunRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
