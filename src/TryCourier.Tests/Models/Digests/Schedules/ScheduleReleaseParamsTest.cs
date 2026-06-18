using System;
using TryCourier.Models.Digests.Schedules;

namespace TryCourier.Tests.Models.Digests.Schedules;

public class ScheduleReleaseParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ScheduleReleaseParams { ScheduleID = "schedule_id" };

        string expectedScheduleID = "schedule_id";

        Assert.Equal(expectedScheduleID, parameters.ScheduleID);
    }

    [Fact]
    public void Url_Works()
    {
        ScheduleReleaseParams parameters = new() { ScheduleID = "schedule_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/digests/schedules/schedule_id/trigger"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ScheduleReleaseParams { ScheduleID = "schedule_id" };

        ScheduleReleaseParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
