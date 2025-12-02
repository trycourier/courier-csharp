using Courier.Core;
using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class FilterConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FilterConfig
        {
            Operator = FilterConfigOperator.EndsWith,
            Path = "path",
            Value = "value",
        };

        ApiEnum<string, FilterConfigOperator> expectedOperator = FilterConfigOperator.EndsWith;
        string expectedPath = "path";
        string expectedValue = "value";

        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedValue, model.Value);
    }
}
