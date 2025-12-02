using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class BrandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Brand
        {
            ID = "id",
            Created = 0,
            Name = "name",
            Updated = 0,
            Published = 0,
            Settings = new()
            {
                Colors = new() { Primary = "primary", Secondary = "secondary" },
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
                    WidgetBackground = new() { BottomColor = "bottomColor", TopColor = "topColor" },
                    BorderRadius = "borderRadius",
                    DisableMessageIcon = true,
                    FontFamily = "fontFamily",
                    Placement = Placement.Top,
                },
            },
            Snippets = new() { Items = [new() { Name = "name", Value = "value" }] },
            Version = "version",
        };

        string expectedID = "id";
        long expectedCreated = 0;
        string expectedName = "name";
        long expectedUpdated = 0;
        long expectedPublished = 0;
        BrandSettings expectedSettings = new()
        {
            Colors = new() { Primary = "primary", Secondary = "secondary" },
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
                WidgetBackground = new() { BottomColor = "bottomColor", TopColor = "topColor" },
                BorderRadius = "borderRadius",
                DisableMessageIcon = true,
                FontFamily = "fontFamily",
                Placement = Placement.Top,
            },
        };
        BrandSnippets expectedSnippets = new()
        {
            Items = [new() { Name = "name", Value = "value" }],
        };
        string expectedVersion = "version";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUpdated, model.Updated);
        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedSettings, model.Settings);
        Assert.Equal(expectedSnippets, model.Snippets);
        Assert.Equal(expectedVersion, model.Version);
    }
}
