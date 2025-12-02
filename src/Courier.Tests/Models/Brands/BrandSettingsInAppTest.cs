using Courier.Core;
using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class BrandSettingsInAppTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandSettingsInApp
        {
            Colors = new() { Primary = "primary", Secondary = "secondary" },
            Icons = new() { Bell = "bell", Message = "message" },
            WidgetBackground = new() { BottomColor = "bottomColor", TopColor = "topColor" },
            BorderRadius = "borderRadius",
            DisableMessageIcon = true,
            FontFamily = "fontFamily",
            Placement = Placement.Top,
        };

        BrandColors expectedColors = new() { Primary = "primary", Secondary = "secondary" };
        Icons expectedIcons = new() { Bell = "bell", Message = "message" };
        WidgetBackground expectedWidgetBackground = new()
        {
            BottomColor = "bottomColor",
            TopColor = "topColor",
        };
        string expectedBorderRadius = "borderRadius";
        bool expectedDisableMessageIcon = true;
        string expectedFontFamily = "fontFamily";
        ApiEnum<string, Placement> expectedPlacement = Placement.Top;

        Assert.Equal(expectedColors, model.Colors);
        Assert.Equal(expectedIcons, model.Icons);
        Assert.Equal(expectedWidgetBackground, model.WidgetBackground);
        Assert.Equal(expectedBorderRadius, model.BorderRadius);
        Assert.Equal(expectedDisableMessageIcon, model.DisableMessageIcon);
        Assert.Equal(expectedFontFamily, model.FontFamily);
        Assert.Equal(expectedPlacement, model.Placement);
    }
}
