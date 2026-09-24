using System;
using TryCourier.Models.Notifications.Previews.Runs;

namespace TryCourier.Tests.Models.Notifications.Previews.Runs;

public class RunRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RunRetrieveParams { ID = "id", PreviewRunID = "previewRunId" };

        string expectedID = "id";
        string expectedPreviewRunID = "previewRunId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedPreviewRunID, parameters.PreviewRunID);
    }

    [Fact]
    public void Url_Works()
    {
        RunRetrieveParams parameters = new() { ID = "id", PreviewRunID = "previewRunId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/notifications/id/previews/runs/previewRunId"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RunRetrieveParams { ID = "id", PreviewRunID = "previewRunId" };

        RunRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
