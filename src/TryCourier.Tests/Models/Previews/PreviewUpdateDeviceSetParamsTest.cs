using System;
using System.Collections.Generic;
using TryCourier.Models.Previews;

namespace TryCourier.Tests.Models.Previews;

public class PreviewUpdateDeviceSetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PreviewUpdateDeviceSetParams
        {
            DeviceSetID = "deviceSetId",
            DeviceIds = ["pvd_1w6dgafr3aaycvv9a8bm996pkc", "pvd_34qvmj6p4dbqaa5mpys1ekt9jx"],
            Name = "Mobile and desktop",
        };

        string expectedDeviceSetID = "deviceSetId";
        List<string> expectedDeviceIds =
        [
            "pvd_1w6dgafr3aaycvv9a8bm996pkc",
            "pvd_34qvmj6p4dbqaa5mpys1ekt9jx",
        ];
        string expectedName = "Mobile and desktop";

        Assert.Equal(expectedDeviceSetID, parameters.DeviceSetID);
        Assert.Equal(expectedDeviceIds.Count, parameters.DeviceIds.Count);
        for (int i = 0; i < expectedDeviceIds.Count; i++)
        {
            Assert.Equal(expectedDeviceIds[i], parameters.DeviceIds[i]);
        }
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void Url_Works()
    {
        PreviewUpdateDeviceSetParams parameters = new()
        {
            DeviceSetID = "deviceSetId",
            DeviceIds = ["pvd_1w6dgafr3aaycvv9a8bm996pkc", "pvd_34qvmj6p4dbqaa5mpys1ekt9jx"],
            Name = "Mobile and desktop",
        };

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
        var parameters = new PreviewUpdateDeviceSetParams
        {
            DeviceSetID = "deviceSetId",
            DeviceIds = ["pvd_1w6dgafr3aaycvv9a8bm996pkc", "pvd_34qvmj6p4dbqaa5mpys1ekt9jx"],
            Name = "Mobile and desktop",
        };

        PreviewUpdateDeviceSetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
