using Courier.Core;
using Courier.Models.Profiles;

namespace Courier.Tests.Models.Profiles;

public class ProfileCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProfileCreateResponse { Status = Status.Success };

        ApiEnum<string, Status> expectedStatus = Status.Success;

        Assert.Equal(expectedStatus, model.Status);
    }
}
