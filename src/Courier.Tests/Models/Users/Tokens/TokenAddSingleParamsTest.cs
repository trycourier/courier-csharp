using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Users.Tokens;

namespace Courier.Tests.Models.Users.Tokens;

public class ProviderKeyTest : TestBase
{
    [Theory]
    [InlineData(ProviderKey.FirebaseFcm)]
    [InlineData(ProviderKey.Apn)]
    [InlineData(ProviderKey.Expo)]
    [InlineData(ProviderKey.Onesignal)]
    public void Validation_Works(ProviderKey rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProviderKey> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProviderKey>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProviderKey.FirebaseFcm)]
    [InlineData(ProviderKey.Apn)]
    [InlineData(ProviderKey.Expo)]
    [InlineData(ProviderKey.Onesignal)]
    public void SerializationRoundtrip_Works(ProviderKey rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProviderKey> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ProviderKey>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProviderKey>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ProviderKey>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

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

public class ExpiryDateTest : TestBase
{
    [Fact]
    public void stringValidation_Works()
    {
        ExpiryDate value = new("string");
        value.Validate();
    }

    [Fact]
    public void boolValidation_Works()
    {
        ExpiryDate value = new(true);
        value.Validate();
    }

    [Fact]
    public void stringSerializationRoundtrip_Works()
    {
        ExpiryDate value = new("string");
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ExpiryDate>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void boolSerializationRoundtrip_Works()
    {
        ExpiryDate value = new(true);
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ExpiryDate>(json);

        Assert.Equal(value, deserialized);
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
