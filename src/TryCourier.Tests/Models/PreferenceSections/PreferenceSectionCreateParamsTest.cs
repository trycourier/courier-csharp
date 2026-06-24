using System;
using System.Collections.Generic;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.PreferenceSections;

namespace TryCourier.Tests.Models.PreferenceSections;

public class PreferenceSectionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PreferenceSectionCreateParams
        {
            Name = "Account Notifications",
            HasCustomRouting = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
        };

        string expectedName = "Account Notifications";
        bool expectedHasCustomRouting = true;
        List<ApiEnum<string, ChannelClassification>> expectedRoutingOptions =
        [
            ChannelClassification.DirectMessage,
        ];

        Assert.Equal(expectedName, parameters.Name);
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
        var parameters = new PreferenceSectionCreateParams { Name = "Account Notifications" };

        Assert.Null(parameters.HasCustomRouting);
        Assert.False(parameters.RawBodyData.ContainsKey("has_custom_routing"));
        Assert.Null(parameters.RoutingOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("routing_options"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PreferenceSectionCreateParams
        {
            Name = "Account Notifications",

            HasCustomRouting = null,
            RoutingOptions = null,
        };

        Assert.Null(parameters.HasCustomRouting);
        Assert.True(parameters.RawBodyData.ContainsKey("has_custom_routing"));
        Assert.Null(parameters.RoutingOptions);
        Assert.True(parameters.RawBodyData.ContainsKey("routing_options"));
    }

    [Fact]
    public void Url_Works()
    {
        PreferenceSectionCreateParams parameters = new() { Name = "Account Notifications" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/preferences/sections"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PreferenceSectionCreateParams
        {
            Name = "Account Notifications",
            HasCustomRouting = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
        };

        PreferenceSectionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
