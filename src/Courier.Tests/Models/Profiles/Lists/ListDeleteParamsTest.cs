using Courier.Models.Profiles.Lists;

namespace Courier.Tests.Models.Profiles.Lists;

public class ListDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ListDeleteParams { UserID = "user_id" };

        string expectedUserID = "user_id";

        Assert.Equal(expectedUserID, parameters.UserID);
    }
}
