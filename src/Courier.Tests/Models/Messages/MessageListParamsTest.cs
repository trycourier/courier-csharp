using System;
using System.Collections.Generic;
using Courier.Models.Messages;

namespace Courier.Tests.Models.Messages;

public class MessageListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MessageListParams
        {
            Archived = true,
            Cursor = "cursor",
            EnqueuedAfter = "enqueued_after",
            Event = "event",
            List = "list",
            MessageID = "messageId",
            Notification = "notification",
            Provider = ["string"],
            Recipient = "recipient",
            Status = ["string"],
            Tag = ["string"],
            Tags = "tags",
            TenantID = "tenant_id",
            TraceID = "traceId",
        };

        bool expectedArchived = true;
        string expectedCursor = "cursor";
        string expectedEnqueuedAfter = "enqueued_after";
        string expectedEvent = "event";
        string expectedList = "list";
        string expectedMessageID = "messageId";
        string expectedNotification = "notification";
        List<string?> expectedProvider = ["string"];
        string expectedRecipient = "recipient";
        List<string?> expectedStatus = ["string"];
        List<string?> expectedTag = ["string"];
        string expectedTags = "tags";
        string expectedTenantID = "tenant_id";
        string expectedTraceID = "traceId";

        Assert.Equal(expectedArchived, parameters.Archived);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedEnqueuedAfter, parameters.EnqueuedAfter);
        Assert.Equal(expectedEvent, parameters.Event);
        Assert.Equal(expectedList, parameters.List);
        Assert.Equal(expectedMessageID, parameters.MessageID);
        Assert.Equal(expectedNotification, parameters.Notification);
        Assert.NotNull(parameters.Provider);
        Assert.Equal(expectedProvider.Count, parameters.Provider.Count);
        for (int i = 0; i < expectedProvider.Count; i++)
        {
            Assert.Equal(expectedProvider[i], parameters.Provider[i]);
        }
        Assert.Equal(expectedRecipient, parameters.Recipient);
        Assert.NotNull(parameters.Status);
        Assert.Equal(expectedStatus.Count, parameters.Status.Count);
        for (int i = 0; i < expectedStatus.Count; i++)
        {
            Assert.Equal(expectedStatus[i], parameters.Status[i]);
        }
        Assert.NotNull(parameters.Tag);
        Assert.Equal(expectedTag.Count, parameters.Tag.Count);
        for (int i = 0; i < expectedTag.Count; i++)
        {
            Assert.Equal(expectedTag[i], parameters.Tag[i]);
        }
        Assert.Equal(expectedTags, parameters.Tags);
        Assert.Equal(expectedTenantID, parameters.TenantID);
        Assert.Equal(expectedTraceID, parameters.TraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MessageListParams
        {
            Archived = true,
            Cursor = "cursor",
            EnqueuedAfter = "enqueued_after",
            Event = "event",
            List = "list",
            MessageID = "messageId",
            Notification = "notification",
            Recipient = "recipient",
            Tags = "tags",
            TenantID = "tenant_id",
            TraceID = "traceId",
        };

        Assert.Null(parameters.Provider);
        Assert.False(parameters.RawQueryData.ContainsKey("provider"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.Tag);
        Assert.False(parameters.RawQueryData.ContainsKey("tag"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MessageListParams
        {
            Archived = true,
            Cursor = "cursor",
            EnqueuedAfter = "enqueued_after",
            Event = "event",
            List = "list",
            MessageID = "messageId",
            Notification = "notification",
            Recipient = "recipient",
            Tags = "tags",
            TenantID = "tenant_id",
            TraceID = "traceId",

            // Null should be interpreted as omitted for these properties
            Provider = null,
            Status = null,
            Tag = null,
        };

        Assert.Null(parameters.Provider);
        Assert.False(parameters.RawQueryData.ContainsKey("provider"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.Tag);
        Assert.False(parameters.RawQueryData.ContainsKey("tag"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MessageListParams
        {
            Provider = ["string"],
            Status = ["string"],
            Tag = ["string"],
        };

        Assert.Null(parameters.Archived);
        Assert.False(parameters.RawQueryData.ContainsKey("archived"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.EnqueuedAfter);
        Assert.False(parameters.RawQueryData.ContainsKey("enqueued_after"));
        Assert.Null(parameters.Event);
        Assert.False(parameters.RawQueryData.ContainsKey("event"));
        Assert.Null(parameters.List);
        Assert.False(parameters.RawQueryData.ContainsKey("list"));
        Assert.Null(parameters.MessageID);
        Assert.False(parameters.RawQueryData.ContainsKey("messageId"));
        Assert.Null(parameters.Notification);
        Assert.False(parameters.RawQueryData.ContainsKey("notification"));
        Assert.Null(parameters.Recipient);
        Assert.False(parameters.RawQueryData.ContainsKey("recipient"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawQueryData.ContainsKey("tags"));
        Assert.Null(parameters.TenantID);
        Assert.False(parameters.RawQueryData.ContainsKey("tenant_id"));
        Assert.Null(parameters.TraceID);
        Assert.False(parameters.RawQueryData.ContainsKey("traceId"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MessageListParams
        {
            Provider = ["string"],
            Status = ["string"],
            Tag = ["string"],

            Archived = null,
            Cursor = null,
            EnqueuedAfter = null,
            Event = null,
            List = null,
            MessageID = null,
            Notification = null,
            Recipient = null,
            Tags = null,
            TenantID = null,
            TraceID = null,
        };

        Assert.Null(parameters.Archived);
        Assert.True(parameters.RawQueryData.ContainsKey("archived"));
        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.EnqueuedAfter);
        Assert.True(parameters.RawQueryData.ContainsKey("enqueued_after"));
        Assert.Null(parameters.Event);
        Assert.True(parameters.RawQueryData.ContainsKey("event"));
        Assert.Null(parameters.List);
        Assert.True(parameters.RawQueryData.ContainsKey("list"));
        Assert.Null(parameters.MessageID);
        Assert.True(parameters.RawQueryData.ContainsKey("messageId"));
        Assert.Null(parameters.Notification);
        Assert.True(parameters.RawQueryData.ContainsKey("notification"));
        Assert.Null(parameters.Recipient);
        Assert.True(parameters.RawQueryData.ContainsKey("recipient"));
        Assert.Null(parameters.Tags);
        Assert.True(parameters.RawQueryData.ContainsKey("tags"));
        Assert.Null(parameters.TenantID);
        Assert.True(parameters.RawQueryData.ContainsKey("tenant_id"));
        Assert.Null(parameters.TraceID);
        Assert.True(parameters.RawQueryData.ContainsKey("traceId"));
    }

    [Fact]
    public void Url_Works()
    {
        MessageListParams parameters = new()
        {
            Archived = true,
            Cursor = "cursor",
            EnqueuedAfter = "enqueued_after",
            Event = "event",
            List = "list",
            MessageID = "messageId",
            Notification = "notification",
            Provider = ["string"],
            Recipient = "recipient",
            Status = ["string"],
            Tag = ["string"],
            Tags = "tags",
            TenantID = "tenant_id",
            TraceID = "traceId",
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.courier.com/messages?archived=true&cursor=cursor&enqueued_after=enqueued_after&event=event&list=list&messageId=messageId&notification=notification&provider=string&recipient=recipient&status=string&tag=string&tags=tags&tenant_id=tenant_id&traceId=traceId"
            ),
            url
        );
    }
}
