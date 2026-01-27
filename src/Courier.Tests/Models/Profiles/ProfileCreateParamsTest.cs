using System;
using System.Collections.Generic;
using System.Text.Json;
using Courier.Models.Profiles;

namespace Courier.Tests.Models.Profiles;

public class ProfileCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProfileCreateParams
        {
            UserID = "user_id",
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedUserID = "user_id";
        Dictionary<string, JsonElement> expectedProfile = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedProfile.Count, parameters.Profile.Count);
        foreach (var item in expectedProfile)
        {
            Assert.True(parameters.Profile.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Profile[item.Key]));
        }
    }

    [Fact]
    public void Url_Works()
    {
        ProfileCreateParams parameters = new()
        {
            UserID = "user_id",
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/profiles/user_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProfileCreateParams
        {
            UserID = "user_id",
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        ProfileCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
