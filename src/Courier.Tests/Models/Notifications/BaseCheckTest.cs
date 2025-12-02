using Courier.Core;
using Courier.Models.Notifications;

namespace Courier.Tests.Models.Notifications;

public class BaseCheckTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BaseCheck
        {
            ID = "id",
            Status = Status.Resolved,
            Type = Type.Custom,
        };

        string expectedID = "id";
        ApiEnum<string, Status> expectedStatus = Status.Resolved;
        ApiEnum<string, Type> expectedType = Type.Custom;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }
}
