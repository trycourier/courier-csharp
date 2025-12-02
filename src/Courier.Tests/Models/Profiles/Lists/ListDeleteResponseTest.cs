using Courier.Core;
using Courier.Models.Profiles.Lists;

namespace Courier.Tests.Models.Profiles.Lists;

public class ListDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ListDeleteResponse { Status = Status.Success };

        ApiEnum<string, Status> expectedStatus = Status.Success;

        Assert.Equal(expectedStatus, model.Status);
    }
}
