using System;
using System.Collections.Generic;
using TryCourier.Models.Previews;

namespace TryCourier.Tests.Models.Previews;

public class PreviewCreateDeviceSetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PreviewCreateDeviceSetParams
        {
            DeviceIds = ["pvd_1w6dgafr3aaycvv9a8bm996pkc"],
            Name = "Mobile",
        };

        List<string> expectedDeviceIds = ["pvd_1w6dgafr3aaycvv9a8bm996pkc"];
        string expectedName = "Mobile";

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
        PreviewCreateDeviceSetParams parameters = new()
        {
            DeviceIds = ["pvd_1w6dgafr3aaycvv9a8bm996pkc"],
            Name = "Mobile",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/previews/device-sets"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PreviewCreateDeviceSetParams
        {
            DeviceIds = ["pvd_1w6dgafr3aaycvv9a8bm996pkc"],
            Name = "Mobile",
        };

        PreviewCreateDeviceSetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
