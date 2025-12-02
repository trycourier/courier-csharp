using System.Collections.Generic;
using Courier.Models;
using Courier.Models.Lists;

namespace Courier.Tests.Models.Lists;

public class ListListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ListListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Created = "created",
                    Updated = "updated",
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        List<SubscriptionList> expectedItems =
        [
            new()
            {
                ID = "id",
                Name = "name",
                Created = "created",
                Updated = "updated",
            },
        ];
        Paging expectedPaging = new() { More = true, Cursor = "cursor" };

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedPaging, model.Paging);
    }
}
