using System;
using System.Collections.Generic;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.WorkspacePreferences;

namespace TryCourier.Tests.Models.WorkspacePreferences;

public class WorkspacePreferenceReplaceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkspacePreferenceReplaceParams
        {
            SectionID = "section_id",
            Name = "name",
            HasCustomRouting = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
        };

        string expectedSectionID = "section_id";
        string expectedName = "name";
        bool expectedHasCustomRouting = true;
        List<ApiEnum<string, ChannelClassification>> expectedRoutingOptions =
        [
            ChannelClassification.DirectMessage,
        ];

        Assert.Equal(expectedSectionID, parameters.SectionID);
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
        var parameters = new WorkspacePreferenceReplaceParams
        {
            SectionID = "section_id",
            Name = "name",
        };

        Assert.Null(parameters.HasCustomRouting);
        Assert.False(parameters.RawBodyData.ContainsKey("has_custom_routing"));
        Assert.Null(parameters.RoutingOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("routing_options"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WorkspacePreferenceReplaceParams
        {
            SectionID = "section_id",
            Name = "name",

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
        WorkspacePreferenceReplaceParams parameters = new()
        {
            SectionID = "section_id",
            Name = "name",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/preferences/sections/section_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkspacePreferenceReplaceParams
        {
            SectionID = "section_id",
            Name = "name",
            HasCustomRouting = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
        };

        WorkspacePreferenceReplaceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
