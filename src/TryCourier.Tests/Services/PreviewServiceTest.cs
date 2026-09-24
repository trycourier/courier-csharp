using System.Threading.Tasks;

namespace TryCourier.Tests.Services;

public class PreviewServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ArchiveDeviceSet_Works()
    {
        var deviceSet = await this.client.Previews.ArchiveDeviceSet(
            "deviceSetId",
            new(),
            TestContext.Current.CancellationToken
        );
        deviceSet.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CreateDeviceSet_Works()
    {
        var deviceSet = await this.client.Previews.CreateDeviceSet(
            new() { DeviceIds = ["pvd_1w6dgafr3aaycvv9a8bm996pkc"], Name = "Mobile" },
            TestContext.Current.CancellationToken
        );
        deviceSet.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListDeviceSets_Works()
    {
        var deviceSetListResponse = await this.client.Previews.ListDeviceSets(
            new(),
            TestContext.Current.CancellationToken
        );
        deviceSetListResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListDevices_Works()
    {
        var previewDeviceListResponse = await this.client.Previews.ListDevices(
            new(),
            TestContext.Current.CancellationToken
        );
        previewDeviceListResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveDeviceSet_Works()
    {
        var deviceSet = await this.client.Previews.RetrieveDeviceSet(
            "deviceSetId",
            new(),
            TestContext.Current.CancellationToken
        );
        deviceSet.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UpdateDeviceSet_Works()
    {
        var deviceSet = await this.client.Previews.UpdateDeviceSet(
            "deviceSetId",
            new()
            {
                DeviceIds = ["pvd_1w6dgafr3aaycvv9a8bm996pkc", "pvd_34qvmj6p4dbqaa5mpys1ekt9jx"],
                Name = "Mobile and desktop",
            },
            TestContext.Current.CancellationToken
        );
        deviceSet.Validate();
    }
}
