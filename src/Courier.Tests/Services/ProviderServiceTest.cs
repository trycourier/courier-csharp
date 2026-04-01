using System.Threading.Tasks;

namespace Courier.Tests.Services;

public class ProviderServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var provider = await this.client.Providers.Create(
            new() { Provider = "provider" },
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
            new() { Provider = "provider" },
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
}
