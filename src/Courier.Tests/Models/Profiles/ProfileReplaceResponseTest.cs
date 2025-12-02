using Courier.Core;
using Courier.Models.Profiles;

namespace Courier.Tests.Models.Profiles;

public class ProfileReplaceResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProfileReplaceResponse { Status = ProfileReplaceResponseStatus.Success };

        ApiEnum<string, ProfileReplaceResponseStatus> expectedStatus =
            ProfileReplaceResponseStatus.Success;

        Assert.Equal(expectedStatus, model.Status);
    }
}
