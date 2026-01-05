using Courier.Models.Users.Preferences;

namespace Courier.Tests.Models.Users.Preferences;

public class PreferenceRetrieveTopicParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PreferenceRetrieveTopicParams
        {
            UserID = "user_id",
            TopicID = "topic_id",
            TenantID = "tenant_id",
        };

        string expectedUserID = "user_id";
        string expectedTopicID = "topic_id";
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedTopicID, parameters.TopicID);
        Assert.Equal(expectedTenantID, parameters.TenantID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PreferenceRetrieveTopicParams
        {
            UserID = "user_id",
            TopicID = "topic_id",
        };

        Assert.Null(parameters.TenantID);
        Assert.False(parameters.RawQueryData.ContainsKey("tenant_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PreferenceRetrieveTopicParams
        {
            UserID = "user_id",
            TopicID = "topic_id",

            TenantID = null,
        };

        Assert.Null(parameters.TenantID);
        Assert.False(parameters.RawQueryData.ContainsKey("tenant_id"));
    }
}
