using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models.Tenants;

namespace Courier.Tests.Models.Tenants;

public class TenantListUsersResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TenantListUsersResponse
        {
            HasMore = true,
            Type = TenantListUsersResponseType.List,
            URL = "url",
            Cursor = "cursor",
            Items =
            [
                new()
                {
                    TenantID = "tenant_id",
                    Profile = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = Type.User,
                    UserID = "user_id",
                },
            ],
            NextURL = "next_url",
        };

        bool expectedHasMore = true;
        ApiEnum<string, TenantListUsersResponseType> expectedType =
            TenantListUsersResponseType.List;
        string expectedURL = "url";
        string expectedCursor = "cursor";
        List<TenantAssociation> expectedItems =
        [
            new()
            {
                TenantID = "tenant_id",
                Profile = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Type = Type.User,
                UserID = "user_id",
            },
        ];
        string expectedNextURL = "next_url";

        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedURL, model.URL);
        Assert.Equal(expectedCursor, model.Cursor);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedNextURL, model.NextURL);
    }
}
