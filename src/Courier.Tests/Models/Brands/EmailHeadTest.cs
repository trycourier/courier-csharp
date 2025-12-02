using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class EmailHeadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EmailHead { InheritDefault = true, Content = "content" };

        bool expectedInheritDefault = true;
        string expectedContent = "content";

        Assert.Equal(expectedInheritDefault, model.InheritDefault);
        Assert.Equal(expectedContent, model.Content);
    }
}
