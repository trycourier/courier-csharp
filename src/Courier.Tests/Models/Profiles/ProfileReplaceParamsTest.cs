using System.Collections.Generic;
using System.Text.Json;
using Courier.Models.Profiles;

namespace Courier.Tests.Models.Profiles;

public class ProfileReplaceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProfileReplaceParams
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
}
