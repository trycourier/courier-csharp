using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class PreferenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Preference
        {
            Status = PreferenceStatus.OptedIn,
            ChannelPreferences = [new(ChannelClassification.DirectMessage)],
            Rules = [new() { Until = "until", Start = "start" }],
            Source = Source.Subscription,
        };

        ApiEnum<string, PreferenceStatus> expectedStatus = PreferenceStatus.OptedIn;
        List<ChannelPreference> expectedChannelPreferences =
        [
            new(ChannelClassification.DirectMessage),
        ];
        List<Rule> expectedRules = [new() { Until = "until", Start = "start" }];
        ApiEnum<string, Source> expectedSource = Source.Subscription;

        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedChannelPreferences.Count, model.ChannelPreferences.Count);
        for (int i = 0; i < expectedChannelPreferences.Count; i++)
        {
            Assert.Equal(expectedChannelPreferences[i], model.ChannelPreferences[i]);
        }
        Assert.Equal(expectedRules.Count, model.Rules.Count);
        for (int i = 0; i < expectedRules.Count; i++)
        {
            Assert.Equal(expectedRules[i], model.Rules[i]);
        }
        Assert.Equal(expectedSource, model.Source);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Preference
        {
            Status = PreferenceStatus.OptedIn,
            ChannelPreferences = [new(ChannelClassification.DirectMessage)],
            Rules = [new() { Until = "until", Start = "start" }],
            Source = Source.Subscription,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Preference>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Preference
        {
            Status = PreferenceStatus.OptedIn,
            ChannelPreferences = [new(ChannelClassification.DirectMessage)],
            Rules = [new() { Until = "until", Start = "start" }],
            Source = Source.Subscription,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Preference>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, PreferenceStatus> expectedStatus = PreferenceStatus.OptedIn;
        List<ChannelPreference> expectedChannelPreferences =
        [
            new(ChannelClassification.DirectMessage),
        ];
        List<Rule> expectedRules = [new() { Until = "until", Start = "start" }];
        ApiEnum<string, Source> expectedSource = Source.Subscription;

        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedChannelPreferences.Count, deserialized.ChannelPreferences.Count);
        for (int i = 0; i < expectedChannelPreferences.Count; i++)
        {
            Assert.Equal(expectedChannelPreferences[i], deserialized.ChannelPreferences[i]);
        }
        Assert.Equal(expectedRules.Count, deserialized.Rules.Count);
        for (int i = 0; i < expectedRules.Count; i++)
        {
            Assert.Equal(expectedRules[i], deserialized.Rules[i]);
        }
        Assert.Equal(expectedSource, deserialized.Source);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Preference
        {
            Status = PreferenceStatus.OptedIn,
            ChannelPreferences = [new(ChannelClassification.DirectMessage)],
            Rules = [new() { Until = "until", Start = "start" }],
            Source = Source.Subscription,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Preference { Status = PreferenceStatus.OptedIn };

        Assert.Null(model.ChannelPreferences);
        Assert.False(model.RawData.ContainsKey("channel_preferences"));
        Assert.Null(model.Rules);
        Assert.False(model.RawData.ContainsKey("rules"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Preference { Status = PreferenceStatus.OptedIn };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Preference
        {
            Status = PreferenceStatus.OptedIn,

            ChannelPreferences = null,
            Rules = null,
            Source = null,
        };

        Assert.Null(model.ChannelPreferences);
        Assert.True(model.RawData.ContainsKey("channel_preferences"));
        Assert.Null(model.Rules);
        Assert.True(model.RawData.ContainsKey("rules"));
        Assert.Null(model.Source);
        Assert.True(model.RawData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Preference
        {
            Status = PreferenceStatus.OptedIn,

            ChannelPreferences = null,
            Rules = null,
            Source = null,
        };

        model.Validate();
    }
}
