using Courier.Models.Lists;

namespace Courier.Tests.Models.Lists;

public class ListListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ListListParams { Cursor = "cursor", Pattern = "pattern" };

        string expectedCursor = "cursor";
        string expectedPattern = "pattern";

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedPattern, parameters.Pattern);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ListListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Pattern);
        Assert.False(parameters.RawQueryData.ContainsKey("pattern"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ListListParams { Cursor = null, Pattern = null };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Pattern);
        Assert.False(parameters.RawQueryData.ContainsKey("pattern"));
    }
}
