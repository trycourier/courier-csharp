using Courier.Core;
using Courier.Models.Profiles.Lists;

namespace Courier.Tests.Models.Profiles.Lists;

public class ListSubscribeResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ListSubscribeResponse { Status = ListSubscribeResponseStatus.Success };

        ApiEnum<string, ListSubscribeResponseStatus> expectedStatus =
            ListSubscribeResponseStatus.Success;

        Assert.Equal(expectedStatus, model.Status);
    }
}
