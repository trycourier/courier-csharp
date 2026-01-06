using System.Collections.Generic;
using System.Text.Json;
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
                        Html = "html",
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
                    Html = "html",
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

    [Fact]
    public void SerializationRoundtrip_Works()
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
                        Html = "html",
                        Subject = "subject",
                        Text = "text",
                        Title = "title",
                    },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MessageContentResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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
                        Html = "html",
                        Subject = "subject",
                        Text = "text",
                        Title = "title",
                    },
                },
            ],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MessageContentResponse>(element);
        Assert.NotNull(deserialized);

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
                    Html = "html",
                    Subject = "subject",
                    Text = "text",
                    Title = "title",
                },
            },
        ];

        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
    }

    [Fact]
    public void Validation_Works()
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
                        Html = "html",
                        Subject = "subject",
                        Text = "text",
                        Title = "title",
                    },
                },
            ],
        };

        model.Validate();
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
                Html = "html",
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
            Html = "html",
            Subject = "subject",
            Text = "text",
            Title = "title",
        };

        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedChannelID, model.ChannelID);
        Assert.Equal(expectedContent, model.Content);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Result
        {
            Channel = "channel",
            ChannelID = "channel_id",
            Content = new()
            {
                Blocks = [new() { Text = "text", Type = "type" }],
                Body = "body",
                Html = "html",
                Subject = "subject",
                Text = "text",
                Title = "title",
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Result>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Result
        {
            Channel = "channel",
            ChannelID = "channel_id",
            Content = new()
            {
                Blocks = [new() { Text = "text", Type = "type" }],
                Body = "body",
                Html = "html",
                Subject = "subject",
                Text = "text",
                Title = "title",
            },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Result>(element);
        Assert.NotNull(deserialized);

        string expectedChannel = "channel";
        string expectedChannelID = "channel_id";
        Content expectedContent = new()
        {
            Blocks = [new() { Text = "text", Type = "type" }],
            Body = "body",
            Html = "html",
            Subject = "subject",
            Text = "text",
            Title = "title",
        };

        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedChannelID, deserialized.ChannelID);
        Assert.Equal(expectedContent, deserialized.Content);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Result
        {
            Channel = "channel",
            ChannelID = "channel_id",
            Content = new()
            {
                Blocks = [new() { Text = "text", Type = "type" }],
                Body = "body",
                Html = "html",
                Subject = "subject",
                Text = "text",
                Title = "title",
            },
        };

        model.Validate();
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
            Html = "html",
            Subject = "subject",
            Text = "text",
            Title = "title",
        };

        List<Block> expectedBlocks = [new() { Text = "text", Type = "type" }];
        string expectedBody = "body";
        string expectedHtml = "html";
        string expectedSubject = "subject";
        string expectedText = "text";
        string expectedTitle = "title";

        Assert.Equal(expectedBlocks.Count, model.Blocks.Count);
        for (int i = 0; i < expectedBlocks.Count; i++)
        {
            Assert.Equal(expectedBlocks[i], model.Blocks[i]);
        }
        Assert.Equal(expectedBody, model.Body);
        Assert.Equal(expectedHtml, model.Html);
        Assert.Equal(expectedSubject, model.Subject);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedTitle, model.Title);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Content
        {
            Blocks = [new() { Text = "text", Type = "type" }],
            Body = "body",
            Html = "html",
            Subject = "subject",
            Text = "text",
            Title = "title",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Content>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Content
        {
            Blocks = [new() { Text = "text", Type = "type" }],
            Body = "body",
            Html = "html",
            Subject = "subject",
            Text = "text",
            Title = "title",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Content>(element);
        Assert.NotNull(deserialized);

        List<Block> expectedBlocks = [new() { Text = "text", Type = "type" }];
        string expectedBody = "body";
        string expectedHtml = "html";
        string expectedSubject = "subject";
        string expectedText = "text";
        string expectedTitle = "title";

        Assert.Equal(expectedBlocks.Count, deserialized.Blocks.Count);
        for (int i = 0; i < expectedBlocks.Count; i++)
        {
            Assert.Equal(expectedBlocks[i], deserialized.Blocks[i]);
        }
        Assert.Equal(expectedBody, deserialized.Body);
        Assert.Equal(expectedHtml, deserialized.Html);
        Assert.Equal(expectedSubject, deserialized.Subject);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedTitle, deserialized.Title);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Content
        {
            Blocks = [new() { Text = "text", Type = "type" }],
            Body = "body",
            Html = "html",
            Subject = "subject",
            Text = "text",
            Title = "title",
        };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Block { Text = "text", Type = "type" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Block>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Block { Text = "text", Type = "type" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Block>(element);
        Assert.NotNull(deserialized);

        string expectedText = "text";
        string expectedType = "type";

        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Block { Text = "text", Type = "type" };

        model.Validate();
    }
}
