using System;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new JourneyCancelParams
        {
            CancelJourneyRequest = new ByCancelationToken("order-1234"),
        };

        CancelJourneyRequest expectedCancelJourneyRequest = new ByCancelationToken("order-1234");

        Assert.Equal(expectedCancelJourneyRequest, parameters.CancelJourneyRequest);
    }

    [Fact]
    public void Url_Works()
    {
        JourneyCancelParams parameters = new()
        {
            CancelJourneyRequest = new ByCancelationToken("order-1234"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.courier.com/journeys/cancel"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new JourneyCancelParams
        {
            CancelJourneyRequest = new ByCancelationToken("order-1234"),
        };

        JourneyCancelParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
