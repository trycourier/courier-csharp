using System.Collections.Generic;
using Courier.Core;
using Courier.Models.Tenants;
using Models = Courier.Models;

namespace Courier.Tests.Models.Tenants;

public class DefaultPreferencesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DefaultPreferences
        {
            Items =
            [
                new()
                {
                    Status = Status.OptedOut,
                    CustomRouting = [Models::ChannelClassification.DirectMessage],
                    HasCustomRouting = true,
                    ID = "id",
                },
            ],
        };

        List<Item> expectedItems =
        [
            new()
            {
                Status = Status.OptedOut,
                CustomRouting = [Models::ChannelClassification.DirectMessage],
                HasCustomRouting = true,
                ID = "id",
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
        {
            Status = Status.OptedOut,
            CustomRouting = [Models::ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            ID = "id",
        };

        ApiEnum<string, Status> expectedStatus = Status.OptedOut;
        List<ApiEnum<string, Models::ChannelClassification>> expectedCustomRouting =
        [
            Models::ChannelClassification.DirectMessage,
        ];
        bool expectedHasCustomRouting = true;
        string expectedID = "id";

        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedCustomRouting.Count, model.CustomRouting.Count);
        for (int i = 0; i < expectedCustomRouting.Count; i++)
        {
            Assert.Equal(expectedCustomRouting[i], model.CustomRouting[i]);
        }
        Assert.Equal(expectedHasCustomRouting, model.HasCustomRouting);
        Assert.Equal(expectedID, model.ID);
    }
}

public class IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntersectionMember1 { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }
}
