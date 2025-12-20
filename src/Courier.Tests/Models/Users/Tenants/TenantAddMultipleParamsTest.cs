using System.Collections.Generic;
using System.Text.Json;
using Courier.Models.Users.Tenants;
using Tenants = Courier.Models.Tenants;

namespace Courier.Tests.Models.Users.Tenants;

public class TenantAddMultipleParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TenantAddMultipleParams
        {
            UserID = "user_id",
            Tenants =
            [
                new()
                {
                    TenantID = "tenant_id",
                    Profile = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = Tenants::Type.User,
                    UserID = "user_id",
                },
            ],
        };

        string expectedUserID = "user_id";
        List<Tenants::TenantAssociation> expectedTenants =
        [
            new()
            {
                TenantID = "tenant_id",
                Profile = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Type = Tenants::Type.User,
                UserID = "user_id",
            },
        ];

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedTenants.Count, parameters.Tenants.Count);
        for (int i = 0; i < expectedTenants.Count; i++)
        {
            Assert.Equal(expectedTenants[i], parameters.Tenants[i]);
        }
    }
}
