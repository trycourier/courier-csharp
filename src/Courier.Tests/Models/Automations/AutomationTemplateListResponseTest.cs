using System;
using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models.Automations;

namespace Courier.Tests.Models.Automations;

public class AutomationTemplateListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutomationTemplateListResponse
        {
            Cursor = "cursor",
            Templates =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Version = AutomationTemplateVersion.Published,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string expectedCursor = "cursor";
        List<AutomationTemplate> expectedTemplates =
        [
            new()
            {
                ID = "id",
                Name = "name",
                Version = AutomationTemplateVersion.Published,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedCursor, model.Cursor);
        Assert.NotNull(model.Templates);
        Assert.Equal(expectedTemplates.Count, model.Templates.Count);
        for (int i = 0; i < expectedTemplates.Count; i++)
        {
            Assert.Equal(expectedTemplates[i], model.Templates[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutomationTemplateListResponse
        {
            Cursor = "cursor",
            Templates =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Version = AutomationTemplateVersion.Published,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutomationTemplateListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutomationTemplateListResponse
        {
            Cursor = "cursor",
            Templates =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Version = AutomationTemplateVersion.Published,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutomationTemplateListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCursor = "cursor";
        List<AutomationTemplate> expectedTemplates =
        [
            new()
            {
                ID = "id",
                Name = "name",
                Version = AutomationTemplateVersion.Published,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedCursor, deserialized.Cursor);
        Assert.NotNull(deserialized.Templates);
        Assert.Equal(expectedTemplates.Count, deserialized.Templates.Count);
        for (int i = 0; i < expectedTemplates.Count; i++)
        {
            Assert.Equal(expectedTemplates[i], deserialized.Templates[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutomationTemplateListResponse
        {
            Cursor = "cursor",
            Templates =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Version = AutomationTemplateVersion.Published,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AutomationTemplateListResponse { };

        Assert.Null(model.Cursor);
        Assert.False(model.RawData.ContainsKey("cursor"));
        Assert.Null(model.Templates);
        Assert.False(model.RawData.ContainsKey("templates"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AutomationTemplateListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AutomationTemplateListResponse
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Templates = null,
        };

        Assert.Null(model.Cursor);
        Assert.False(model.RawData.ContainsKey("cursor"));
        Assert.Null(model.Templates);
        Assert.False(model.RawData.ContainsKey("templates"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AutomationTemplateListResponse
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Templates = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AutomationTemplateListResponse
        {
            Cursor = "cursor",
            Templates =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Version = AutomationTemplateVersion.Published,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        AutomationTemplateListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
