using System;
using Courier.Models.Journeys.Templates;

namespace Courier.Tests.Models.Journeys.Templates;

public class TemplateListVersionsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateListVersionsParams { TemplateID = "x", NotificationID = "x" };

        string expectedTemplateID = "x";
        string expectedNotificationID = "x";

        Assert.Equal(expectedTemplateID, parameters.TemplateID);
        Assert.Equal(expectedNotificationID, parameters.NotificationID);
    }

    [Fact]
    public void Url_Works()
    {
        TemplateListVersionsParams parameters = new() { TemplateID = "x", NotificationID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/journeys/x/templates/x/versions"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TemplateListVersionsParams { TemplateID = "x", NotificationID = "x" };

        TemplateListVersionsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
