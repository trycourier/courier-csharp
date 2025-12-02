using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models.Automations.Invoke;

namespace Courier.Tests.Models.Automations.Invoke;

public class AutomationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Automation
        {
            Steps =
            [
                new AutomationDelayStep()
                {
                    Action = Action.Delay,
                    Duration = "duration",
                    Until = "until",
                },
            ],
            CancelationToken = "cancelation_token",
        };

        List<Step> expectedSteps =
        [
            new AutomationDelayStep()
            {
                Action = Action.Delay,
                Duration = "duration",
                Until = "until",
            },
        ];
        string expectedCancelationToken = "cancelation_token";

        Assert.Equal(expectedSteps.Count, model.Steps.Count);
        for (int i = 0; i < expectedSteps.Count; i++)
        {
            Assert.Equal(expectedSteps[i], model.Steps[i]);
        }
        Assert.Equal(expectedCancelationToken, model.CancelationToken);
    }
}

public class AutomationDelayStepTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutomationDelayStep
        {
            Action = Action.Delay,
            Duration = "duration",
            Until = "until",
        };

        ApiEnum<string, Action> expectedAction = Action.Delay;
        string expectedDuration = "duration";
        string expectedUntil = "until";

        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedUntil, model.Until);
    }
}

public class AutomationSendStepTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutomationSendStep
        {
            Action = AutomationSendStepAction.Send,
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Recipient = "recipient",
            Template = "template",
        };

        ApiEnum<string, AutomationSendStepAction> expectedAction = AutomationSendStepAction.Send;
        string expectedBrand = "brand";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Dictionary<string, JsonElement> expectedProfile = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedRecipient = "recipient";
        string expectedTemplate = "template";

        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedBrand, model.Brand);
        Assert.Equal(expectedData.Count, model.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(model.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Data[item.Key]));
        }
        Assert.Equal(expectedProfile.Count, model.Profile.Count);
        foreach (var item in expectedProfile)
        {
            Assert.True(model.Profile.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Profile[item.Key]));
        }
        Assert.Equal(expectedRecipient, model.Recipient);
        Assert.Equal(expectedTemplate, model.Template);
    }
}

public class AutomationSendListStepTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutomationSendListStep
        {
            Action = AutomationSendListStepAction.SendList,
            List = "list",
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        ApiEnum<string, AutomationSendListStepAction> expectedAction =
            AutomationSendListStepAction.SendList;
        string expectedList = "list";
        string expectedBrand = "brand";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedList, model.List);
        Assert.Equal(expectedBrand, model.Brand);
        Assert.Equal(expectedData.Count, model.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(model.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Data[item.Key]));
        }
    }
}

public class AutomationUpdateProfileStepTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutomationUpdateProfileStep
        {
            Action = AutomationUpdateProfileStepAction.UpdateProfile,
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Merge = Merge.None,
            RecipientID = "recipient_id",
        };

        ApiEnum<string, AutomationUpdateProfileStepAction> expectedAction =
            AutomationUpdateProfileStepAction.UpdateProfile;
        Dictionary<string, JsonElement> expectedProfile = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, Merge> expectedMerge = Merge.None;
        string expectedRecipientID = "recipient_id";

        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedProfile.Count, model.Profile.Count);
        foreach (var item in expectedProfile)
        {
            Assert.True(model.Profile.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Profile[item.Key]));
        }
        Assert.Equal(expectedMerge, model.Merge);
        Assert.Equal(expectedRecipientID, model.RecipientID);
    }
}

public class AutomationCancelStepTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutomationCancelStep
        {
            Action = AutomationCancelStepAction.Cancel,
            CancelationToken = "cancelation_token",
        };

        ApiEnum<string, AutomationCancelStepAction> expectedAction =
            AutomationCancelStepAction.Cancel;
        string expectedCancelationToken = "cancelation_token";

        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedCancelationToken, model.CancelationToken);
    }
}

public class AutomationFetchDataStepTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutomationFetchDataStep
        {
            Action = AutomationFetchDataStepAction.FetchData,
            Webhook = new()
            {
                Method = Method.Get,
                URL = "url",
                Body = "body",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
            MergeStrategy = MergeStrategy.Replace,
        };

        ApiEnum<string, AutomationFetchDataStepAction> expectedAction =
            AutomationFetchDataStepAction.FetchData;
        Webhook expectedWebhook = new()
        {
            Method = Method.Get,
            URL = "url",
            Body = "body",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };
        ApiEnum<string, MergeStrategy> expectedMergeStrategy = MergeStrategy.Replace;

        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedWebhook, model.Webhook);
        Assert.Equal(expectedMergeStrategy, model.MergeStrategy);
    }
}

public class WebhookTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Webhook
        {
            Method = Method.Get,
            URL = "url",
            Body = "body",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        ApiEnum<string, Method> expectedMethod = Method.Get;
        string expectedURL = "url";
        string expectedBody = "body";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };

        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedURL, model.URL);
        Assert.Equal(expectedBody, model.Body);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
    }
}

public class AutomationInvokeStepTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutomationInvokeStep
        {
            Action = AutomationInvokeStepAction.Invoke,
            Template = "template",
        };

        ApiEnum<string, AutomationInvokeStepAction> expectedAction =
            AutomationInvokeStepAction.Invoke;
        string expectedTemplate = "template";

        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedTemplate, model.Template);
    }
}
