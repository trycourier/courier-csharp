using System;
using TryCourier.Models.Journeys.Templates;

namespace TryCourier.Tests.Models.Journeys.Templates;

public class TemplateArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateArchiveParams { TemplateID = "x", NotificationID = "x" };

        string expectedTemplateID = "x";
        string expectedNotificationID = "x";

        Assert.Equal(expectedTemplateID, parameters.TemplateID);
        Assert.Equal(expectedNotificationID, parameters.NotificationID);
    }

    [Fact]
    public void Url_Works()
    {
        TemplateArchiveParams parameters = new() { TemplateID = "x", NotificationID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/journeys/x/templates/x"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TemplateArchiveParams { TemplateID = "x", NotificationID = "x" };

        TemplateArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
