using Courier.Core;
using Courier.Models.Notifications;

namespace Courier.Tests.Models.Notifications;

public class CheckTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Check
        {
            ID = "id",
            Status = Status.Resolved,
            Type = Type.Custom,
            Updated = 0,
        };

        string expectedID = "id";
        ApiEnum<string, Status> expectedStatus = Status.Resolved;
        ApiEnum<string, Type> expectedType = Type.Custom;
        long expectedUpdated = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdated, model.Updated);
    }
}

public class IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntersectionMember1 { Updated = 0 };

        long expectedUpdated = 0;

        Assert.Equal(expectedUpdated, model.Updated);
    }
}
