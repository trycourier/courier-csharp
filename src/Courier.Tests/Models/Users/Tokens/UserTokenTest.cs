using System.Text.Json;
using Courier.Core;
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
        Assert.True(
            model.Properties.HasValue
                && JsonElement.DeepEquals(expectedProperties, model.Properties.Value)
        );
        Assert.Equal(expectedTracking, model.Tracking);
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
}
