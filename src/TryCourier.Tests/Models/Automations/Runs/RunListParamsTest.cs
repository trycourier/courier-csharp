using System;
using TryCourier.Models.Automations.Runs;

namespace TryCourier.Tests.Models.Automations.Runs;

public class RunListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RunListParams
        {
            Cursor = "cursor",
            EndDate = "end_date",
            Limit = "321669910225",
            StartDate = "start_date",
            Status = "status",
            TemplateID = "template_id",
        };

        string expectedCursor = "cursor";
        string expectedEndDate = "end_date";
        string expectedLimit = "321669910225";
        string expectedStartDate = "start_date";
        string expectedStatus = "status";
        string expectedTemplateID = "template_id";

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedEndDate, parameters.EndDate);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStartDate, parameters.StartDate);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedTemplateID, parameters.TemplateID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RunListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawQueryData.ContainsKey("end_date"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawQueryData.ContainsKey("start_date"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.TemplateID);
        Assert.False(parameters.RawQueryData.ContainsKey("template_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RunListParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            EndDate = null,
            Limit = null,
            StartDate = null,
            Status = null,
            TemplateID = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawQueryData.ContainsKey("end_date"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawQueryData.ContainsKey("start_date"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.TemplateID);
        Assert.False(parameters.RawQueryData.ContainsKey("template_id"));
    }

    [Fact]
    public void Url_Works()
    {
        RunListParams parameters = new()
        {
            Cursor = "cursor",
            EndDate = "end_date",
            Limit = "321669910225",
            StartDate = "start_date",
            Status = "status",
            TemplateID = "template_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.courier.com/automations/runs?cursor=cursor&end_date=end_date&limit=321669910225&start_date=start_date&status=status&template_id=template_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RunListParams
        {
            Cursor = "cursor",
            EndDate = "end_date",
            Limit = "321669910225",
            StartDate = "start_date",
            Status = "status",
            TemplateID = "template_id",
        };

        RunListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
