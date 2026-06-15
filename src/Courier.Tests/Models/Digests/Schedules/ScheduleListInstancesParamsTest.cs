using System;
using Courier.Models.Digests.Schedules;

namespace Courier.Tests.Models.Digests.Schedules;

public class ScheduleListInstancesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ScheduleListInstancesParams
        {
            ScheduleID = "schedule_id",
            Cursor = "cursor",
            Limit = 100,
        };

        string expectedScheduleID = "schedule_id";
        string expectedCursor = "cursor";
        long expectedLimit = 100;

        Assert.Equal(expectedScheduleID, parameters.ScheduleID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ScheduleListInstancesParams { ScheduleID = "schedule_id" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ScheduleListInstancesParams
        {
            ScheduleID = "schedule_id",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Limit = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        ScheduleListInstancesParams parameters = new()
        {
            ScheduleID = "schedule_id",
            Cursor = "cursor",
            Limit = 100,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.courier.com/digests/schedules/schedule_id/instances?cursor=cursor&limit=100"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ScheduleListInstancesParams
        {
            ScheduleID = "schedule_id",
            Cursor = "cursor",
            Limit = 100,
        };

        ScheduleListInstancesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
