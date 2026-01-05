using Courier.Models.Lists;

namespace Courier.Tests.Models.Lists;

public class ListRestoreParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ListRestoreParams { ListID = "list_id" };

        string expectedListID = "list_id";

        Assert.Equal(expectedListID, parameters.ListID);
    }
}
