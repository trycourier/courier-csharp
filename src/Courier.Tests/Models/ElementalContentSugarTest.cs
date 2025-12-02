using Courier.Models;

namespace Courier.Tests.Models;

public class ElementalContentSugarTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalContentSugar { Body = "body", Title = "title" };

        string expectedBody = "body";
        string expectedTitle = "title";

        Assert.Equal(expectedBody, model.Body);
        Assert.Equal(expectedTitle, model.Title);
    }
}
