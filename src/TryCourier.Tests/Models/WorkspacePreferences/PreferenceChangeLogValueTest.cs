using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.WorkspacePreferences;

namespace TryCourier.Tests.Models.WorkspacePreferences;

public class PreferenceChangeLogValueTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreferenceChangeLogValue
        {
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            Status = PreferenceStatus.OptedIn,
        };

        List<ApiEnum<string, ChannelClassification>> expectedCustomRouting =
        [
            ChannelClassification.DirectMessage,
        ];
        bool expectedHasCustomRouting = true;
        ApiEnum<string, PreferenceStatus> expectedStatus = PreferenceStatus.OptedIn;

        Assert.Equal(expectedCustomRouting.Count, model.CustomRouting.Count);
        for (int i = 0; i < expectedCustomRouting.Count; i++)
        {
            Assert.Equal(expectedCustomRouting[i], model.CustomRouting[i]);
        }
        Assert.Equal(expectedHasCustomRouting, model.HasCustomRouting);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PreferenceChangeLogValue
        {
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            Status = PreferenceStatus.OptedIn,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceChangeLogValue>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreferenceChangeLogValue
        {
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            Status = PreferenceStatus.OptedIn,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceChangeLogValue>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ApiEnum<string, ChannelClassification>> expectedCustomRouting =
        [
            ChannelClassification.DirectMessage,
        ];
        bool expectedHasCustomRouting = true;
        ApiEnum<string, PreferenceStatus> expectedStatus = PreferenceStatus.OptedIn;

        Assert.Equal(expectedCustomRouting.Count, deserialized.CustomRouting.Count);
        for (int i = 0; i < expectedCustomRouting.Count; i++)
        {
            Assert.Equal(expectedCustomRouting[i], deserialized.CustomRouting[i]);
        }
        Assert.Equal(expectedHasCustomRouting, deserialized.HasCustomRouting);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PreferenceChangeLogValue
        {
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            Status = PreferenceStatus.OptedIn,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PreferenceChangeLogValue
        {
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            Status = PreferenceStatus.OptedIn,
        };

        PreferenceChangeLogValue copied = new(model);

        Assert.Equal(model, copied);
    }
}
