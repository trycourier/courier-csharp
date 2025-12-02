using Courier.Core;
using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class FilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter
        {
            Operator = Operator.EndsWith,
            Path = "path",
            Value = "value",
        };

        ApiEnum<string, Operator> expectedOperator = Operator.EndsWith;
        string expectedPath = "path";
        string expectedValue = "value";

        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedValue, model.Value);
    }
}
