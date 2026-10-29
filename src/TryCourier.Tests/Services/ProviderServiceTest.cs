using System.Text.Json;
using System.Threading.Tasks;
using TryCourier.Models.Providers;

namespace TryCourier.Tests.Services;

public class ProviderServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var provider = await this.client.Providers.Create(
            new() { Provider = "sendgrid" },
            TestContext.Current.CancellationToken
        );
        provider.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var provider = await this.client.Providers.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        provider.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var provider = await this.client.Providers.Update(
            "id",
            new() { Provider = "sendgrid" },
            TestContext.Current.CancellationToken
        );
        provider.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var providers = await this.client.Providers.List(
            new(),
            TestContext.Current.CancellationToken
        );
        providers.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Providers.Delete("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Patch_Works()
    {
        var provider = await this.client.Providers.Patch(
            "id",
            new()
            {
                Patch =
                [
                    new()
                    {
                        Op = Op.Replace,
                        Path = "/title",
                        From = "from",
                        Value = JsonSerializer.SerializeToElement("Production SendGrid"),
                    },
                    new()
                    {
                        Op = Op.Replace,
                        Path = "/settings/api_key",
                        From = "from",
                        Value = JsonSerializer.SerializeToElement("SG.xxxxxxxx"),
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        provider.Validate();
    }
}
