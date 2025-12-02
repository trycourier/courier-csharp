using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models.Tenants;

namespace Courier.Tests.Models.Tenants;

public class TenantAssociationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TenantAssociation
        {
            TenantID = "tenant_id",
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Type.User,
            UserID = "user_id",
        };

        string expectedTenantID = "tenant_id";
        Dictionary<string, JsonElement> expectedProfile = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, Type> expectedType = Type.User;
        string expectedUserID = "user_id";

        Assert.Equal(expectedTenantID, model.TenantID);
        Assert.Equal(expectedProfile.Count, model.Profile.Count);
        foreach (var item in expectedProfile)
        {
            Assert.True(model.Profile.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Profile[item.Key]));
        }
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUserID, model.UserID);
    }
}
