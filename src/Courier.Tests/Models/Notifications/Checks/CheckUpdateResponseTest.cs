using System.Collections.Generic;
using Courier.Models.Notifications;
using Courier.Models.Notifications.Checks;

namespace Courier.Tests.Models.Notifications.Checks;

public class CheckUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckUpdateResponse
        {
            Checks =
            [
                new()
                {
                    ID = "id",
                    Status = Status.Resolved,
                    Type = Type.Custom,
                    Updated = 0,
                },
            ],
        };

        List<Check> expectedChecks =
        [
            new()
            {
                ID = "id",
                Status = Status.Resolved,
                Type = Type.Custom,
                Updated = 0,
            },
        ];

        Assert.Equal(expectedChecks.Count, model.Checks.Count);
        for (int i = 0; i < expectedChecks.Count; i++)
        {
            Assert.Equal(expectedChecks[i], model.Checks[i]);
        }
    }
}
