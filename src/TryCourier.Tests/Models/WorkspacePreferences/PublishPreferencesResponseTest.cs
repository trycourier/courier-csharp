using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.WorkspacePreferences;

namespace TryCourier.Tests.Models.WorkspacePreferences;

public class PublishPreferencesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PublishPreferencesResponse
        {
            PageID = "page_id",
            PublishedAt = "published_at",
            PublishedVersion = 0,
            PreviewUrl = "preview_url",
            PublishedBy = "published_by",
        };

        string expectedPageID = "page_id";
        string expectedPublishedAt = "published_at";
        double expectedPublishedVersion = 0;
        string expectedPreviewUrl = "preview_url";
        string expectedPublishedBy = "published_by";

        Assert.Equal(expectedPageID, model.PageID);
        Assert.Equal(expectedPublishedAt, model.PublishedAt);
        Assert.Equal(expectedPublishedVersion, model.PublishedVersion);
        Assert.Equal(expectedPreviewUrl, model.PreviewUrl);
        Assert.Equal(expectedPublishedBy, model.PublishedBy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PublishPreferencesResponse
        {
            PageID = "page_id",
            PublishedAt = "published_at",
            PublishedVersion = 0,
            PreviewUrl = "preview_url",
            PublishedBy = "published_by",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PublishPreferencesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PublishPreferencesResponse
        {
            PageID = "page_id",
            PublishedAt = "published_at",
            PublishedVersion = 0,
            PreviewUrl = "preview_url",
            PublishedBy = "published_by",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PublishPreferencesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPageID = "page_id";
        string expectedPublishedAt = "published_at";
        double expectedPublishedVersion = 0;
        string expectedPreviewUrl = "preview_url";
        string expectedPublishedBy = "published_by";

        Assert.Equal(expectedPageID, deserialized.PageID);
        Assert.Equal(expectedPublishedAt, deserialized.PublishedAt);
        Assert.Equal(expectedPublishedVersion, deserialized.PublishedVersion);
        Assert.Equal(expectedPreviewUrl, deserialized.PreviewUrl);
        Assert.Equal(expectedPublishedBy, deserialized.PublishedBy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PublishPreferencesResponse
        {
            PageID = "page_id",
            PublishedAt = "published_at",
            PublishedVersion = 0,
            PreviewUrl = "preview_url",
            PublishedBy = "published_by",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PublishPreferencesResponse
        {
            PageID = "page_id",
            PublishedAt = "published_at",
            PublishedVersion = 0,
        };

        Assert.Null(model.PreviewUrl);
        Assert.False(model.RawData.ContainsKey("preview_url"));
        Assert.Null(model.PublishedBy);
        Assert.False(model.RawData.ContainsKey("published_by"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PublishPreferencesResponse
        {
            PageID = "page_id",
            PublishedAt = "published_at",
            PublishedVersion = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PublishPreferencesResponse
        {
            PageID = "page_id",
            PublishedAt = "published_at",
            PublishedVersion = 0,

            PreviewUrl = null,
            PublishedBy = null,
        };

        Assert.Null(model.PreviewUrl);
        Assert.True(model.RawData.ContainsKey("preview_url"));
        Assert.Null(model.PublishedBy);
        Assert.True(model.RawData.ContainsKey("published_by"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PublishPreferencesResponse
        {
            PageID = "page_id",
            PublishedAt = "published_at",
            PublishedVersion = 0,

            PreviewUrl = null,
            PublishedBy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PublishPreferencesResponse
        {
            PageID = "page_id",
            PublishedAt = "published_at",
            PublishedVersion = 0,
            PreviewUrl = "preview_url",
            PublishedBy = "published_by",
        };

        PublishPreferencesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
