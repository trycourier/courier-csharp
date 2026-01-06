using System;
using Courier.Models.Lists;

namespace Courier.Tests.Models.Lists;

public class ListDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ListDeleteParams { ListID = "list_id" };

        string expectedListID = "list_id";

        Assert.Equal(expectedListID, parameters.ListID);
    }

    [Fact]
    public void Url_Works()
    {
        ListDeleteParams parameters = new() { ListID = "list_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/lists/list_id"), url);
    }
}
