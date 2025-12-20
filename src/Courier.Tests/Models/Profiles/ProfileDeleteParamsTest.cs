using Courier.Models.Profiles;

namespace Courier.Tests.Models.Profiles;

public class ProfileDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProfileDeleteParams { UserID = "user_id" };

        string expectedUserID = "user_id";

        Assert.Equal(expectedUserID, parameters.UserID);
    }
}
