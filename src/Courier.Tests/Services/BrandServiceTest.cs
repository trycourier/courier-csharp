using System.Threading.Tasks;

namespace Courier.Tests.Services;

public class BrandServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var brand = await this.client.Brands.Create(
            new() { Name = "name" },
            TestContext.Current.CancellationToken
        );
        brand.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var brand = await this.client.Brands.Retrieve(
            "brand_id",
            new(),
            TestContext.Current.CancellationToken
        );
        brand.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var brand = await this.client.Brands.Update(
            "brand_id",
            new() { Name = "name" },
            TestContext.Current.CancellationToken
        );
        brand.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var brands = await this.client.Brands.List(new(), TestContext.Current.CancellationToken);
        brands.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Brands.Delete("brand_id", new(), TestContext.Current.CancellationToken);
    }
}
