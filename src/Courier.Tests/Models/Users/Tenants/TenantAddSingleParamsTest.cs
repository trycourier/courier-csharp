using System;
using System.Collections.Generic;
using System.Text.Json;
using Courier.Models.Users.Tenants;

namespace Courier.Tests.Models.Users.Tenants;

public class TenantAddSingleParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TenantAddSingleParams
        {
            UserID = "user_id",
            TenantID = "tenant_id",
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedUserID = "user_id";
        string expectedTenantID = "tenant_id";
        Dictionary<string, JsonElement> expectedProfile = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedTenantID, parameters.TenantID);
        Assert.NotNull(parameters.Profile);
        Assert.Equal(expectedProfile.Count, parameters.Profile.Count);
        foreach (var item in expectedProfile)
        {
            Assert.True(parameters.Profile.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Profile[item.Key]));
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TenantAddSingleParams { UserID = "user_id", TenantID = "tenant_id" };

        Assert.Null(parameters.Profile);
        Assert.False(parameters.RawBodyData.ContainsKey("profile"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TenantAddSingleParams
        {
            UserID = "user_id",
            TenantID = "tenant_id",

            Profile = null,
        };

        Assert.Null(parameters.Profile);
        Assert.True(parameters.RawBodyData.ContainsKey("profile"));
    }

    [Fact]
    public void Url_Works()
    {
        TenantAddSingleParams parameters = new() { UserID = "user_id", TenantID = "tenant_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/users/user_id/tenants/tenant_id"), url);
    }
}
