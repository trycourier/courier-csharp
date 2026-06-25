using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.WorkspacePreferences;

namespace TryCourier.Tests.Models.WorkspacePreferences;

public class WorkspacePreferenceCreateRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkspacePreferenceCreateRequest
        {
            Name = "name",
            HasCustomRouting = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
        };

        string expectedName = "name";
        bool expectedHasCustomRouting = true;
        List<ApiEnum<string, ChannelClassification>> expectedRoutingOptions =
        [
            ChannelClassification.DirectMessage,
        ];

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedHasCustomRouting, model.HasCustomRouting);
        Assert.NotNull(model.RoutingOptions);
        Assert.Equal(expectedRoutingOptions.Count, model.RoutingOptions.Count);
        for (int i = 0; i < expectedRoutingOptions.Count; i++)
        {
            Assert.Equal(expectedRoutingOptions[i], model.RoutingOptions[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkspacePreferenceCreateRequest
        {
            Name = "name",
            HasCustomRouting = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspacePreferenceCreateRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkspacePreferenceCreateRequest
        {
            Name = "name",
            HasCustomRouting = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspacePreferenceCreateRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        bool expectedHasCustomRouting = true;
        List<ApiEnum<string, ChannelClassification>> expectedRoutingOptions =
        [
            ChannelClassification.DirectMessage,
        ];

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedHasCustomRouting, deserialized.HasCustomRouting);
        Assert.NotNull(deserialized.RoutingOptions);
        Assert.Equal(expectedRoutingOptions.Count, deserialized.RoutingOptions.Count);
        for (int i = 0; i < expectedRoutingOptions.Count; i++)
        {
            Assert.Equal(expectedRoutingOptions[i], deserialized.RoutingOptions[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkspacePreferenceCreateRequest
        {
            Name = "name",
            HasCustomRouting = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WorkspacePreferenceCreateRequest { Name = "name" };

        Assert.Null(model.HasCustomRouting);
        Assert.False(model.RawData.ContainsKey("has_custom_routing"));
        Assert.Null(model.RoutingOptions);
        Assert.False(model.RawData.ContainsKey("routing_options"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WorkspacePreferenceCreateRequest { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WorkspacePreferenceCreateRequest
        {
            Name = "name",

            HasCustomRouting = null,
            RoutingOptions = null,
        };

        Assert.Null(model.HasCustomRouting);
        Assert.True(model.RawData.ContainsKey("has_custom_routing"));
        Assert.Null(model.RoutingOptions);
        Assert.True(model.RawData.ContainsKey("routing_options"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WorkspacePreferenceCreateRequest
        {
            Name = "name",

            HasCustomRouting = null,
            RoutingOptions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkspacePreferenceCreateRequest
        {
            Name = "name",
            HasCustomRouting = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
        };

        WorkspacePreferenceCreateRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
