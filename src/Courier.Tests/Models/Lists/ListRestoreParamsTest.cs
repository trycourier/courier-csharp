using System;
using Courier.Models.Lists;

namespace Courier.Tests.Models.Lists;

public class ListRestoreParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ListRestoreParams { ListID = "list_id" };

        string expectedListID = "list_id";

        Assert.Equal(expectedListID, parameters.ListID);
    }

    [Fact]
    public void Url_Works()
    {
        ListRestoreParams parameters = new() { ListID = "list_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/lists/list_id/restore"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ListRestoreParams { ListID = "list_id" };

        ListRestoreParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
