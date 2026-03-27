using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;
using Courier.Models.Notifications;

namespace Courier.Tests.Models.Notifications;

public class NotificationTemplateVersionListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotificationTemplateVersionListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Versions =
            [
                new()
                {
                    Created = 0,
                    Creator = "creator",
                    Version = "version",
                    HasChanges = true,
                },
            ],
        };

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<VersionNode> expectedVersions =
        [
            new()
            {
                Created = 0,
                Creator = "creator",
                Version = "version",
                HasChanges = true,
            },
        ];

        Assert.Equal(expectedPaging, model.Paging);
        Assert.Equal(expectedVersions.Count, model.Versions.Count);
        for (int i = 0; i < expectedVersions.Count; i++)
        {
            Assert.Equal(expectedVersions[i], model.Versions[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotificationTemplateVersionListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Versions =
            [
                new()
                {
                    Created = 0,
                    Creator = "creator",
                    Version = "version",
                    HasChanges = true,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationTemplateVersionListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotificationTemplateVersionListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Versions =
            [
                new()
                {
                    Created = 0,
                    Creator = "creator",
                    Version = "version",
                    HasChanges = true,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationTemplateVersionListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<VersionNode> expectedVersions =
        [
            new()
            {
                Created = 0,
                Creator = "creator",
                Version = "version",
                HasChanges = true,
            },
        ];

        Assert.Equal(expectedPaging, deserialized.Paging);
        Assert.Equal(expectedVersions.Count, deserialized.Versions.Count);
        for (int i = 0; i < expectedVersions.Count; i++)
        {
            Assert.Equal(expectedVersions[i], deserialized.Versions[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotificationTemplateVersionListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Versions =
            [
                new()
                {
                    Created = 0,
                    Creator = "creator",
                    Version = "version",
                    HasChanges = true,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NotificationTemplateVersionListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Versions =
            [
                new()
                {
                    Created = 0,
                    Creator = "creator",
                    Version = "version",
                    HasChanges = true,
                },
            ],
        };

        NotificationTemplateVersionListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
