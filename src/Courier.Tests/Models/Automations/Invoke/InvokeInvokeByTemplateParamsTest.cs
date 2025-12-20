using System.Collections.Generic;
using System.Text.Json;
using Courier.Models.Automations.Invoke;

namespace Courier.Tests.Models.Automations.Invoke;

public class InvokeInvokeByTemplateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvokeInvokeByTemplateParams
        {
            TemplateID = "templateId",
            Recipient = "recipient",
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Template = "template",
        };

        string expectedTemplateID = "templateId";
        string expectedRecipient = "recipient";
        string expectedBrand = "brand";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Dictionary<string, JsonElement> expectedProfile = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedTemplate = "template";

        Assert.Equal(expectedTemplateID, parameters.TemplateID);
        Assert.Equal(expectedRecipient, parameters.Recipient);
        Assert.Equal(expectedBrand, parameters.Brand);
        Assert.NotNull(parameters.Data);
        Assert.Equal(expectedData.Count, parameters.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(parameters.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Data[item.Key]));
        }
        Assert.NotNull(parameters.Profile);
        Assert.Equal(expectedProfile.Count, parameters.Profile.Count);
        foreach (var item in expectedProfile)
        {
            Assert.True(parameters.Profile.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Profile[item.Key]));
        }
        Assert.Equal(expectedTemplate, parameters.Template);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvokeInvokeByTemplateParams
        {
            TemplateID = "templateId",
            Recipient = "recipient",
        };

        Assert.Null(parameters.Brand);
        Assert.False(parameters.RawBodyData.ContainsKey("brand"));
        Assert.Null(parameters.Data);
        Assert.False(parameters.RawBodyData.ContainsKey("data"));
        Assert.Null(parameters.Profile);
        Assert.False(parameters.RawBodyData.ContainsKey("profile"));
        Assert.Null(parameters.Template);
        Assert.False(parameters.RawBodyData.ContainsKey("template"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new InvokeInvokeByTemplateParams
        {
            TemplateID = "templateId",
            Recipient = "recipient",

            Brand = null,
            Data = null,
            Profile = null,
            Template = null,
        };

        Assert.Null(parameters.Brand);
        Assert.False(parameters.RawBodyData.ContainsKey("brand"));
        Assert.Null(parameters.Data);
        Assert.False(parameters.RawBodyData.ContainsKey("data"));
        Assert.Null(parameters.Profile);
        Assert.False(parameters.RawBodyData.ContainsKey("profile"));
        Assert.Null(parameters.Template);
        Assert.False(parameters.RawBodyData.ContainsKey("template"));
    }
}
