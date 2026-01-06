using System;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Users.Tokens;

namespace Courier.Tests.Models.Users.Tokens;

public class TokenAddSingleParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TokenAddSingleParams
        {
            UserID = "user_id",
            Token = "token",
            TokenValue = "token",
            ProviderKey = ProviderKey.FirebaseFcm,
            Device = new()
            {
                AdID = "ad_id",
                AppID = "app_id",
                DeviceID = "device_id",
                Manufacturer = "manufacturer",
                Model = "model",
                Platform = "platform",
            },
            ExpiryDate = "string",
            Properties = JsonSerializer.Deserialize<JsonElement>("{}"),
            Tracking = new()
            {
                IP = "ip",
                Lat = "lat",
                Long = "long",
                OsVersion = "os_version",
            },
        };

        string expectedUserID = "user_id";
        string expectedToken = "token";
        string expectedTokenValue = "token";
        ApiEnum<string, ProviderKey> expectedProviderKey = ProviderKey.FirebaseFcm;
        Device expectedDevice = new()
        {
            AdID = "ad_id",
            AppID = "app_id",
            DeviceID = "device_id",
            Manufacturer = "manufacturer",
            Model = "model",
            Platform = "platform",
        };
        ExpiryDate expectedExpiryDate = "string";
        JsonElement expectedProperties = JsonSerializer.Deserialize<JsonElement>("{}");
        Tracking expectedTracking = new()
        {
            IP = "ip",
            Lat = "lat",
            Long = "long",
            OsVersion = "os_version",
        };

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedToken, parameters.Token);
        Assert.Equal(expectedTokenValue, parameters.TokenValue);
        Assert.Equal(expectedProviderKey, parameters.ProviderKey);
        Assert.Equal(expectedDevice, parameters.Device);
        Assert.Equal(expectedExpiryDate, parameters.ExpiryDate);
        Assert.NotNull(parameters.Properties);
        Assert.True(JsonElement.DeepEquals(expectedProperties, parameters.Properties.Value));
        Assert.Equal(expectedTracking, parameters.Tracking);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TokenAddSingleParams
        {
            UserID = "user_id",
            Token = "token",
            TokenValue = "token",
            ProviderKey = ProviderKey.FirebaseFcm,
            Device = new()
            {
                AdID = "ad_id",
                AppID = "app_id",
                DeviceID = "device_id",
                Manufacturer = "manufacturer",
                Model = "model",
                Platform = "platform",
            },
            ExpiryDate = "string",
            Tracking = new()
            {
                IP = "ip",
                Lat = "lat",
                Long = "long",
                OsVersion = "os_version",
            },
        };

        Assert.Null(parameters.Properties);
        Assert.False(parameters.RawBodyData.ContainsKey("properties"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TokenAddSingleParams
        {
            UserID = "user_id",
            Token = "token",
            TokenValue = "token",
            ProviderKey = ProviderKey.FirebaseFcm,
            Device = new()
            {
                AdID = "ad_id",
                AppID = "app_id",
                DeviceID = "device_id",
                Manufacturer = "manufacturer",
                Model = "model",
                Platform = "platform",
            },
            ExpiryDate = "string",
            Tracking = new()
            {
                IP = "ip",
                Lat = "lat",
                Long = "long",
                OsVersion = "os_version",
            },

            // Null should be interpreted as omitted for these properties
            Properties = null,
        };

        Assert.Null(parameters.Properties);
        Assert.False(parameters.RawBodyData.ContainsKey("properties"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TokenAddSingleParams
        {
            UserID = "user_id",
            Token = "token",
            TokenValue = "token",
            ProviderKey = ProviderKey.FirebaseFcm,
            Properties = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(parameters.Device);
        Assert.False(parameters.RawBodyData.ContainsKey("device"));
        Assert.Null(parameters.ExpiryDate);
        Assert.False(parameters.RawBodyData.ContainsKey("expiry_date"));
        Assert.Null(parameters.Tracking);
        Assert.False(parameters.RawBodyData.ContainsKey("tracking"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TokenAddSingleParams
        {
            UserID = "user_id",
            Token = "token",
            TokenValue = "token",
            ProviderKey = ProviderKey.FirebaseFcm,
            Properties = JsonSerializer.Deserialize<JsonElement>("{}"),

            Device = null,
            ExpiryDate = null,
            Tracking = null,
        };

        Assert.Null(parameters.Device);
        Assert.True(parameters.RawBodyData.ContainsKey("device"));
        Assert.Null(parameters.ExpiryDate);
        Assert.True(parameters.RawBodyData.ContainsKey("expiry_date"));
        Assert.Null(parameters.Tracking);
        Assert.True(parameters.RawBodyData.ContainsKey("tracking"));
    }

    [Fact]
    public void Url_Works()
    {
        TokenAddSingleParams parameters = new()
        {
            UserID = "user_id",
            Token = "token",
            TokenValue = "token",
            ProviderKey = ProviderKey.FirebaseFcm,
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/users/user_id/tokens/token"), url);
    }
}

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

        Assert.NotNull(value);
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Device>(element);
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
    public void StringValidationWorks()
    {
        ExpiryDate value = new("string");
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ExpiryDate value = new(true);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ExpiryDate value = new("string");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ExpiryDate>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ExpiryDate value = new(true);
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ExpiryDate>(element);

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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Tracking>(element);
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
