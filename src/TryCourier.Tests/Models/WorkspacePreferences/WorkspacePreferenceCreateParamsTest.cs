using System;
using System.Collections.Generic;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.WorkspacePreferences;

namespace TryCourier.Tests.Models.WorkspacePreferences;

public class WorkspacePreferenceCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkspacePreferenceCreateParams
        {
            Name = "Account Notifications",
            Description = "description",
            HasCustomRouting = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
        };

        string expectedName = "Account Notifications";
        string expectedDescription = "description";
        bool expectedHasCustomRouting = true;
        List<ApiEnum<string, ChannelClassification>> expectedRoutingOptions =
        [
            ChannelClassification.DirectMessage,
        ];

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedHasCustomRouting, parameters.HasCustomRouting);
        Assert.NotNull(parameters.RoutingOptions);
        Assert.Equal(expectedRoutingOptions.Count, parameters.RoutingOptions.Count);
        for (int i = 0; i < expectedRoutingOptions.Count; i++)
        {
            Assert.Equal(expectedRoutingOptions[i], parameters.RoutingOptions[i]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkspacePreferenceCreateParams { Name = "Account Notifications" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.HasCustomRouting);
        Assert.False(parameters.RawBodyData.ContainsKey("has_custom_routing"));
        Assert.Null(parameters.RoutingOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("routing_options"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WorkspacePreferenceCreateParams
        {
            Name = "Account Notifications",

            Description = null,
            HasCustomRouting = null,
            RoutingOptions = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.HasCustomRouting);
        Assert.True(parameters.RawBodyData.ContainsKey("has_custom_routing"));
        Assert.Null(parameters.RoutingOptions);
        Assert.True(parameters.RawBodyData.ContainsKey("routing_options"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkspacePreferenceCreateParams parameters = new() { Name = "Account Notifications" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/preferences/sections"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkspacePreferenceCreateParams
        {
            Name = "Account Notifications",
            Description = "description",
            HasCustomRouting = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
        };

        WorkspacePreferenceCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
