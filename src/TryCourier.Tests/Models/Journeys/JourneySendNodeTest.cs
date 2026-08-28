using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneySendNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneySendNode
        {
            Message = new()
            {
                Context = new("x"),
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Delay = new() { Until = "x", Timezone = "x" },
                Template = "x",
                To = new()
                {
                    EmailOverride = "x",
                    MsTeams = new()
                    {
                        ChannelID = "x",
                        ChannelName = "x",
                        Email = "x",
                        ServiceUrl = "x",
                        TeamID = "x",
                        TenantID = "x",
                        UserID = "x",
                    },
                    PhoneNumberOverride = "x",
                    Slack = new JourneySendNodeToSlackChannel()
                    {
                        Channel = "x",
                        AccessToken = "x",
                    },
                    UserIDOverride = "x",
                },
            },
            Type = JourneySendNodeType.Send,
            ID = "x",
            Channel = Channel.Email,
            Conditions = new(["string", "string"]),
            Experiment = new()
            {
                BucketingKey = "x",
                Variants =
                [
                    new()
                    {
                        ID = "x",
                        TemplateID = "x",
                        Weight = 0,
                        Name = "name",
                    },
                    new()
                    {
                        ID = "x",
                        TemplateID = "x",
                        Weight = 0,
                        Name = "name",
                    },
                ],
                ID = "x",
                Name = "name",
            },
        };

        Message expectedMessage = new()
        {
            Context = new("x"),
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Delay = new() { Until = "x", Timezone = "x" },
            Template = "x",
            To = new()
            {
                EmailOverride = "x",
                MsTeams = new()
                {
                    ChannelID = "x",
                    ChannelName = "x",
                    Email = "x",
                    ServiceUrl = "x",
                    TeamID = "x",
                    TenantID = "x",
                    UserID = "x",
                },
                PhoneNumberOverride = "x",
                Slack = new JourneySendNodeToSlackChannel() { Channel = "x", AccessToken = "x" },
                UserIDOverride = "x",
            },
        };
        ApiEnum<string, JourneySendNodeType> expectedType = JourneySendNodeType.Send;
        string expectedID = "x";
        ApiEnum<string, Channel> expectedChannel = Channel.Email;
        JourneyConditionsField expectedConditions = new(["string", "string"]);
        JourneyExperiment expectedExperiment = new()
        {
            BucketingKey = "x",
            Variants =
            [
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
            ],
            ID = "x",
            Name = "name",
        };

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedConditions, model.Conditions);
        Assert.Equal(expectedExperiment, model.Experiment);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneySendNode
        {
            Message = new()
            {
                Context = new("x"),
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Delay = new() { Until = "x", Timezone = "x" },
                Template = "x",
                To = new()
                {
                    EmailOverride = "x",
                    MsTeams = new()
                    {
                        ChannelID = "x",
                        ChannelName = "x",
                        Email = "x",
                        ServiceUrl = "x",
                        TeamID = "x",
                        TenantID = "x",
                        UserID = "x",
                    },
                    PhoneNumberOverride = "x",
                    Slack = new JourneySendNodeToSlackChannel()
                    {
                        Channel = "x",
                        AccessToken = "x",
                    },
                    UserIDOverride = "x",
                },
            },
            Type = JourneySendNodeType.Send,
            ID = "x",
            Channel = Channel.Email,
            Conditions = new(["string", "string"]),
            Experiment = new()
            {
                BucketingKey = "x",
                Variants =
                [
                    new()
                    {
                        ID = "x",
                        TemplateID = "x",
                        Weight = 0,
                        Name = "name",
                    },
                    new()
                    {
                        ID = "x",
                        TemplateID = "x",
                        Weight = 0,
                        Name = "name",
                    },
                ],
                ID = "x",
                Name = "name",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneySendNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneySendNode
        {
            Message = new()
            {
                Context = new("x"),
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Delay = new() { Until = "x", Timezone = "x" },
                Template = "x",
                To = new()
                {
                    EmailOverride = "x",
                    MsTeams = new()
                    {
                        ChannelID = "x",
                        ChannelName = "x",
                        Email = "x",
                        ServiceUrl = "x",
                        TeamID = "x",
                        TenantID = "x",
                        UserID = "x",
                    },
                    PhoneNumberOverride = "x",
                    Slack = new JourneySendNodeToSlackChannel()
                    {
                        Channel = "x",
                        AccessToken = "x",
                    },
                    UserIDOverride = "x",
                },
            },
            Type = JourneySendNodeType.Send,
            ID = "x",
            Channel = Channel.Email,
            Conditions = new(["string", "string"]),
            Experiment = new()
            {
                BucketingKey = "x",
                Variants =
                [
                    new()
                    {
                        ID = "x",
                        TemplateID = "x",
                        Weight = 0,
                        Name = "name",
                    },
                    new()
                    {
                        ID = "x",
                        TemplateID = "x",
                        Weight = 0,
                        Name = "name",
                    },
                ],
                ID = "x",
                Name = "name",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneySendNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Message expectedMessage = new()
        {
            Context = new("x"),
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Delay = new() { Until = "x", Timezone = "x" },
            Template = "x",
            To = new()
            {
                EmailOverride = "x",
                MsTeams = new()
                {
                    ChannelID = "x",
                    ChannelName = "x",
                    Email = "x",
                    ServiceUrl = "x",
                    TeamID = "x",
                    TenantID = "x",
                    UserID = "x",
                },
                PhoneNumberOverride = "x",
                Slack = new JourneySendNodeToSlackChannel() { Channel = "x", AccessToken = "x" },
                UserIDOverride = "x",
            },
        };
        ApiEnum<string, JourneySendNodeType> expectedType = JourneySendNodeType.Send;
        string expectedID = "x";
        ApiEnum<string, Channel> expectedChannel = Channel.Email;
        JourneyConditionsField expectedConditions = new(["string", "string"]);
        JourneyExperiment expectedExperiment = new()
        {
            BucketingKey = "x",
            Variants =
            [
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
            ],
            ID = "x",
            Name = "name",
        };

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedConditions, deserialized.Conditions);
        Assert.Equal(expectedExperiment, deserialized.Experiment);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneySendNode
        {
            Message = new()
            {
                Context = new("x"),
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Delay = new() { Until = "x", Timezone = "x" },
                Template = "x",
                To = new()
                {
                    EmailOverride = "x",
                    MsTeams = new()
                    {
                        ChannelID = "x",
                        ChannelName = "x",
                        Email = "x",
                        ServiceUrl = "x",
                        TeamID = "x",
                        TenantID = "x",
                        UserID = "x",
                    },
                    PhoneNumberOverride = "x",
                    Slack = new JourneySendNodeToSlackChannel()
                    {
                        Channel = "x",
                        AccessToken = "x",
                    },
                    UserIDOverride = "x",
                },
            },
            Type = JourneySendNodeType.Send,
            ID = "x",
            Channel = Channel.Email,
            Conditions = new(["string", "string"]),
            Experiment = new()
            {
                BucketingKey = "x",
                Variants =
                [
                    new()
                    {
                        ID = "x",
                        TemplateID = "x",
                        Weight = 0,
                        Name = "name",
                    },
                    new()
                    {
                        ID = "x",
                        TemplateID = "x",
                        Weight = 0,
                        Name = "name",
                    },
                ],
                ID = "x",
                Name = "name",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneySendNode
        {
            Message = new()
            {
                Context = new("x"),
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Delay = new() { Until = "x", Timezone = "x" },
                Template = "x",
                To = new()
                {
                    EmailOverride = "x",
                    MsTeams = new()
                    {
                        ChannelID = "x",
                        ChannelName = "x",
                        Email = "x",
                        ServiceUrl = "x",
                        TeamID = "x",
                        TenantID = "x",
                        UserID = "x",
                    },
                    PhoneNumberOverride = "x",
                    Slack = new JourneySendNodeToSlackChannel()
                    {
                        Channel = "x",
                        AccessToken = "x",
                    },
                    UserIDOverride = "x",
                },
            },
            Type = JourneySendNodeType.Send,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Conditions);
        Assert.False(model.RawData.ContainsKey("conditions"));
        Assert.Null(model.Experiment);
        Assert.False(model.RawData.ContainsKey("experiment"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneySendNode
        {
            Message = new()
            {
                Context = new("x"),
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Delay = new() { Until = "x", Timezone = "x" },
                Template = "x",
                To = new()
                {
                    EmailOverride = "x",
                    MsTeams = new()
                    {
                        ChannelID = "x",
                        ChannelName = "x",
                        Email = "x",
                        ServiceUrl = "x",
                        TeamID = "x",
                        TenantID = "x",
                        UserID = "x",
                    },
                    PhoneNumberOverride = "x",
                    Slack = new JourneySendNodeToSlackChannel()
                    {
                        Channel = "x",
                        AccessToken = "x",
                    },
                    UserIDOverride = "x",
                },
            },
            Type = JourneySendNodeType.Send,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneySendNode
        {
            Message = new()
            {
                Context = new("x"),
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Delay = new() { Until = "x", Timezone = "x" },
                Template = "x",
                To = new()
                {
                    EmailOverride = "x",
                    MsTeams = new()
                    {
                        ChannelID = "x",
                        ChannelName = "x",
                        Email = "x",
                        ServiceUrl = "x",
                        TeamID = "x",
                        TenantID = "x",
                        UserID = "x",
                    },
                    PhoneNumberOverride = "x",
                    Slack = new JourneySendNodeToSlackChannel()
                    {
                        Channel = "x",
                        AccessToken = "x",
                    },
                    UserIDOverride = "x",
                },
            },
            Type = JourneySendNodeType.Send,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Channel = null,
            Conditions = null,
            Experiment = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Conditions);
        Assert.False(model.RawData.ContainsKey("conditions"));
        Assert.Null(model.Experiment);
        Assert.False(model.RawData.ContainsKey("experiment"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneySendNode
        {
            Message = new()
            {
                Context = new("x"),
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Delay = new() { Until = "x", Timezone = "x" },
                Template = "x",
                To = new()
                {
                    EmailOverride = "x",
                    MsTeams = new()
                    {
                        ChannelID = "x",
                        ChannelName = "x",
                        Email = "x",
                        ServiceUrl = "x",
                        TeamID = "x",
                        TenantID = "x",
                        UserID = "x",
                    },
                    PhoneNumberOverride = "x",
                    Slack = new JourneySendNodeToSlackChannel()
                    {
                        Channel = "x",
                        AccessToken = "x",
                    },
                    UserIDOverride = "x",
                },
            },
            Type = JourneySendNodeType.Send,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Channel = null,
            Conditions = null,
            Experiment = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneySendNode
        {
            Message = new()
            {
                Context = new("x"),
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Delay = new() { Until = "x", Timezone = "x" },
                Template = "x",
                To = new()
                {
                    EmailOverride = "x",
                    MsTeams = new()
                    {
                        ChannelID = "x",
                        ChannelName = "x",
                        Email = "x",
                        ServiceUrl = "x",
                        TeamID = "x",
                        TenantID = "x",
                        UserID = "x",
                    },
                    PhoneNumberOverride = "x",
                    Slack = new JourneySendNodeToSlackChannel()
                    {
                        Channel = "x",
                        AccessToken = "x",
                    },
                    UserIDOverride = "x",
                },
            },
            Type = JourneySendNodeType.Send,
            ID = "x",
            Channel = Channel.Email,
            Conditions = new(["string", "string"]),
            Experiment = new()
            {
                BucketingKey = "x",
                Variants =
                [
                    new()
                    {
                        ID = "x",
                        TemplateID = "x",
                        Weight = 0,
                        Name = "name",
                    },
                    new()
                    {
                        ID = "x",
                        TemplateID = "x",
                        Weight = 0,
                        Name = "name",
                    },
                ],
                ID = "x",
                Name = "name",
            },
        };

        JourneySendNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MessageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Message
        {
            Context = new("x"),
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Delay = new() { Until = "x", Timezone = "x" },
            Template = "x",
            To = new()
            {
                EmailOverride = "x",
                MsTeams = new()
                {
                    ChannelID = "x",
                    ChannelName = "x",
                    Email = "x",
                    ServiceUrl = "x",
                    TeamID = "x",
                    TenantID = "x",
                    UserID = "x",
                },
                PhoneNumberOverride = "x",
                Slack = new JourneySendNodeToSlackChannel() { Channel = "x", AccessToken = "x" },
                UserIDOverride = "x",
            },
        };

        Context expectedContext = new("x");
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Delay expectedDelay = new() { Until = "x", Timezone = "x" };
        string expectedTemplate = "x";
        To expectedTo = new()
        {
            EmailOverride = "x",
            MsTeams = new()
            {
                ChannelID = "x",
                ChannelName = "x",
                Email = "x",
                ServiceUrl = "x",
                TeamID = "x",
                TenantID = "x",
                UserID = "x",
            },
            PhoneNumberOverride = "x",
            Slack = new JourneySendNodeToSlackChannel() { Channel = "x", AccessToken = "x" },
            UserIDOverride = "x",
        };

        Assert.Equal(expectedContext, model.Context);
        Assert.NotNull(model.Data);
        Assert.Equal(expectedData.Count, model.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(model.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Data[item.Key]));
        }
        Assert.Equal(expectedDelay, model.Delay);
        Assert.Equal(expectedTemplate, model.Template);
        Assert.Equal(expectedTo, model.To);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Message
        {
            Context = new("x"),
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Delay = new() { Until = "x", Timezone = "x" },
            Template = "x",
            To = new()
            {
                EmailOverride = "x",
                MsTeams = new()
                {
                    ChannelID = "x",
                    ChannelName = "x",
                    Email = "x",
                    ServiceUrl = "x",
                    TeamID = "x",
                    TenantID = "x",
                    UserID = "x",
                },
                PhoneNumberOverride = "x",
                Slack = new JourneySendNodeToSlackChannel() { Channel = "x", AccessToken = "x" },
                UserIDOverride = "x",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Message>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Message
        {
            Context = new("x"),
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Delay = new() { Until = "x", Timezone = "x" },
            Template = "x",
            To = new()
            {
                EmailOverride = "x",
                MsTeams = new()
                {
                    ChannelID = "x",
                    ChannelName = "x",
                    Email = "x",
                    ServiceUrl = "x",
                    TeamID = "x",
                    TenantID = "x",
                    UserID = "x",
                },
                PhoneNumberOverride = "x",
                Slack = new JourneySendNodeToSlackChannel() { Channel = "x", AccessToken = "x" },
                UserIDOverride = "x",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Message>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Context expectedContext = new("x");
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Delay expectedDelay = new() { Until = "x", Timezone = "x" };
        string expectedTemplate = "x";
        To expectedTo = new()
        {
            EmailOverride = "x",
            MsTeams = new()
            {
                ChannelID = "x",
                ChannelName = "x",
                Email = "x",
                ServiceUrl = "x",
                TeamID = "x",
                TenantID = "x",
                UserID = "x",
            },
            PhoneNumberOverride = "x",
            Slack = new JourneySendNodeToSlackChannel() { Channel = "x", AccessToken = "x" },
            UserIDOverride = "x",
        };

        Assert.Equal(expectedContext, deserialized.Context);
        Assert.NotNull(deserialized.Data);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(deserialized.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Data[item.Key]));
        }
        Assert.Equal(expectedDelay, deserialized.Delay);
        Assert.Equal(expectedTemplate, deserialized.Template);
        Assert.Equal(expectedTo, deserialized.To);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Message
        {
            Context = new("x"),
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Delay = new() { Until = "x", Timezone = "x" },
            Template = "x",
            To = new()
            {
                EmailOverride = "x",
                MsTeams = new()
                {
                    ChannelID = "x",
                    ChannelName = "x",
                    Email = "x",
                    ServiceUrl = "x",
                    TeamID = "x",
                    TenantID = "x",
                    UserID = "x",
                },
                PhoneNumberOverride = "x",
                Slack = new JourneySendNodeToSlackChannel() { Channel = "x", AccessToken = "x" },
                UserIDOverride = "x",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Message { };

        Assert.Null(model.Context);
        Assert.False(model.RawData.ContainsKey("context"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Delay);
        Assert.False(model.RawData.ContainsKey("delay"));
        Assert.Null(model.Template);
        Assert.False(model.RawData.ContainsKey("template"));
        Assert.Null(model.To);
        Assert.False(model.RawData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Message { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Message
        {
            // Null should be interpreted as omitted for these properties
            Context = null,
            Data = null,
            Delay = null,
            Template = null,
            To = null,
        };

        Assert.Null(model.Context);
        Assert.False(model.RawData.ContainsKey("context"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Delay);
        Assert.False(model.RawData.ContainsKey("delay"));
        Assert.Null(model.Template);
        Assert.False(model.RawData.ContainsKey("template"));
        Assert.Null(model.To);
        Assert.False(model.RawData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Message
        {
            // Null should be interpreted as omitted for these properties
            Context = null,
            Data = null,
            Delay = null,
            Template = null,
            To = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Message
        {
            Context = new("x"),
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Delay = new() { Until = "x", Timezone = "x" },
            Template = "x",
            To = new()
            {
                EmailOverride = "x",
                MsTeams = new()
                {
                    ChannelID = "x",
                    ChannelName = "x",
                    Email = "x",
                    ServiceUrl = "x",
                    TeamID = "x",
                    TenantID = "x",
                    UserID = "x",
                },
                PhoneNumberOverride = "x",
                Slack = new JourneySendNodeToSlackChannel() { Channel = "x", AccessToken = "x" },
                UserIDOverride = "x",
            },
        };

        Message copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContextTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Context { TenantID = "x" };

        string expectedTenantID = "x";

        Assert.Equal(expectedTenantID, model.TenantID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Context { TenantID = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Context>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Context { TenantID = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Context>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTenantID = "x";

        Assert.Equal(expectedTenantID, deserialized.TenantID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Context { TenantID = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Context { TenantID = "x" };

        Context copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DelayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Delay { Until = "x", Timezone = "x" };

        string expectedUntil = "x";
        string expectedTimezone = "x";

        Assert.Equal(expectedUntil, model.Until);
        Assert.Equal(expectedTimezone, model.Timezone);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Delay { Until = "x", Timezone = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delay>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Delay { Until = "x", Timezone = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delay>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedUntil = "x";
        string expectedTimezone = "x";

        Assert.Equal(expectedUntil, deserialized.Until);
        Assert.Equal(expectedTimezone, deserialized.Timezone);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Delay { Until = "x", Timezone = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Delay { Until = "x" };

        Assert.Null(model.Timezone);
        Assert.False(model.RawData.ContainsKey("timezone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Delay { Until = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Delay
        {
            Until = "x",

            // Null should be interpreted as omitted for these properties
            Timezone = null,
        };

        Assert.Null(model.Timezone);
        Assert.False(model.RawData.ContainsKey("timezone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Delay
        {
            Until = "x",

            // Null should be interpreted as omitted for these properties
            Timezone = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Delay { Until = "x", Timezone = "x" };

        Delay copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ToTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new To
        {
            EmailOverride = "x",
            MsTeams = new()
            {
                ChannelID = "x",
                ChannelName = "x",
                Email = "x",
                ServiceUrl = "x",
                TeamID = "x",
                TenantID = "x",
                UserID = "x",
            },
            PhoneNumberOverride = "x",
            Slack = new JourneySendNodeToSlackChannel() { Channel = "x", AccessToken = "x" },
            UserIDOverride = "x",
        };

        string expectedEmailOverride = "x";
        JourneySendNodeToMsTeams expectedMsTeams = new()
        {
            ChannelID = "x",
            ChannelName = "x",
            Email = "x",
            ServiceUrl = "x",
            TeamID = "x",
            TenantID = "x",
            UserID = "x",
        };
        string expectedPhoneNumberOverride = "x";
        JourneySendNodeToSlack expectedSlack = new JourneySendNodeToSlackChannel()
        {
            Channel = "x",
            AccessToken = "x",
        };
        string expectedUserIDOverride = "x";

        Assert.Equal(expectedEmailOverride, model.EmailOverride);
        Assert.Equal(expectedMsTeams, model.MsTeams);
        Assert.Equal(expectedPhoneNumberOverride, model.PhoneNumberOverride);
        Assert.Equal(expectedSlack, model.Slack);
        Assert.Equal(expectedUserIDOverride, model.UserIDOverride);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new To
        {
            EmailOverride = "x",
            MsTeams = new()
            {
                ChannelID = "x",
                ChannelName = "x",
                Email = "x",
                ServiceUrl = "x",
                TeamID = "x",
                TenantID = "x",
                UserID = "x",
            },
            PhoneNumberOverride = "x",
            Slack = new JourneySendNodeToSlackChannel() { Channel = "x", AccessToken = "x" },
            UserIDOverride = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<To>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new To
        {
            EmailOverride = "x",
            MsTeams = new()
            {
                ChannelID = "x",
                ChannelName = "x",
                Email = "x",
                ServiceUrl = "x",
                TeamID = "x",
                TenantID = "x",
                UserID = "x",
            },
            PhoneNumberOverride = "x",
            Slack = new JourneySendNodeToSlackChannel() { Channel = "x", AccessToken = "x" },
            UserIDOverride = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<To>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedEmailOverride = "x";
        JourneySendNodeToMsTeams expectedMsTeams = new()
        {
            ChannelID = "x",
            ChannelName = "x",
            Email = "x",
            ServiceUrl = "x",
            TeamID = "x",
            TenantID = "x",
            UserID = "x",
        };
        string expectedPhoneNumberOverride = "x";
        JourneySendNodeToSlack expectedSlack = new JourneySendNodeToSlackChannel()
        {
            Channel = "x",
            AccessToken = "x",
        };
        string expectedUserIDOverride = "x";

        Assert.Equal(expectedEmailOverride, deserialized.EmailOverride);
        Assert.Equal(expectedMsTeams, deserialized.MsTeams);
        Assert.Equal(expectedPhoneNumberOverride, deserialized.PhoneNumberOverride);
        Assert.Equal(expectedSlack, deserialized.Slack);
        Assert.Equal(expectedUserIDOverride, deserialized.UserIDOverride);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new To
        {
            EmailOverride = "x",
            MsTeams = new()
            {
                ChannelID = "x",
                ChannelName = "x",
                Email = "x",
                ServiceUrl = "x",
                TeamID = "x",
                TenantID = "x",
                UserID = "x",
            },
            PhoneNumberOverride = "x",
            Slack = new JourneySendNodeToSlackChannel() { Channel = "x", AccessToken = "x" },
            UserIDOverride = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new To { };

        Assert.Null(model.EmailOverride);
        Assert.False(model.RawData.ContainsKey("email_override"));
        Assert.Null(model.MsTeams);
        Assert.False(model.RawData.ContainsKey("ms_teams"));
        Assert.Null(model.PhoneNumberOverride);
        Assert.False(model.RawData.ContainsKey("phone_number_override"));
        Assert.Null(model.Slack);
        Assert.False(model.RawData.ContainsKey("slack"));
        Assert.Null(model.UserIDOverride);
        Assert.False(model.RawData.ContainsKey("user_id_override"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new To { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new To
        {
            // Null should be interpreted as omitted for these properties
            EmailOverride = null,
            MsTeams = null,
            PhoneNumberOverride = null,
            Slack = null,
            UserIDOverride = null,
        };

        Assert.Null(model.EmailOverride);
        Assert.False(model.RawData.ContainsKey("email_override"));
        Assert.Null(model.MsTeams);
        Assert.False(model.RawData.ContainsKey("ms_teams"));
        Assert.Null(model.PhoneNumberOverride);
        Assert.False(model.RawData.ContainsKey("phone_number_override"));
        Assert.Null(model.Slack);
        Assert.False(model.RawData.ContainsKey("slack"));
        Assert.Null(model.UserIDOverride);
        Assert.False(model.RawData.ContainsKey("user_id_override"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new To
        {
            // Null should be interpreted as omitted for these properties
            EmailOverride = null,
            MsTeams = null,
            PhoneNumberOverride = null,
            Slack = null,
            UserIDOverride = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new To
        {
            EmailOverride = "x",
            MsTeams = new()
            {
                ChannelID = "x",
                ChannelName = "x",
                Email = "x",
                ServiceUrl = "x",
                TeamID = "x",
                TenantID = "x",
                UserID = "x",
            },
            PhoneNumberOverride = "x",
            Slack = new JourneySendNodeToSlackChannel() { Channel = "x", AccessToken = "x" },
            UserIDOverride = "x",
        };

        To copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JourneySendNodeTypeTest : TestBase
{
    [Theory]
    [InlineData(JourneySendNodeType.Send)]
    public void Validation_Works(JourneySendNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneySendNodeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneySendNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneySendNodeType.Send)]
    public void SerializationRoundtrip_Works(JourneySendNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneySendNodeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JourneySendNodeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneySendNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JourneySendNodeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ChannelTest : TestBase
{
    [Theory]
    [InlineData(Channel.Email)]
    [InlineData(Channel.Sms)]
    [InlineData(Channel.Push)]
    [InlineData(Channel.Inbox)]
    [InlineData(Channel.Slack)]
    [InlineData(Channel.Msteams)]
    public void Validation_Works(Channel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Channel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Channel.Email)]
    [InlineData(Channel.Sms)]
    [InlineData(Channel.Push)]
    [InlineData(Channel.Inbox)]
    [InlineData(Channel.Slack)]
    [InlineData(Channel.Msteams)]
    public void SerializationRoundtrip_Works(Channel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Channel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
