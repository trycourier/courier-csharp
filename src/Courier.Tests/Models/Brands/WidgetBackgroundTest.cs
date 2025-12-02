using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class WidgetBackgroundTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WidgetBackground { BottomColor = "bottomColor", TopColor = "topColor" };

        string expectedBottomColor = "bottomColor";
        string expectedTopColor = "topColor";

        Assert.Equal(expectedBottomColor, model.BottomColor);
        Assert.Equal(expectedTopColor, model.TopColor);
    }
}
