using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Users.Tokens;

namespace Courier.Tests.Models.Users.Tokens;

public class TokenRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TokenRetrieveResponse
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
            Status = Status.Active,
            StatusReason = "status_reason",
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
        ApiEnum<string, Status> expectedStatus = Status.Active;
        string expectedStatusReason = "status_reason";

        Assert.Equal(expectedToken, model.Token);
        Assert.Equal(expectedProviderKey, model.ProviderKey);
        Assert.Equal(expectedDevice, model.Device);
        Assert.Equal(expectedExpiryDate, model.ExpiryDate);
        Assert.NotNull(model.Properties);
        Assert.True(JsonElement.DeepEquals(expectedProperties, model.Properties.Value));
        Assert.Equal(expectedTracking, model.Tracking);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedStatusReason, model.StatusReason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TokenRetrieveResponse
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
            Status = Status.Active,
            StatusReason = "status_reason",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TokenRetrieveResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TokenRetrieveResponse
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
            Status = Status.Active,
            StatusReason = "status_reason",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TokenRetrieveResponse>(json);
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
        ApiEnum<string, Status> expectedStatus = Status.Active;
        string expectedStatusReason = "status_reason";

        Assert.Equal(expectedToken, deserialized.Token);
        Assert.Equal(expectedProviderKey, deserialized.ProviderKey);
        Assert.Equal(expectedDevice, deserialized.Device);
        Assert.Equal(expectedExpiryDate, deserialized.ExpiryDate);
        Assert.NotNull(deserialized.Properties);
        Assert.True(JsonElement.DeepEquals(expectedProperties, deserialized.Properties.Value));
        Assert.Equal(expectedTracking, deserialized.Tracking);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedStatusReason, deserialized.StatusReason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TokenRetrieveResponse
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
            Status = Status.Active,
            StatusReason = "status_reason",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TokenRetrieveResponse
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
            Status = Status.Active,
            StatusReason = "status_reason",
        };

        Assert.Null(model.Properties);
        Assert.False(model.RawData.ContainsKey("properties"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TokenRetrieveResponse
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
            Status = Status.Active,
            StatusReason = "status_reason",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TokenRetrieveResponse
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
            Status = Status.Active,
            StatusReason = "status_reason",

            // Null should be interpreted as omitted for these properties
            Properties = null,
        };

        Assert.Null(model.Properties);
        Assert.False(model.RawData.ContainsKey("properties"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TokenRetrieveResponse
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
            Status = Status.Active,
            StatusReason = "status_reason",

            // Null should be interpreted as omitted for these properties
            Properties = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TokenRetrieveResponse
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
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.StatusReason);
        Assert.False(model.RawData.ContainsKey("status_reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TokenRetrieveResponse
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
        var model = new TokenRetrieveResponse
        {
            Token = "token",
            ProviderKey = UserTokenProviderKey.FirebaseFcm,
            Properties = JsonSerializer.Deserialize<JsonElement>("{}"),

            Device = null,
            ExpiryDate = null,
            Tracking = null,
            Status = null,
            StatusReason = null,
        };

        Assert.Null(model.Device);
        Assert.True(model.RawData.ContainsKey("device"));
        Assert.Null(model.ExpiryDate);
        Assert.True(model.RawData.ContainsKey("expiry_date"));
        Assert.Null(model.Tracking);
        Assert.True(model.RawData.ContainsKey("tracking"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
        Assert.Null(model.StatusReason);
        Assert.True(model.RawData.ContainsKey("status_reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TokenRetrieveResponse
        {
            Token = "token",
            ProviderKey = UserTokenProviderKey.FirebaseFcm,
            Properties = JsonSerializer.Deserialize<JsonElement>("{}"),

            Device = null,
            ExpiryDate = null,
            Tracking = null,
            Status = null,
            StatusReason = null,
        };

        model.Validate();
    }
}

public class IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntersectionMember1
        {
            Status = Status.Active,
            StatusReason = "status_reason",
        };

        ApiEnum<string, Status> expectedStatus = Status.Active;
        string expectedStatusReason = "status_reason";

        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedStatusReason, model.StatusReason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntersectionMember1
        {
            Status = Status.Active,
            StatusReason = "status_reason",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntersectionMember1
        {
            Status = Status.Active,
            StatusReason = "status_reason",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, Status> expectedStatus = Status.Active;
        string expectedStatusReason = "status_reason";

        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedStatusReason, deserialized.StatusReason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntersectionMember1
        {
            Status = Status.Active,
            StatusReason = "status_reason",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new IntersectionMember1 { };

        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.StatusReason);
        Assert.False(model.RawData.ContainsKey("status_reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new IntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new IntersectionMember1 { Status = null, StatusReason = null };

        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
        Assert.Null(model.StatusReason);
        Assert.True(model.RawData.ContainsKey("status_reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new IntersectionMember1 { Status = null, StatusReason = null };

        model.Validate();
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Unknown)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Revoked)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Unknown)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Revoked)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
