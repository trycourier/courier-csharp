using System.Collections.Generic;
using Courier.Models;
using Courier.Models.AuditEvents;

namespace Courier.Tests.Models.AuditEvents;

public class AuditEventListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AuditEventListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    Actor = new() { ID = "id", Email = "email" },
                    AuditEventID = "auditEventId",
                    Source = "source",
                    Target = "target",
                    Timestamp = "timestamp",
                    Type = "type",
                },
            ],
        };

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<AuditEvent> expectedResults =
        [
            new()
            {
                Actor = new() { ID = "id", Email = "email" },
                AuditEventID = "auditEventId",
                Source = "source",
                Target = "target",
                Timestamp = "timestamp",
                Type = "type",
            },
        ];

        Assert.Equal(expectedPaging, model.Paging);
        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
    }
}
