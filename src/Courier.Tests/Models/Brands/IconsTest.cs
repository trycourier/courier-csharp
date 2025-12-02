using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class IconsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Icons { Bell = "bell", Message = "message" };

        string expectedBell = "bell";
        string expectedMessage = "message";

        Assert.Equal(expectedBell, model.Bell);
        Assert.Equal(expectedMessage, model.Message);
    }
}
