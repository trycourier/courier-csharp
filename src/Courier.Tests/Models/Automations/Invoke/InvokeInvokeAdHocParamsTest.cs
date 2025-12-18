using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Automation>(element);
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

public class StepTest : TestBase
{
    [Fact]
    public void AutomationDelayValidationWorks()
    {
        Step value = new(
            new AutomationDelayStep()
            {
                Action = Action.Delay,
                Duration = "duration",
                Until = "until",
            }
        );
        value.Validate();
    }

    [Fact]
    public void AutomationSendValidationWorks()
    {
        Step value = new(
            new AutomationSendStep()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void AutomationSendListValidationWorks()
    {
        Step value = new(
            new AutomationSendListStep()
            {
                Action = AutomationSendListStepAction.SendList,
                List = "list",
                Brand = "brand",
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            }
        );
        value.Validate();
    }

    [Fact]
    public void AutomationUpdateProfileValidationWorks()
    {
        Step value = new(
            new AutomationUpdateProfileStep()
            {
                Action = AutomationUpdateProfileStepAction.UpdateProfile,
                Profile = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Merge = Merge.None,
                RecipientID = "recipient_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void AutomationCancelValidationWorks()
    {
        Step value = new(
            new AutomationCancelStep()
            {
                Action = AutomationCancelStepAction.Cancel,
                CancelationToken = "cancelation_token",
            }
        );
        value.Validate();
    }

    [Fact]
    public void AutomationFetchDataValidationWorks()
    {
        Step value = new(
            new AutomationFetchDataStep()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void AutomationInvokeValidationWorks()
    {
        Step value = new(
            new AutomationInvokeStep()
            {
                Action = AutomationInvokeStepAction.Invoke,
                Template = "template",
            }
        );
        value.Validate();
    }

    [Fact]
    public void AutomationDelaySerializationRoundtripWorks()
    {
        Step value = new(
            new AutomationDelayStep()
            {
                Action = Action.Delay,
                Duration = "duration",
                Until = "until",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Step>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutomationSendSerializationRoundtripWorks()
    {
        Step value = new(
            new AutomationSendStep()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Step>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutomationSendListSerializationRoundtripWorks()
    {
        Step value = new(
            new AutomationSendListStep()
            {
                Action = AutomationSendListStepAction.SendList,
                List = "list",
                Brand = "brand",
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Step>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutomationUpdateProfileSerializationRoundtripWorks()
    {
        Step value = new(
            new AutomationUpdateProfileStep()
            {
                Action = AutomationUpdateProfileStepAction.UpdateProfile,
                Profile = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Merge = Merge.None,
                RecipientID = "recipient_id",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Step>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutomationCancelSerializationRoundtripWorks()
    {
        Step value = new(
            new AutomationCancelStep()
            {
                Action = AutomationCancelStepAction.Cancel,
                CancelationToken = "cancelation_token",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Step>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutomationFetchDataSerializationRoundtripWorks()
    {
        Step value = new(
            new AutomationFetchDataStep()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Step>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutomationInvokeSerializationRoundtripWorks()
    {
        Step value = new(
            new AutomationInvokeStep()
            {
                Action = AutomationInvokeStepAction.Invoke,
                Template = "template",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Step>(element);

        Assert.Equal(value, deserialized);
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationDelayStep>(element);
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

public class ActionTest : TestBase
{
    [Theory]
    [InlineData(Action.Delay)]
    public void Validation_Works(Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Action> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Action>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Action.Delay)]
    public void SerializationRoundtrip_Works(Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Action> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Action>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationSendStep>(element);
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

public class AutomationSendStepActionTest : TestBase
{
    [Theory]
    [InlineData(AutomationSendStepAction.Send)]
    public void Validation_Works(AutomationSendStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AutomationSendStepAction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AutomationSendStepAction>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AutomationSendStepAction.Send)]
    public void SerializationRoundtrip_Works(AutomationSendStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AutomationSendStepAction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AutomationSendStepAction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AutomationSendStepAction>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AutomationSendStepAction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationSendListStep>(element);
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

public class AutomationSendListStepActionTest : TestBase
{
    [Theory]
    [InlineData(AutomationSendListStepAction.SendList)]
    public void Validation_Works(AutomationSendListStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AutomationSendListStepAction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AutomationSendListStepAction>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AutomationSendListStepAction.SendList)]
    public void SerializationRoundtrip_Works(AutomationSendListStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AutomationSendListStepAction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AutomationSendListStepAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AutomationSendListStepAction>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AutomationSendListStepAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationUpdateProfileStep>(element);
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

public class AutomationUpdateProfileStepActionTest : TestBase
{
    [Theory]
    [InlineData(AutomationUpdateProfileStepAction.UpdateProfile)]
    public void Validation_Works(AutomationUpdateProfileStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AutomationUpdateProfileStepAction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AutomationUpdateProfileStepAction>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AutomationUpdateProfileStepAction.UpdateProfile)]
    public void SerializationRoundtrip_Works(AutomationUpdateProfileStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AutomationUpdateProfileStepAction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AutomationUpdateProfileStepAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AutomationUpdateProfileStepAction>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AutomationUpdateProfileStepAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MergeTest : TestBase
{
    [Theory]
    [InlineData(Merge.None)]
    [InlineData(Merge.Overwrite)]
    [InlineData(Merge.SoftMerge)]
    [InlineData(Merge.Replace)]
    public void Validation_Works(Merge rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Merge> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Merge>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Merge.None)]
    [InlineData(Merge.Overwrite)]
    [InlineData(Merge.SoftMerge)]
    [InlineData(Merge.Replace)]
    public void SerializationRoundtrip_Works(Merge rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Merge> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Merge>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Merge>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Merge>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationCancelStep>(element);
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

public class AutomationCancelStepActionTest : TestBase
{
    [Theory]
    [InlineData(AutomationCancelStepAction.Cancel)]
    public void Validation_Works(AutomationCancelStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AutomationCancelStepAction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AutomationCancelStepAction>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AutomationCancelStepAction.Cancel)]
    public void SerializationRoundtrip_Works(AutomationCancelStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AutomationCancelStepAction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AutomationCancelStepAction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AutomationCancelStepAction>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AutomationCancelStepAction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationFetchDataStep>(element);
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

public class AutomationFetchDataStepActionTest : TestBase
{
    [Theory]
    [InlineData(AutomationFetchDataStepAction.FetchData)]
    public void Validation_Works(AutomationFetchDataStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AutomationFetchDataStepAction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AutomationFetchDataStepAction>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AutomationFetchDataStepAction.FetchData)]
    public void SerializationRoundtrip_Works(AutomationFetchDataStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AutomationFetchDataStepAction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AutomationFetchDataStepAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AutomationFetchDataStepAction>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AutomationFetchDataStepAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Webhook>(element);
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

public class MethodTest : TestBase
{
    [Theory]
    [InlineData(Method.Get)]
    [InlineData(Method.Post)]
    [InlineData(Method.Put)]
    [InlineData(Method.Patch)]
    [InlineData(Method.Delete)]
    public void Validation_Works(Method rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Method> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Method.Get)]
    [InlineData(Method.Post)]
    [InlineData(Method.Put)]
    [InlineData(Method.Patch)]
    [InlineData(Method.Delete)]
    public void SerializationRoundtrip_Works(Method rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Method> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MergeStrategyTest : TestBase
{
    [Theory]
    [InlineData(MergeStrategy.Replace)]
    [InlineData(MergeStrategy.Overwrite)]
    [InlineData(MergeStrategy.SoftMerge)]
    public void Validation_Works(MergeStrategy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MergeStrategy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MergeStrategy>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MergeStrategy.Replace)]
    [InlineData(MergeStrategy.Overwrite)]
    [InlineData(MergeStrategy.SoftMerge)]
    public void SerializationRoundtrip_Works(MergeStrategy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MergeStrategy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MergeStrategy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MergeStrategy>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MergeStrategy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationInvokeStep>(element);
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

public class AutomationInvokeStepActionTest : TestBase
{
    [Theory]
    [InlineData(AutomationInvokeStepAction.Invoke)]
    public void Validation_Works(AutomationInvokeStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AutomationInvokeStepAction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AutomationInvokeStepAction>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AutomationInvokeStepAction.Invoke)]
    public void SerializationRoundtrip_Works(AutomationInvokeStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AutomationInvokeStepAction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AutomationInvokeStepAction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AutomationInvokeStepAction>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AutomationInvokeStepAction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
