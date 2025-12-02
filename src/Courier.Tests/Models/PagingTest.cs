using Courier.Models;

namespace Courier.Tests.Models;

public class PagingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Paging { More = true, Cursor = "cursor" };

        bool expectedMore = true;
        string expectedCursor = "cursor";

        Assert.Equal(expectedMore, model.More);
        Assert.Equal(expectedCursor, model.Cursor);
    }
}
