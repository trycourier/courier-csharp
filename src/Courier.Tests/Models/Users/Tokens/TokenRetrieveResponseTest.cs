using System.Text.Json;
using Courier.Core;
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
        Assert.True(JsonElement.DeepEquals(expectedProperties, model.Properties));
        Assert.Equal(expectedTracking, model.Tracking);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedStatusReason, model.StatusReason);
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
}
