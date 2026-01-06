using System;
using Courier.Models.Lists;

namespace Courier.Tests.Models.Lists;

public class ListRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ListRetrieveParams { ListID = "list_id" };

        string expectedListID = "list_id";

        Assert.Equal(expectedListID, parameters.ListID);
    }

    [Fact]
    public void Url_Works()
    {
        ListRetrieveParams parameters = new() { ListID = "list_id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/lists/list_id"), url);
    }
}
