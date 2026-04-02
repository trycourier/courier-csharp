using System.Threading.Tasks;

namespace Courier.Tests.Services.Providers;

public class CatalogServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var catalogs = await this.client.Providers.Catalog.List(
            new(),
            TestContext.Current.CancellationToken
        );
        catalogs.Validate();
    }
}
