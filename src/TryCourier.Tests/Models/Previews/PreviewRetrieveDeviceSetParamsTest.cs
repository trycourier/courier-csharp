using System;
using TryCourier.Models.Previews;

namespace TryCourier.Tests.Models.Previews;

public class PreviewRetrieveDeviceSetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PreviewRetrieveDeviceSetParams { DeviceSetID = "deviceSetId" };

        string expectedDeviceSetID = "deviceSetId";

        Assert.Equal(expectedDeviceSetID, parameters.DeviceSetID);
    }

    [Fact]
    public void Url_Works()
    {
        PreviewRetrieveDeviceSetParams parameters = new() { DeviceSetID = "deviceSetId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/previews/device-sets/deviceSetId"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PreviewRetrieveDeviceSetParams { DeviceSetID = "deviceSetId" };

        PreviewRetrieveDeviceSetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
