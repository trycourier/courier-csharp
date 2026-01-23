using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Preference>(
            json,
            ModelBase.SerializerOptions
        );

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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Preference>(
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
        ApiEnum<string, Source> expectedSource = Source.Subscription;

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

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Preference
        {
            Status = PreferenceStatus.OptedIn,
            ChannelPreferences = [new(ChannelClassification.DirectMessage)],
            Rules = [new() { Until = "until", Start = "start" }],
            Source = Source.Subscription,
        };

        Preference copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SourceTest : TestBase
{
    [Theory]
    [InlineData(Source.Subscription)]
    [InlineData(Source.List)]
    [InlineData(Source.Recipient)]
    public void Validation_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Source.Subscription)]
    [InlineData(Source.List)]
    [InlineData(Source.Recipient)]
    public void SerializationRoundtrip_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
