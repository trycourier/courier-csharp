using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class NotificationPreferenceDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotificationPreferenceDetails
        {
            Status = PreferenceStatus.OptedIn,
            ChannelPreferences = [new(ChannelClassification.DirectMessage)],
            Rules = [new() { Until = "until", Start = "start" }],
        };

        ApiEnum<string, PreferenceStatus> expectedStatus = PreferenceStatus.OptedIn;
        List<ChannelPreference> expectedChannelPreferences =
        [
            new(ChannelClassification.DirectMessage),
        ];
        List<Rule> expectedRules = [new() { Until = "until", Start = "start" }];

        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.ChannelPreferences);
        Assert.Equal(expectedChannelPreferences.Count, model.ChannelPreferences.Count);
        for (int i = 0; i < expectedChannelPreferences.Count; i++)
        {
            Assert.Equal(expectedChannelPreferences[i], model.ChannelPreferences[i]);
        }
        Assert.NotNull(model.Rules);
        Assert.Equal(expectedRules.Count, model.Rules.Count);
        for (int i = 0; i < expectedRules.Count; i++)
        {
            Assert.Equal(expectedRules[i], model.Rules[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotificationPreferenceDetails
        {
            Status = PreferenceStatus.OptedIn,
            ChannelPreferences = [new(ChannelClassification.DirectMessage)],
            Rules = [new() { Until = "until", Start = "start" }],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationPreferenceDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotificationPreferenceDetails
        {
            Status = PreferenceStatus.OptedIn,
            ChannelPreferences = [new(ChannelClassification.DirectMessage)],
            Rules = [new() { Until = "until", Start = "start" }],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationPreferenceDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, PreferenceStatus> expectedStatus = PreferenceStatus.OptedIn;
        List<ChannelPreference> expectedChannelPreferences =
        [
            new(ChannelClassification.DirectMessage),
        ];
        List<Rule> expectedRules = [new() { Until = "until", Start = "start" }];

        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.ChannelPreferences);
        Assert.Equal(expectedChannelPreferences.Count, deserialized.ChannelPreferences.Count);
        for (int i = 0; i < expectedChannelPreferences.Count; i++)
        {
            Assert.Equal(expectedChannelPreferences[i], deserialized.ChannelPreferences[i]);
        }
        Assert.NotNull(deserialized.Rules);
        Assert.Equal(expectedRules.Count, deserialized.Rules.Count);
        for (int i = 0; i < expectedRules.Count; i++)
        {
            Assert.Equal(expectedRules[i], deserialized.Rules[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotificationPreferenceDetails
        {
            Status = PreferenceStatus.OptedIn,
            ChannelPreferences = [new(ChannelClassification.DirectMessage)],
            Rules = [new() { Until = "until", Start = "start" }],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NotificationPreferenceDetails { Status = PreferenceStatus.OptedIn };

        Assert.Null(model.ChannelPreferences);
        Assert.False(model.RawData.ContainsKey("channel_preferences"));
        Assert.Null(model.Rules);
        Assert.False(model.RawData.ContainsKey("rules"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new NotificationPreferenceDetails { Status = PreferenceStatus.OptedIn };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NotificationPreferenceDetails
        {
            Status = PreferenceStatus.OptedIn,

            ChannelPreferences = null,
            Rules = null,
        };

        Assert.Null(model.ChannelPreferences);
        Assert.True(model.RawData.ContainsKey("channel_preferences"));
        Assert.Null(model.Rules);
        Assert.True(model.RawData.ContainsKey("rules"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NotificationPreferenceDetails
        {
            Status = PreferenceStatus.OptedIn,

            ChannelPreferences = null,
            Rules = null,
        };

        model.Validate();
    }
}
