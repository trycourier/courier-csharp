using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Users.Tokens;

namespace Courier.Tests.Models.Users.Tokens;

public class UserTokenTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserToken
        {
            Token = "token",
            ProviderKey = UserTokenProviderKey.FirebaseFcm,
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

        string expectedToken = "token";
        ApiEnum<string, UserTokenProviderKey> expectedProviderKey =
            UserTokenProviderKey.FirebaseFcm;
        UserTokenDevice expectedDevice = new()
        {
            AdID = "ad_id",
            AppID = "app_id",
            DeviceID = "device_id",
            Manufacturer = "manufacturer",
            Model = "model",
            Platform = "platform",
        };
        UserTokenExpiryDate expectedExpiryDate = "string";
        JsonElement expectedProperties = JsonSerializer.Deserialize<JsonElement>("{}");
        UserTokenTracking expectedTracking = new()
        {
            IP = "ip",
            Lat = "lat",
            Long = "long",
            OsVersion = "os_version",
        };

        Assert.Equal(expectedToken, model.Token);
        Assert.Equal(expectedProviderKey, model.ProviderKey);
        Assert.Equal(expectedDevice, model.Device);
        Assert.Equal(expectedExpiryDate, model.ExpiryDate);
        Assert.NotNull(model.Properties);
        Assert.True(JsonElement.DeepEquals(expectedProperties, model.Properties.Value));
        Assert.Equal(expectedTracking, model.Tracking);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserToken
        {
            Token = "token",
            ProviderKey = UserTokenProviderKey.FirebaseFcm,
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UserToken>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserToken
        {
            Token = "token",
            ProviderKey = UserTokenProviderKey.FirebaseFcm,
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UserToken>(element);
        Assert.NotNull(deserialized);

        string expectedToken = "token";
        ApiEnum<string, UserTokenProviderKey> expectedProviderKey =
            UserTokenProviderKey.FirebaseFcm;
        UserTokenDevice expectedDevice = new()
        {
            AdID = "ad_id",
            AppID = "app_id",
            DeviceID = "device_id",
            Manufacturer = "manufacturer",
            Model = "model",
            Platform = "platform",
        };
        UserTokenExpiryDate expectedExpiryDate = "string";
        JsonElement expectedProperties = JsonSerializer.Deserialize<JsonElement>("{}");
        UserTokenTracking expectedTracking = new()
        {
            IP = "ip",
            Lat = "lat",
            Long = "long",
            OsVersion = "os_version",
        };

        Assert.Equal(expectedToken, deserialized.Token);
        Assert.Equal(expectedProviderKey, deserialized.ProviderKey);
        Assert.Equal(expectedDevice, deserialized.Device);
        Assert.Equal(expectedExpiryDate, deserialized.ExpiryDate);
        Assert.NotNull(deserialized.Properties);
        Assert.True(JsonElement.DeepEquals(expectedProperties, deserialized.Properties.Value));
        Assert.Equal(expectedTracking, deserialized.Tracking);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserToken
        {
            Token = "token",
            ProviderKey = UserTokenProviderKey.FirebaseFcm,
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UserToken
        {
            Token = "token",
            ProviderKey = UserTokenProviderKey.FirebaseFcm,
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

        Assert.Null(model.Properties);
        Assert.False(model.RawData.ContainsKey("properties"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UserToken
        {
            Token = "token",
            ProviderKey = UserTokenProviderKey.FirebaseFcm,
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UserToken
        {
            Token = "token",
            ProviderKey = UserTokenProviderKey.FirebaseFcm,
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

        Assert.Null(model.Properties);
        Assert.False(model.RawData.ContainsKey("properties"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UserToken
        {
            Token = "token",
            ProviderKey = UserTokenProviderKey.FirebaseFcm,
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UserToken
        {
            Token = "token",
            ProviderKey = UserTokenProviderKey.FirebaseFcm,
            Properties = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.Device);
        Assert.False(model.RawData.ContainsKey("device"));
        Assert.Null(model.ExpiryDate);
        Assert.False(model.RawData.ContainsKey("expiry_date"));
        Assert.Null(model.Tracking);
        Assert.False(model.RawData.ContainsKey("tracking"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UserToken
        {
            Token = "token",
            ProviderKey = UserTokenProviderKey.FirebaseFcm,
            Properties = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UserToken
        {
            Token = "token",
            ProviderKey = UserTokenProviderKey.FirebaseFcm,
            Properties = JsonSerializer.Deserialize<JsonElement>("{}"),

            Device = null,
            ExpiryDate = null,
            Tracking = null,
        };

        Assert.Null(model.Device);
        Assert.True(model.RawData.ContainsKey("device"));
        Assert.Null(model.ExpiryDate);
        Assert.True(model.RawData.ContainsKey("expiry_date"));
        Assert.Null(model.Tracking);
        Assert.True(model.RawData.ContainsKey("tracking"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UserToken
        {
            Token = "token",
            ProviderKey = UserTokenProviderKey.FirebaseFcm,
            Properties = JsonSerializer.Deserialize<JsonElement>("{}"),

            Device = null,
            ExpiryDate = null,
            Tracking = null,
        };

        model.Validate();
    }
}

public class UserTokenProviderKeyTest : TestBase
{
    [Theory]
    [InlineData(UserTokenProviderKey.FirebaseFcm)]
    [InlineData(UserTokenProviderKey.Apn)]
    [InlineData(UserTokenProviderKey.Expo)]
    [InlineData(UserTokenProviderKey.Onesignal)]
    public void Validation_Works(UserTokenProviderKey rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserTokenProviderKey> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserTokenProviderKey>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserTokenProviderKey.FirebaseFcm)]
    [InlineData(UserTokenProviderKey.Apn)]
    [InlineData(UserTokenProviderKey.Expo)]
    [InlineData(UserTokenProviderKey.Onesignal)]
    public void SerializationRoundtrip_Works(UserTokenProviderKey rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserTokenProviderKey> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserTokenProviderKey>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserTokenProviderKey>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserTokenProviderKey>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UserTokenDeviceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserTokenDevice
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
        var model = new UserTokenDevice
        {
            AdID = "ad_id",
            AppID = "app_id",
            DeviceID = "device_id",
            Manufacturer = "manufacturer",
            Model = "model",
            Platform = "platform",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UserTokenDevice>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserTokenDevice
        {
            AdID = "ad_id",
            AppID = "app_id",
            DeviceID = "device_id",
            Manufacturer = "manufacturer",
            Model = "model",
            Platform = "platform",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UserTokenDevice>(element);
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
        var model = new UserTokenDevice
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
        var model = new UserTokenDevice { };

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
        var model = new UserTokenDevice { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UserTokenDevice
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
        var model = new UserTokenDevice
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

public class UserTokenExpiryDateTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        UserTokenExpiryDate value = new("string");
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        UserTokenExpiryDate value = new(true);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        UserTokenExpiryDate value = new("string");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<UserTokenExpiryDate>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        UserTokenExpiryDate value = new(true);
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<UserTokenExpiryDate>(element);

        Assert.Equal(value, deserialized);
    }
}

public class UserTokenTrackingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserTokenTracking
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
        var model = new UserTokenTracking
        {
            IP = "ip",
            Lat = "lat",
            Long = "long",
            OsVersion = "os_version",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UserTokenTracking>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserTokenTracking
        {
            IP = "ip",
            Lat = "lat",
            Long = "long",
            OsVersion = "os_version",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UserTokenTracking>(element);
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
        var model = new UserTokenTracking
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
        var model = new UserTokenTracking { };

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
        var model = new UserTokenTracking { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UserTokenTracking
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
        var model = new UserTokenTracking
        {
            IP = null,
            Lat = null,
            Long = null,
            OsVersion = null,
        };

        model.Validate();
    }
}
