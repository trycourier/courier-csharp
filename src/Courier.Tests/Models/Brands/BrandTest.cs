using System.Text.Json;
using Courier.Core;
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Brand>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Brand>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUpdated, deserialized.Updated);
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedSettings, deserialized.Settings);
        Assert.Equal(expectedSnippets, deserialized.Snippets);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Brand
        {
            ID = "id",
            Created = 0,
            Name = "name",
            Updated = 0,
        };

        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Settings);
        Assert.False(model.RawData.ContainsKey("settings"));
        Assert.Null(model.Snippets);
        Assert.False(model.RawData.ContainsKey("snippets"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Brand
        {
            ID = "id",
            Created = 0,
            Name = "name",
            Updated = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Brand
        {
            ID = "id",
            Created = 0,
            Name = "name",
            Updated = 0,

            Published = null,
            Settings = null,
            Snippets = null,
            Version = null,
        };

        Assert.Null(model.Published);
        Assert.True(model.RawData.ContainsKey("published"));
        Assert.Null(model.Settings);
        Assert.True(model.RawData.ContainsKey("settings"));
        Assert.Null(model.Snippets);
        Assert.True(model.RawData.ContainsKey("snippets"));
        Assert.Null(model.Version);
        Assert.True(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Brand
        {
            ID = "id",
            Created = 0,
            Name = "name",
            Updated = 0,

            Published = null,
            Settings = null,
            Snippets = null,
            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
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

        Brand copied = new(model);

        Assert.Equal(model, copied);
    }
}
