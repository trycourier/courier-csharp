using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;
using Courier.Models.Notifications;
using Courier.Models.RoutingStrategies;

namespace Courier.Tests.Models.RoutingStrategies;

public class AssociatedNotificationListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AssociatedNotificationListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Created = 0,
                    Creator = "creator",
                    Name = "name",
                    State = NotificationTemplateSummaryState.Draft,
                    Tags = ["string"],
                    Updated = 0,
                    Updater = "updater",
                },
            ],
        };

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<NotificationTemplateSummary> expectedResults =
        [
            new()
            {
                ID = "id",
                Created = 0,
                Creator = "creator",
                Name = "name",
                State = NotificationTemplateSummaryState.Draft,
                Tags = ["string"],
                Updated = 0,
                Updater = "updater",
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
        var model = new AssociatedNotificationListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Created = 0,
                    Creator = "creator",
                    Name = "name",
                    State = NotificationTemplateSummaryState.Draft,
                    Tags = ["string"],
                    Updated = 0,
                    Updater = "updater",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AssociatedNotificationListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AssociatedNotificationListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Created = 0,
                    Creator = "creator",
                    Name = "name",
                    State = NotificationTemplateSummaryState.Draft,
                    Tags = ["string"],
                    Updated = 0,
                    Updater = "updater",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AssociatedNotificationListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<NotificationTemplateSummary> expectedResults =
        [
            new()
            {
                ID = "id",
                Created = 0,
                Creator = "creator",
                Name = "name",
                State = NotificationTemplateSummaryState.Draft,
                Tags = ["string"],
                Updated = 0,
                Updater = "updater",
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
        var model = new AssociatedNotificationListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Created = 0,
                    Creator = "creator",
                    Name = "name",
                    State = NotificationTemplateSummaryState.Draft,
                    Tags = ["string"],
                    Updated = 0,
                    Updater = "updater",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AssociatedNotificationListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Created = 0,
                    Creator = "creator",
                    Name = "name",
                    State = NotificationTemplateSummaryState.Draft,
                    Tags = ["string"],
                    Updated = 0,
                    Updater = "updater",
                },
            ],
        };

        AssociatedNotificationListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
