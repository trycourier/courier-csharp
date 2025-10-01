using System.Text.Json;
using System.Threading.Tasks;

namespace Courier.Tests.Services.Brands;

public class BrandServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var brand = await this.client.Brands.Create(
            new()
            {
                Name = "name",
                Settings = new()
                {
                    Colors = new()
                    {
                        Primary = "primary",
                        Secondary = "secondary",
                        Tertiary = "tertiary",
                    },
                    Email = new()
                    {
                        Footer = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Header = JsonSerializer.Deserialize<JsonElement>("{}"),
                    },
                    Inapp = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            }
        );
        brand.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var brand = await this.client.Brands.Retrieve(new() { BrandID = "brand_id" });
        brand.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var brand = await this.client.Brands.Update(new() { BrandID = "brand_id", Name = "name" });
        brand.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var brands = await this.client.Brands.List();
        brands.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Brands.Delete(new() { BrandID = "brand_id" });
    }
}
