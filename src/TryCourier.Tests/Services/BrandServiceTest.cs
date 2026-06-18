using System.Threading.Tasks;
using TryCourier.Models.Brands;

namespace TryCourier.Tests.Services;

public class BrandServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var brand = await this.client.Brands.Create(
            new()
            {
                Name = "My Brand",
                Settings = new()
                {
                    Colors = new() { Primary = "#9D3789", Secondary = "#FFFFFF" },
                    Email = new()
                    {
                        Footer = new() { Content = "content", InheritDefault = true },
                        Head = new() { InheritDefault = true, Content = "content" },
                        Header = new()
                        {
                            Logo = new() { Href = "href", Image = "image" },
                            BarColor = "barColor",
                            InheritDefault = true,
                        },
                        TemplateOverride = new()
                        {
                            Enabled = true,
                            BackgroundColor = "backgroundColor",
                            BlocksBackgroundColor = "blocksBackgroundColor",
                            Footer = "footer",
                            Head = "head",
                            Header = "header",
                            Width = "width",
                            Mjml = new()
                            {
                                Enabled = true,
                                BackgroundColor = "backgroundColor",
                                BlocksBackgroundColor = "blocksBackgroundColor",
                                Footer = "footer",
                                Head = "head",
                                Header = "header",
                                Width = "width",
                            },
                            FooterBackgroundColor = "footerBackgroundColor",
                            FooterFullWidth = true,
                        },
                    },
                    Inapp = new()
                    {
                        Colors = new() { Primary = "primary", Secondary = "secondary" },
                        Icons = new() { Bell = "bell", Message = "message" },
                        WidgetBackground = new()
                        {
                            BottomColor = "bottomColor",
                            TopColor = "topColor",
                        },
                        BorderRadius = "borderRadius",
                        DisableMessageIcon = true,
                        FontFamily = "fontFamily",
                        Placement = Placement.Top,
                    },
                },
            },
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
