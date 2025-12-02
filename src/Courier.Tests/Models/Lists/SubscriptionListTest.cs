using Courier.Models.Lists;

namespace Courier.Tests.Models.Lists;

public class SubscriptionListTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionList
        {
            ID = "id",
            Name = "name",
            Created = "created",
            Updated = "updated",
        };

        string expectedID = "id";
        string expectedName = "name";
        string expectedCreated = "created";
        string expectedUpdated = "updated";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedUpdated, model.Updated);
    }
}
