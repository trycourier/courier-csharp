using System.Collections.Generic;
using Courier.Models.Messages;

namespace Courier.Tests.Models.Messages;

public class MessageContentResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageContentResponse
        {
            Results =
            [
                new()
                {
                    Channel = "channel",
                    ChannelID = "channel_id",
                    Content = new()
                    {
                        Blocks = [new() { Text = "text", Type = "type" }],
                        Body = "body",
                        HTML = "html",
                        Subject = "subject",
                        Text = "text",
                        Title = "title",
                    },
                },
            ],
        };

        List<Result> expectedResults =
        [
            new()
            {
                Channel = "channel",
                ChannelID = "channel_id",
                Content = new()
                {
                    Blocks = [new() { Text = "text", Type = "type" }],
                    Body = "body",
                    HTML = "html",
                    Subject = "subject",
                    Text = "text",
                    Title = "title",
                },
            },
        ];

        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Result
        {
            Channel = "channel",
            ChannelID = "channel_id",
            Content = new()
            {
                Blocks = [new() { Text = "text", Type = "type" }],
                Body = "body",
                HTML = "html",
                Subject = "subject",
                Text = "text",
                Title = "title",
            },
        };

        string expectedChannel = "channel";
        string expectedChannelID = "channel_id";
        Content expectedContent = new()
        {
            Blocks = [new() { Text = "text", Type = "type" }],
            Body = "body",
            HTML = "html",
            Subject = "subject",
            Text = "text",
            Title = "title",
        };

        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedChannelID, model.ChannelID);
        Assert.Equal(expectedContent, model.Content);
    }
}

public class ContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Content
        {
            Blocks = [new() { Text = "text", Type = "type" }],
            Body = "body",
            HTML = "html",
            Subject = "subject",
            Text = "text",
            Title = "title",
        };

        List<Block> expectedBlocks = [new() { Text = "text", Type = "type" }];
        string expectedBody = "body";
        string expectedHTML = "html";
        string expectedSubject = "subject";
        string expectedText = "text";
        string expectedTitle = "title";

        Assert.Equal(expectedBlocks.Count, model.Blocks.Count);
        for (int i = 0; i < expectedBlocks.Count; i++)
        {
            Assert.Equal(expectedBlocks[i], model.Blocks[i]);
        }
        Assert.Equal(expectedBody, model.Body);
        Assert.Equal(expectedHTML, model.HTML);
        Assert.Equal(expectedSubject, model.Subject);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedTitle, model.Title);
    }
}

public class BlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Block { Text = "text", Type = "type" };

        string expectedText = "text";
        string expectedType = "type";

        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedType, model.Type);
    }
}
