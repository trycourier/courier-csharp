using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class BrandSnippetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandSnippet { Name = "name", Value = "value" };

        string expectedName = "name";
        string expectedValue = "value";

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedValue, model.Value);
    }
}
