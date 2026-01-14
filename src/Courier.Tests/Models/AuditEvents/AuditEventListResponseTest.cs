using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuditEventListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuditEventListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedPaging, deserialized.Paging);
        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }
}
