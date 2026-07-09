using System;
using TryCourier.Models.WorkspacePreferences;

namespace TryCourier.Tests.Models.WorkspacePreferences;

public class WorkspacePreferencePublishParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkspacePreferencePublishParams
        {
            BrandID = "brand_id",
            Description = "description",
            Heading = "heading",
        };

        string expectedBrandID = "brand_id";
        string expectedDescription = "description";
        string expectedHeading = "heading";

        Assert.Equal(expectedBrandID, parameters.BrandID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedHeading, parameters.Heading);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkspacePreferencePublishParams { };

        Assert.Null(parameters.BrandID);
        Assert.False(parameters.RawBodyData.ContainsKey("brand_id"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Heading);
        Assert.False(parameters.RawBodyData.ContainsKey("heading"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WorkspacePreferencePublishParams
        {
            BrandID = null,
            Description = null,
            Heading = null,
        };

        Assert.Null(parameters.BrandID);
        Assert.True(parameters.RawBodyData.ContainsKey("brand_id"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Heading);
        Assert.True(parameters.RawBodyData.ContainsKey("heading"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkspacePreferencePublishParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/preferences/publish"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkspacePreferencePublishParams
        {
            BrandID = "brand_id",
            Description = "description",
            Heading = "heading",
        };

        WorkspacePreferencePublishParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
