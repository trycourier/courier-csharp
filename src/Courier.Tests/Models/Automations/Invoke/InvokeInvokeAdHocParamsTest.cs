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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Automation>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Automation>(json);
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedSteps.Count, deserialized.Steps.Count);
        for (int i = 0; i < expectedSteps.Count; i++)
        {
            Assert.Equal(expectedSteps[i], deserialized.Steps[i]);
        }
        Assert.Equal(expectedCancelationToken, deserialized.CancelationToken);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
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
        };

        Assert.Null(model.CancelationToken);
        Assert.False(model.RawData.ContainsKey("cancelation_token"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
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

            CancelationToken = null,
        };

        Assert.Null(model.CancelationToken);
        Assert.True(model.RawData.ContainsKey("cancelation_token"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
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

            CancelationToken = null,
        };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutomationDelayStep
        {
            Action = Action.Delay,
            Duration = "duration",
            Until = "until",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationDelayStep>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutomationDelayStep
        {
            Action = Action.Delay,
            Duration = "duration",
            Until = "until",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationDelayStep>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, Action> expectedAction = Action.Delay;
        string expectedDuration = "duration";
        string expectedUntil = "until";

        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedUntil, deserialized.Until);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutomationDelayStep
        {
            Action = Action.Delay,
            Duration = "duration",
            Until = "until",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AutomationDelayStep { Action = Action.Delay };

        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.Until);
        Assert.False(model.RawData.ContainsKey("until"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AutomationDelayStep { Action = Action.Delay };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AutomationDelayStep
        {
            Action = Action.Delay,

            Duration = null,
            Until = null,
        };

        Assert.Null(model.Duration);
        Assert.True(model.RawData.ContainsKey("duration"));
        Assert.Null(model.Until);
        Assert.True(model.RawData.ContainsKey("until"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AutomationDelayStep
        {
            Action = Action.Delay,

            Duration = null,
            Until = null,
        };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationSendStep>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationSendStep>(json);
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedBrand, deserialized.Brand);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(deserialized.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Data[item.Key]));
        }
        Assert.Equal(expectedProfile.Count, deserialized.Profile.Count);
        foreach (var item in expectedProfile)
        {
            Assert.True(deserialized.Profile.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Profile[item.Key]));
        }
        Assert.Equal(expectedRecipient, deserialized.Recipient);
        Assert.Equal(expectedTemplate, deserialized.Template);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AutomationSendStep { Action = AutomationSendStepAction.Send };

        Assert.Null(model.Brand);
        Assert.False(model.RawData.ContainsKey("brand"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Profile);
        Assert.False(model.RawData.ContainsKey("profile"));
        Assert.Null(model.Recipient);
        Assert.False(model.RawData.ContainsKey("recipient"));
        Assert.Null(model.Template);
        Assert.False(model.RawData.ContainsKey("template"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AutomationSendStep { Action = AutomationSendStepAction.Send };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AutomationSendStep
        {
            Action = AutomationSendStepAction.Send,

            Brand = null,
            Data = null,
            Profile = null,
            Recipient = null,
            Template = null,
        };

        Assert.Null(model.Brand);
        Assert.True(model.RawData.ContainsKey("brand"));
        Assert.Null(model.Data);
        Assert.True(model.RawData.ContainsKey("data"));
        Assert.Null(model.Profile);
        Assert.True(model.RawData.ContainsKey("profile"));
        Assert.Null(model.Recipient);
        Assert.True(model.RawData.ContainsKey("recipient"));
        Assert.Null(model.Template);
        Assert.True(model.RawData.ContainsKey("template"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AutomationSendStep
        {
            Action = AutomationSendStepAction.Send,

            Brand = null,
            Data = null,
            Profile = null,
            Recipient = null,
            Template = null,
        };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationSendListStep>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationSendListStep>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, AutomationSendListStepAction> expectedAction =
            AutomationSendListStepAction.SendList;
        string expectedList = "list";
        string expectedBrand = "brand";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedList, deserialized.List);
        Assert.Equal(expectedBrand, deserialized.Brand);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(deserialized.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Data[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AutomationSendListStep
        {
            Action = AutomationSendListStepAction.SendList,
            List = "list",
        };

        Assert.Null(model.Brand);
        Assert.False(model.RawData.ContainsKey("brand"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AutomationSendListStep
        {
            Action = AutomationSendListStepAction.SendList,
            List = "list",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AutomationSendListStep
        {
            Action = AutomationSendListStepAction.SendList,
            List = "list",

            Brand = null,
            Data = null,
        };

        Assert.Null(model.Brand);
        Assert.True(model.RawData.ContainsKey("brand"));
        Assert.Null(model.Data);
        Assert.True(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AutomationSendListStep
        {
            Action = AutomationSendListStepAction.SendList,
            List = "list",

            Brand = null,
            Data = null,
        };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationUpdateProfileStep>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationUpdateProfileStep>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, AutomationUpdateProfileStepAction> expectedAction =
            AutomationUpdateProfileStepAction.UpdateProfile;
        Dictionary<string, JsonElement> expectedProfile = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, Merge> expectedMerge = Merge.None;
        string expectedRecipientID = "recipient_id";

        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedProfile.Count, deserialized.Profile.Count);
        foreach (var item in expectedProfile)
        {
            Assert.True(deserialized.Profile.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Profile[item.Key]));
        }
        Assert.Equal(expectedMerge, deserialized.Merge);
        Assert.Equal(expectedRecipientID, deserialized.RecipientID);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AutomationUpdateProfileStep
        {
            Action = AutomationUpdateProfileStepAction.UpdateProfile,
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Assert.Null(model.Merge);
        Assert.False(model.RawData.ContainsKey("merge"));
        Assert.Null(model.RecipientID);
        Assert.False(model.RawData.ContainsKey("recipient_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AutomationUpdateProfileStep
        {
            Action = AutomationUpdateProfileStepAction.UpdateProfile,
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AutomationUpdateProfileStep
        {
            Action = AutomationUpdateProfileStepAction.UpdateProfile,
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            Merge = null,
            RecipientID = null,
        };

        Assert.Null(model.Merge);
        Assert.True(model.RawData.ContainsKey("merge"));
        Assert.Null(model.RecipientID);
        Assert.True(model.RawData.ContainsKey("recipient_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AutomationUpdateProfileStep
        {
            Action = AutomationUpdateProfileStepAction.UpdateProfile,
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            Merge = null,
            RecipientID = null,
        };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutomationCancelStep
        {
            Action = AutomationCancelStepAction.Cancel,
            CancelationToken = "cancelation_token",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationCancelStep>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutomationCancelStep
        {
            Action = AutomationCancelStepAction.Cancel,
            CancelationToken = "cancelation_token",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationCancelStep>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, AutomationCancelStepAction> expectedAction =
            AutomationCancelStepAction.Cancel;
        string expectedCancelationToken = "cancelation_token";

        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedCancelationToken, deserialized.CancelationToken);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutomationCancelStep
        {
            Action = AutomationCancelStepAction.Cancel,
            CancelationToken = "cancelation_token",
        };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationFetchDataStep>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationFetchDataStep>(json);
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedWebhook, deserialized.Webhook);
        Assert.Equal(expectedMergeStrategy, deserialized.MergeStrategy);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
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
        };

        Assert.Null(model.MergeStrategy);
        Assert.False(model.RawData.ContainsKey("merge_strategy"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
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

            MergeStrategy = null,
        };

        Assert.Null(model.MergeStrategy);
        Assert.True(model.RawData.ContainsKey("merge_strategy"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
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

            MergeStrategy = null,
        };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Webhook
        {
            Method = Method.Get,
            URL = "url",
            Body = "body",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Webhook>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Webhook
        {
            Method = Method.Get,
            URL = "url",
            Body = "body",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Webhook>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, Method> expectedMethod = Method.Get;
        string expectedURL = "url";
        string expectedBody = "body";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };

        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedURL, deserialized.URL);
        Assert.Equal(expectedBody, deserialized.Body);
        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Webhook
        {
            Method = Method.Get,
            URL = "url",
            Body = "body",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Webhook { Method = Method.Get, URL = "url" };

        Assert.Null(model.Body);
        Assert.False(model.RawData.ContainsKey("body"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Webhook { Method = Method.Get, URL = "url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Webhook
        {
            Method = Method.Get,
            URL = "url",

            Body = null,
            Headers = null,
        };

        Assert.Null(model.Body);
        Assert.True(model.RawData.ContainsKey("body"));
        Assert.Null(model.Headers);
        Assert.True(model.RawData.ContainsKey("headers"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Webhook
        {
            Method = Method.Get,
            URL = "url",

            Body = null,
            Headers = null,
        };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutomationInvokeStep
        {
            Action = AutomationInvokeStepAction.Invoke,
            Template = "template",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationInvokeStep>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutomationInvokeStep
        {
            Action = AutomationInvokeStepAction.Invoke,
            Template = "template",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationInvokeStep>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, AutomationInvokeStepAction> expectedAction =
            AutomationInvokeStepAction.Invoke;
        string expectedTemplate = "template";

        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedTemplate, deserialized.Template);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutomationInvokeStep
        {
            Action = AutomationInvokeStepAction.Invoke,
            Template = "template",
        };

        model.Validate();
    }
}
