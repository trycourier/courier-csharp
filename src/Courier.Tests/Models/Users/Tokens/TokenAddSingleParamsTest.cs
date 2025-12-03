using System.Text.Json;
using Courier.Models.Users.Tokens;

namespace Courier.Tests.Models.Users.Tokens;

public class DeviceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Device
        {
            AdID = "ad_id",
            AppID = "app_id",
            DeviceID = "device_id",
            Manufacturer = "manufacturer",
            Model = "model",
            Platform = "platform",
        };

        string expectedAdID = "ad_id";
        string expectedAppID = "app_id";
        string expectedDeviceID = "device_id";
        string expectedManufacturer = "manufacturer";
        string expectedModel = "model";
        string expectedPlatform = "platform";

        Assert.Equal(expectedAdID, model.AdID);
        Assert.Equal(expectedAppID, model.AppID);
        Assert.Equal(expectedDeviceID, model.DeviceID);
        Assert.Equal(expectedManufacturer, model.Manufacturer);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedPlatform, model.Platform);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Device
        {
            AdID = "ad_id",
            AppID = "app_id",
            DeviceID = "device_id",
            Manufacturer = "manufacturer",
            Model = "model",
            Platform = "platform",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Device>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Device
        {
            AdID = "ad_id",
            AppID = "app_id",
            DeviceID = "device_id",
            Manufacturer = "manufacturer",
            Model = "model",
            Platform = "platform",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Device>(json);
        Assert.NotNull(deserialized);

        string expectedAdID = "ad_id";
        string expectedAppID = "app_id";
        string expectedDeviceID = "device_id";
        string expectedManufacturer = "manufacturer";
        string expectedModel = "model";
        string expectedPlatform = "platform";

        Assert.Equal(expectedAdID, deserialized.AdID);
        Assert.Equal(expectedAppID, deserialized.AppID);
        Assert.Equal(expectedDeviceID, deserialized.DeviceID);
        Assert.Equal(expectedManufacturer, deserialized.Manufacturer);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedPlatform, deserialized.Platform);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Device
        {
            AdID = "ad_id",
            AppID = "app_id",
            DeviceID = "device_id",
            Manufacturer = "manufacturer",
            Model = "model",
            Platform = "platform",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Device { };

        Assert.Null(model.AdID);
        Assert.False(model.RawData.ContainsKey("ad_id"));
        Assert.Null(model.AppID);
        Assert.False(model.RawData.ContainsKey("app_id"));
        Assert.Null(model.DeviceID);
        Assert.False(model.RawData.ContainsKey("device_id"));
        Assert.Null(model.Manufacturer);
        Assert.False(model.RawData.ContainsKey("manufacturer"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Platform);
        Assert.False(model.RawData.ContainsKey("platform"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Device { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Device
        {
            AdID = null,
            AppID = null,
            DeviceID = null,
            Manufacturer = null,
            Model = null,
            Platform = null,
        };

        Assert.Null(model.AdID);
        Assert.True(model.RawData.ContainsKey("ad_id"));
        Assert.Null(model.AppID);
        Assert.True(model.RawData.ContainsKey("app_id"));
        Assert.Null(model.DeviceID);
        Assert.True(model.RawData.ContainsKey("device_id"));
        Assert.Null(model.Manufacturer);
        Assert.True(model.RawData.ContainsKey("manufacturer"));
        Assert.Null(model.Model);
        Assert.True(model.RawData.ContainsKey("model"));
        Assert.Null(model.Platform);
        Assert.True(model.RawData.ContainsKey("platform"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Device
        {
            AdID = null,
            AppID = null,
            DeviceID = null,
            Manufacturer = null,
            Model = null,
            Platform = null,
        };

        model.Validate();
    }
}

public class TrackingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tracking
        {
            IP = "ip",
            Lat = "lat",
            Long = "long",
            OsVersion = "os_version",
        };

        string expectedIP = "ip";
        string expectedLat = "lat";
        string expectedLong = "long";
        string expectedOsVersion = "os_version";

        Assert.Equal(expectedIP, model.IP);
        Assert.Equal(expectedLat, model.Lat);
        Assert.Equal(expectedLong, model.Long);
        Assert.Equal(expectedOsVersion, model.OsVersion);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Tracking
        {
            IP = "ip",
            Lat = "lat",
            Long = "long",
            OsVersion = "os_version",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Tracking>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Tracking
        {
            IP = "ip",
            Lat = "lat",
            Long = "long",
            OsVersion = "os_version",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Tracking>(json);
        Assert.NotNull(deserialized);

        string expectedIP = "ip";
        string expectedLat = "lat";
        string expectedLong = "long";
        string expectedOsVersion = "os_version";

        Assert.Equal(expectedIP, deserialized.IP);
        Assert.Equal(expectedLat, deserialized.Lat);
        Assert.Equal(expectedLong, deserialized.Long);
        Assert.Equal(expectedOsVersion, deserialized.OsVersion);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Tracking
        {
            IP = "ip",
            Lat = "lat",
            Long = "long",
            OsVersion = "os_version",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Tracking { };

        Assert.Null(model.IP);
        Assert.False(model.RawData.ContainsKey("ip"));
        Assert.Null(model.Lat);
        Assert.False(model.RawData.ContainsKey("lat"));
        Assert.Null(model.Long);
        Assert.False(model.RawData.ContainsKey("long"));
        Assert.Null(model.OsVersion);
        Assert.False(model.RawData.ContainsKey("os_version"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Tracking { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Tracking
        {
            IP = null,
            Lat = null,
            Long = null,
            OsVersion = null,
        };

        Assert.Null(model.IP);
        Assert.True(model.RawData.ContainsKey("ip"));
        Assert.Null(model.Lat);
        Assert.True(model.RawData.ContainsKey("lat"));
        Assert.Null(model.Long);
        Assert.True(model.RawData.ContainsKey("long"));
        Assert.Null(model.OsVersion);
        Assert.True(model.RawData.ContainsKey("os_version"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Tracking
        {
            IP = null,
            Lat = null,
            Long = null,
            OsVersion = null,
        };

        model.Validate();
    }
}
