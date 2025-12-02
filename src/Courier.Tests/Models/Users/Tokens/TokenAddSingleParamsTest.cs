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
}
