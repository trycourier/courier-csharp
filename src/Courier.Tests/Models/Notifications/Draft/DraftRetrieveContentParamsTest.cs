using System;
using Courier.Models.Notifications.Draft;

namespace Courier.Tests.Models.Notifications.Draft;

public class DraftRetrieveContentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DraftRetrieveContentParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        DraftRetrieveContentParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/notifications/id/draft/content"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DraftRetrieveContentParams { ID = "id" };

        DraftRetrieveContentParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
