using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.WorkspacePreferences;

namespace TryCourier.Tests.Models.WorkspacePreferences;

public class PublishPreferencesRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PublishPreferencesRequest
        {
            BrandID = "brand_id",
            Description = "description",
            Heading = "heading",
        };

        string expectedBrandID = "brand_id";
        string expectedDescription = "description";
        string expectedHeading = "heading";

        Assert.Equal(expectedBrandID, model.BrandID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedHeading, model.Heading);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PublishPreferencesRequest
        {
            BrandID = "brand_id",
            Description = "description",
            Heading = "heading",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PublishPreferencesRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PublishPreferencesRequest
        {
            BrandID = "brand_id",
            Description = "description",
            Heading = "heading",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PublishPreferencesRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBrandID = "brand_id";
        string expectedDescription = "description";
        string expectedHeading = "heading";

        Assert.Equal(expectedBrandID, deserialized.BrandID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedHeading, deserialized.Heading);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PublishPreferencesRequest
        {
            BrandID = "brand_id",
            Description = "description",
            Heading = "heading",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PublishPreferencesRequest { };

        Assert.Null(model.BrandID);
        Assert.False(model.RawData.ContainsKey("brand_id"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Heading);
        Assert.False(model.RawData.ContainsKey("heading"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PublishPreferencesRequest { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PublishPreferencesRequest
        {
            BrandID = null,
            Description = null,
            Heading = null,
        };

        Assert.Null(model.BrandID);
        Assert.True(model.RawData.ContainsKey("brand_id"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Heading);
        Assert.True(model.RawData.ContainsKey("heading"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PublishPreferencesRequest
        {
            BrandID = null,
            Description = null,
            Heading = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PublishPreferencesRequest
        {
            BrandID = "brand_id",
            Description = "description",
            Heading = "heading",
        };

        PublishPreferencesRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
