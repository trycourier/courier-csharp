using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class EmailFooterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EmailFooter { Content = "content", InheritDefault = true };

        string expectedContent = "content";
        bool expectedInheritDefault = true;

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedInheritDefault, model.InheritDefault);
    }
}
