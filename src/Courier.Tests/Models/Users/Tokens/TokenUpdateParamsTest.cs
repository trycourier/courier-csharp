using Courier.Models.Users.Tokens;

namespace Courier.Tests.Models.Users.Tokens;

public class PatchTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Patch
        {
            Op = "op",
            Path = "path",
            Value = "value",
        };

        string expectedOp = "op";
        string expectedPath = "path";
        string expectedValue = "value";

        Assert.Equal(expectedOp, model.Op);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedValue, model.Value);
    }
}
