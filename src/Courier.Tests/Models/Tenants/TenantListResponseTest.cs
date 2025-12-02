using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;
using Courier.Models.Tenants;

namespace Courier.Tests.Models.Tenants;

public class TenantListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TenantListResponse
        {
            HasMore = true,
            Items =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    BrandID = "brand_id",
                    DefaultPreferences = new()
                    {
                        Items =
                        [
                            new()
                            {
                                Status = Status.OptedOut,
                                CustomRouting = [ChannelClassification.DirectMessage],
                                HasCustomRouting = true,
                                ID = "id",
                            },
                        ],
                    },
                    ParentTenantID = "parent_tenant_id",
                    Properties = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    UserProfile = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
            ],
            Type = TenantListResponseType.List,
            URL = "url",
            Cursor = "cursor",
            NextURL = "next_url",
        };

        bool expectedHasMore = true;
        List<Tenant> expectedItems =
        [
            new()
            {
                ID = "id",
                Name = "name",
                BrandID = "brand_id",
                DefaultPreferences = new()
                {
                    Items =
                    [
                        new()
                        {
                            Status = Status.OptedOut,
                            CustomRouting = [ChannelClassification.DirectMessage],
                            HasCustomRouting = true,
                            ID = "id",
                        },
                    ],
                },
                ParentTenantID = "parent_tenant_id",
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                UserProfile = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        ];
        ApiEnum<string, TenantListResponseType> expectedType = TenantListResponseType.List;
        string expectedURL = "url";
        string expectedCursor = "cursor";
        string expectedNextURL = "next_url";

        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedURL, model.URL);
        Assert.Equal(expectedCursor, model.Cursor);
        Assert.Equal(expectedNextURL, model.NextURL);
    }
}
