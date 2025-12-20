using Courier.Models.Notifications.Draft;

namespace Courier.Tests.Models.Notifications.Draft;

public class DraftRetrieveContentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DraftRetrieveContentParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }
}
