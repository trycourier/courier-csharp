using System;
using TryCourier.Models.WorkspacePreferences.Topics;

namespace TryCourier.Tests.Models.WorkspacePreferences.Topics;

public class TopicReleaseDigestParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TopicReleaseDigestParams
        {
            SectionID = "section_id",
            TopicID = "topic_id",
            UserID = "user_01h1p2c3d4e5f6g7h8",
            TenantID = "x",
        };

        string expectedSectionID = "section_id";
        string expectedTopicID = "topic_id";
        string expectedUserID = "user_01h1p2c3d4e5f6g7h8";
        string expectedTenantID = "x";

        Assert.Equal(expectedSectionID, parameters.SectionID);
        Assert.Equal(expectedTopicID, parameters.TopicID);
        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedTenantID, parameters.TenantID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TopicReleaseDigestParams
        {
            SectionID = "section_id",
            TopicID = "topic_id",
            UserID = "user_01h1p2c3d4e5f6g7h8",
        };

        Assert.Null(parameters.TenantID);
        Assert.False(parameters.RawBodyData.ContainsKey("tenant_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TopicReleaseDigestParams
        {
            SectionID = "section_id",
            TopicID = "topic_id",
            UserID = "user_01h1p2c3d4e5f6g7h8",

            // Null should be interpreted as omitted for these properties
            TenantID = null,
        };

        Assert.Null(parameters.TenantID);
        Assert.False(parameters.RawBodyData.ContainsKey("tenant_id"));
    }

    [Fact]
    public void Url_Works()
    {
        TopicReleaseDigestParams parameters = new()
        {
            SectionID = "section_id",
            TopicID = "topic_id",
            UserID = "user_01h1p2c3d4e5f6g7h8",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.courier.com/preferences/sections/section_id/topics/topic_id/digest/release"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TopicReleaseDigestParams
        {
            SectionID = "section_id",
            TopicID = "topic_id",
            UserID = "user_01h1p2c3d4e5f6g7h8",
            TenantID = "x",
        };

        TopicReleaseDigestParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
