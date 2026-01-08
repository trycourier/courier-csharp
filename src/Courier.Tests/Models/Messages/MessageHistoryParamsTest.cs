using System;
using Courier.Models.Messages;

namespace Courier.Tests.Models.Messages;

public class MessageHistoryParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MessageHistoryParams { MessageID = "message_id", Type = "type" };

        string expectedMessageID = "message_id";
        string expectedType = "type";

        Assert.Equal(expectedMessageID, parameters.MessageID);
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MessageHistoryParams { MessageID = "message_id" };

        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MessageHistoryParams
        {
            MessageID = "message_id",

            Type = null,
        };

        Assert.Null(parameters.Type);
        Assert.True(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        MessageHistoryParams parameters = new() { MessageID = "message_id", Type = "type" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/messages/message_id/history?type=type"), url);
    }
}
