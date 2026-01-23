using System;
using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Invoke = Courier.Models.Automations.Invoke;

namespace Courier.Tests.Models.Automations.Invoke;

public class InvokeInvokeAdHocParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Invoke::InvokeInvokeAdHocParams
        {
            Automation = new()
            {
                Steps =
                [
                    new Invoke::AutomationDelayStep()
                    {
                        Action = Invoke::Action.Delay,
                        Duration = "duration",
                        Until = "20240408T080910.123",
                    },
                    new Invoke::AutomationSendStep()
                    {
                        Action = Invoke::AutomationSendStepAction.Send,
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
                        Template = "64TP5HKPFTM8VTK1Y75SJDQX9JK0",
                    },
                ],
                CancelationToken = "delay-send--user-yes--abc-123",
            },
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "name", JsonSerializer.SerializeToElement("bar") },
            },
            Profile = new Dictionary<string, JsonElement>()
            {
                { "tenant_id", JsonSerializer.SerializeToElement("bar") },
            },
            Recipient = "user-yes",
            Template = "template",
        };

        Invoke::Automation expectedAutomation = new()
        {
            Steps =
            [
                new Invoke::AutomationDelayStep()
                {
                    Action = Invoke::Action.Delay,
                    Duration = "duration",
                    Until = "20240408T080910.123",
                },
                new Invoke::AutomationSendStep()
                {
                    Action = Invoke::AutomationSendStepAction.Send,
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
                    Template = "64TP5HKPFTM8VTK1Y75SJDQX9JK0",
                },
            ],
            CancelationToken = "delay-send--user-yes--abc-123",
        };
        string expectedBrand = "brand";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "name", JsonSerializer.SerializeToElement("bar") },
        };
        Dictionary<string, JsonElement> expectedProfile = new()
        {
            { "tenant_id", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedRecipient = "user-yes";
        string expectedTemplate = "template";

        Assert.Equal(expectedAutomation, parameters.Automation);
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
        Assert.Equal(expectedRecipient, parameters.Recipient);
        Assert.Equal(expectedTemplate, parameters.Template);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Invoke::InvokeInvokeAdHocParams
        {
            Automation = new()
            {
                Steps =
                [
                    new Invoke::AutomationDelayStep()
                    {
                        Action = Invoke::Action.Delay,
                        Duration = "duration",
                        Until = "20240408T080910.123",
                    },
                    new Invoke::AutomationSendStep()
                    {
                        Action = Invoke::AutomationSendStepAction.Send,
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
                        Template = "64TP5HKPFTM8VTK1Y75SJDQX9JK0",
                    },
                ],
                CancelationToken = "delay-send--user-yes--abc-123",
            },
        };

        Assert.Null(parameters.Brand);
        Assert.False(parameters.RawBodyData.ContainsKey("brand"));
        Assert.Null(parameters.Data);
        Assert.False(parameters.RawBodyData.ContainsKey("data"));
        Assert.Null(parameters.Profile);
        Assert.False(parameters.RawBodyData.ContainsKey("profile"));
        Assert.Null(parameters.Recipient);
        Assert.False(parameters.RawBodyData.ContainsKey("recipient"));
        Assert.Null(parameters.Template);
        Assert.False(parameters.RawBodyData.ContainsKey("template"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Invoke::InvokeInvokeAdHocParams
        {
            Automation = new()
            {
                Steps =
                [
                    new Invoke::AutomationDelayStep()
                    {
                        Action = Invoke::Action.Delay,
                        Duration = "duration",
                        Until = "20240408T080910.123",
                    },
                    new Invoke::AutomationSendStep()
                    {
                        Action = Invoke::AutomationSendStepAction.Send,
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
                        Template = "64TP5HKPFTM8VTK1Y75SJDQX9JK0",
                    },
                ],
                CancelationToken = "delay-send--user-yes--abc-123",
            },

            Brand = null,
            Data = null,
            Profile = null,
            Recipient = null,
            Template = null,
        };

        Assert.Null(parameters.Brand);
        Assert.True(parameters.RawBodyData.ContainsKey("brand"));
        Assert.Null(parameters.Data);
        Assert.True(parameters.RawBodyData.ContainsKey("data"));
        Assert.Null(parameters.Profile);
        Assert.True(parameters.RawBodyData.ContainsKey("profile"));
        Assert.Null(parameters.Recipient);
        Assert.True(parameters.RawBodyData.ContainsKey("recipient"));
        Assert.Null(parameters.Template);
        Assert.True(parameters.RawBodyData.ContainsKey("template"));
    }

    [Fact]
    public void Url_Works()
    {
        Invoke::InvokeInvokeAdHocParams parameters = new()
        {
            Automation = new()
            {
                Steps =
                [
                    new Invoke::AutomationDelayStep()
                    {
                        Action = Invoke::Action.Delay,
                        Duration = "duration",
                        Until = "20240408T080910.123",
                    },
                    new Invoke::AutomationSendStep()
                    {
                        Action = Invoke::AutomationSendStepAction.Send,
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
                        Template = "64TP5HKPFTM8VTK1Y75SJDQX9JK0",
                    },
                ],
                CancelationToken = "delay-send--user-yes--abc-123",
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/automations/invoke"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Invoke::InvokeInvokeAdHocParams
        {
            Automation = new()
            {
                Steps =
                [
                    new Invoke::AutomationDelayStep()
                    {
                        Action = Invoke::Action.Delay,
                        Duration = "duration",
                        Until = "20240408T080910.123",
                    },
                    new Invoke::AutomationSendStep()
                    {
                        Action = Invoke::AutomationSendStepAction.Send,
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
                        Template = "64TP5HKPFTM8VTK1Y75SJDQX9JK0",
                    },
                ],
                CancelationToken = "delay-send--user-yes--abc-123",
            },
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "name", JsonSerializer.SerializeToElement("bar") },
            },
            Profile = new Dictionary<string, JsonElement>()
            {
                { "tenant_id", JsonSerializer.SerializeToElement("bar") },
            },
            Recipient = "user-yes",
            Template = "template",
        };

        Invoke::InvokeInvokeAdHocParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AutomationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoke::Automation
        {
            Steps =
            [
                new Invoke::AutomationDelayStep()
                {
                    Action = Invoke::Action.Delay,
                    Duration = "duration",
                    Until = "until",
                },
            ],
            CancelationToken = "cancelation_token",
        };

        List<Invoke::Step> expectedSteps =
        [
            new Invoke::AutomationDelayStep()
            {
                Action = Invoke::Action.Delay,
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
        var model = new Invoke::Automation
        {
            Steps =
            [
                new Invoke::AutomationDelayStep()
                {
                    Action = Invoke::Action.Delay,
                    Duration = "duration",
                    Until = "until",
                },
            ],
            CancelationToken = "cancelation_token",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::Automation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoke::Automation
        {
            Steps =
            [
                new Invoke::AutomationDelayStep()
                {
                    Action = Invoke::Action.Delay,
                    Duration = "duration",
                    Until = "until",
                },
            ],
            CancelationToken = "cancelation_token",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::Automation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Invoke::Step> expectedSteps =
        [
            new Invoke::AutomationDelayStep()
            {
                Action = Invoke::Action.Delay,
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
        var model = new Invoke::Automation
        {
            Steps =
            [
                new Invoke::AutomationDelayStep()
                {
                    Action = Invoke::Action.Delay,
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
        var model = new Invoke::Automation
        {
            Steps =
            [
                new Invoke::AutomationDelayStep()
                {
                    Action = Invoke::Action.Delay,
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
        var model = new Invoke::Automation
        {
            Steps =
            [
                new Invoke::AutomationDelayStep()
                {
                    Action = Invoke::Action.Delay,
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
        var model = new Invoke::Automation
        {
            Steps =
            [
                new Invoke::AutomationDelayStep()
                {
                    Action = Invoke::Action.Delay,
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
        var model = new Invoke::Automation
        {
            Steps =
            [
                new Invoke::AutomationDelayStep()
                {
                    Action = Invoke::Action.Delay,
                    Duration = "duration",
                    Until = "until",
                },
            ],

            CancelationToken = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoke::Automation
        {
            Steps =
            [
                new Invoke::AutomationDelayStep()
                {
                    Action = Invoke::Action.Delay,
                    Duration = "duration",
                    Until = "until",
                },
            ],
            CancelationToken = "cancelation_token",
        };

        Invoke::Automation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StepTest : TestBase
{
    [Fact]
    public void AutomationDelayValidationWorks()
    {
        Invoke::Step value = new Invoke::AutomationDelayStep()
        {
            Action = Invoke::Action.Delay,
            Duration = "duration",
            Until = "until",
        };
        value.Validate();
    }

    [Fact]
    public void AutomationSendValidationWorks()
    {
        Invoke::Step value = new Invoke::AutomationSendStep()
        {
            Action = Invoke::AutomationSendStepAction.Send,
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
        value.Validate();
    }

    [Fact]
    public void AutomationSendListValidationWorks()
    {
        Invoke::Step value = new Invoke::AutomationSendListStep()
        {
            Action = Invoke::AutomationSendListStepAction.SendList,
            List = "list",
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };
        value.Validate();
    }

    [Fact]
    public void AutomationUpdateProfileValidationWorks()
    {
        Invoke::Step value = new Invoke::AutomationUpdateProfileStep()
        {
            Action = Invoke::AutomationUpdateProfileStepAction.UpdateProfile,
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Merge = Invoke::Merge.None,
            RecipientID = "recipient_id",
        };
        value.Validate();
    }

    [Fact]
    public void AutomationCancelValidationWorks()
    {
        Invoke::Step value = new Invoke::AutomationCancelStep()
        {
            Action = Invoke::AutomationCancelStepAction.Cancel,
            CancelationToken = "cancelation_token",
        };
        value.Validate();
    }

    [Fact]
    public void AutomationFetchDataValidationWorks()
    {
        Invoke::Step value = new Invoke::AutomationFetchDataStep()
        {
            Action = Invoke::AutomationFetchDataStepAction.FetchData,
            Webhook = new()
            {
                Method = Invoke::Method.Get,
                Url = "url",
                Body = "body",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
            MergeStrategy = Invoke::MergeStrategy.Replace,
        };
        value.Validate();
    }

    [Fact]
    public void AutomationInvokeValidationWorks()
    {
        Invoke::Step value = new Invoke::AutomationInvokeStep()
        {
            Action = Invoke::AutomationInvokeStepAction.Invoke,
            Template = "template",
        };
        value.Validate();
    }

    [Fact]
    public void AutomationDelaySerializationRoundtripWorks()
    {
        Invoke::Step value = new Invoke::AutomationDelayStep()
        {
            Action = Invoke::Action.Delay,
            Duration = "duration",
            Until = "until",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::Step>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutomationSendSerializationRoundtripWorks()
    {
        Invoke::Step value = new Invoke::AutomationSendStep()
        {
            Action = Invoke::AutomationSendStepAction.Send,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::Step>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutomationSendListSerializationRoundtripWorks()
    {
        Invoke::Step value = new Invoke::AutomationSendListStep()
        {
            Action = Invoke::AutomationSendListStepAction.SendList,
            List = "list",
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::Step>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutomationUpdateProfileSerializationRoundtripWorks()
    {
        Invoke::Step value = new Invoke::AutomationUpdateProfileStep()
        {
            Action = Invoke::AutomationUpdateProfileStepAction.UpdateProfile,
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Merge = Invoke::Merge.None,
            RecipientID = "recipient_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::Step>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutomationCancelSerializationRoundtripWorks()
    {
        Invoke::Step value = new Invoke::AutomationCancelStep()
        {
            Action = Invoke::AutomationCancelStepAction.Cancel,
            CancelationToken = "cancelation_token",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::Step>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutomationFetchDataSerializationRoundtripWorks()
    {
        Invoke::Step value = new Invoke::AutomationFetchDataStep()
        {
            Action = Invoke::AutomationFetchDataStepAction.FetchData,
            Webhook = new()
            {
                Method = Invoke::Method.Get,
                Url = "url",
                Body = "body",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
            MergeStrategy = Invoke::MergeStrategy.Replace,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::Step>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutomationInvokeSerializationRoundtripWorks()
    {
        Invoke::Step value = new Invoke::AutomationInvokeStep()
        {
            Action = Invoke::AutomationInvokeStepAction.Invoke,
            Template = "template",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::Step>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AutomationDelayStepTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoke::AutomationDelayStep
        {
            Action = Invoke::Action.Delay,
            Duration = "duration",
            Until = "until",
        };

        ApiEnum<string, Invoke::Action> expectedAction = Invoke::Action.Delay;
        string expectedDuration = "duration";
        string expectedUntil = "until";

        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedUntil, model.Until);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invoke::AutomationDelayStep
        {
            Action = Invoke::Action.Delay,
            Duration = "duration",
            Until = "until",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::AutomationDelayStep>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoke::AutomationDelayStep
        {
            Action = Invoke::Action.Delay,
            Duration = "duration",
            Until = "until",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::AutomationDelayStep>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Invoke::Action> expectedAction = Invoke::Action.Delay;
        string expectedDuration = "duration";
        string expectedUntil = "until";

        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedUntil, deserialized.Until);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invoke::AutomationDelayStep
        {
            Action = Invoke::Action.Delay,
            Duration = "duration",
            Until = "until",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Invoke::AutomationDelayStep { Action = Invoke::Action.Delay };

        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.Until);
        Assert.False(model.RawData.ContainsKey("until"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Invoke::AutomationDelayStep { Action = Invoke::Action.Delay };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Invoke::AutomationDelayStep
        {
            Action = Invoke::Action.Delay,

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
        var model = new Invoke::AutomationDelayStep
        {
            Action = Invoke::Action.Delay,

            Duration = null,
            Until = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoke::AutomationDelayStep
        {
            Action = Invoke::Action.Delay,
            Duration = "duration",
            Until = "until",
        };

        Invoke::AutomationDelayStep copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ActionTest : TestBase
{
    [Theory]
    [InlineData(Invoke::Action.Delay)]
    public void Validation_Works(Invoke::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoke::Action> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoke::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoke::Action.Delay)]
    public void SerializationRoundtrip_Works(Invoke::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoke::Action> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoke::Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoke::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoke::Action>>(
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
        var model = new Invoke::AutomationSendStep
        {
            Action = Invoke::AutomationSendStepAction.Send,
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

        ApiEnum<string, Invoke::AutomationSendStepAction> expectedAction =
            Invoke::AutomationSendStepAction.Send;
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
        Assert.NotNull(model.Data);
        Assert.Equal(expectedData.Count, model.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(model.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Data[item.Key]));
        }
        Assert.NotNull(model.Profile);
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
        var model = new Invoke::AutomationSendStep
        {
            Action = Invoke::AutomationSendStepAction.Send,
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::AutomationSendStep>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoke::AutomationSendStep
        {
            Action = Invoke::AutomationSendStepAction.Send,
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::AutomationSendStep>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Invoke::AutomationSendStepAction> expectedAction =
            Invoke::AutomationSendStepAction.Send;
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
        Assert.NotNull(deserialized.Data);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(deserialized.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Data[item.Key]));
        }
        Assert.NotNull(deserialized.Profile);
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
        var model = new Invoke::AutomationSendStep
        {
            Action = Invoke::AutomationSendStepAction.Send,
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
        var model = new Invoke::AutomationSendStep
        {
            Action = Invoke::AutomationSendStepAction.Send,
        };

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
        var model = new Invoke::AutomationSendStep
        {
            Action = Invoke::AutomationSendStepAction.Send,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Invoke::AutomationSendStep
        {
            Action = Invoke::AutomationSendStepAction.Send,

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
        var model = new Invoke::AutomationSendStep
        {
            Action = Invoke::AutomationSendStepAction.Send,

            Brand = null,
            Data = null,
            Profile = null,
            Recipient = null,
            Template = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoke::AutomationSendStep
        {
            Action = Invoke::AutomationSendStepAction.Send,
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

        Invoke::AutomationSendStep copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AutomationSendStepActionTest : TestBase
{
    [Theory]
    [InlineData(Invoke::AutomationSendStepAction.Send)]
    public void Validation_Works(Invoke::AutomationSendStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoke::AutomationSendStepAction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoke::AutomationSendStepAction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoke::AutomationSendStepAction.Send)]
    public void SerializationRoundtrip_Works(Invoke::AutomationSendStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoke::AutomationSendStepAction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Invoke::AutomationSendStepAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoke::AutomationSendStepAction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Invoke::AutomationSendStepAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AutomationSendListStepTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoke::AutomationSendListStep
        {
            Action = Invoke::AutomationSendListStepAction.SendList,
            List = "list",
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        ApiEnum<string, Invoke::AutomationSendListStepAction> expectedAction =
            Invoke::AutomationSendListStepAction.SendList;
        string expectedList = "list";
        string expectedBrand = "brand";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedList, model.List);
        Assert.Equal(expectedBrand, model.Brand);
        Assert.NotNull(model.Data);
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
        var model = new Invoke::AutomationSendListStep
        {
            Action = Invoke::AutomationSendListStepAction.SendList,
            List = "list",
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::AutomationSendListStep>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoke::AutomationSendListStep
        {
            Action = Invoke::AutomationSendListStepAction.SendList,
            List = "list",
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::AutomationSendListStep>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Invoke::AutomationSendListStepAction> expectedAction =
            Invoke::AutomationSendListStepAction.SendList;
        string expectedList = "list";
        string expectedBrand = "brand";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedList, deserialized.List);
        Assert.Equal(expectedBrand, deserialized.Brand);
        Assert.NotNull(deserialized.Data);
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
        var model = new Invoke::AutomationSendListStep
        {
            Action = Invoke::AutomationSendListStepAction.SendList,
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
        var model = new Invoke::AutomationSendListStep
        {
            Action = Invoke::AutomationSendListStepAction.SendList,
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
        var model = new Invoke::AutomationSendListStep
        {
            Action = Invoke::AutomationSendListStepAction.SendList,
            List = "list",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Invoke::AutomationSendListStep
        {
            Action = Invoke::AutomationSendListStepAction.SendList,
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
        var model = new Invoke::AutomationSendListStep
        {
            Action = Invoke::AutomationSendListStepAction.SendList,
            List = "list",

            Brand = null,
            Data = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoke::AutomationSendListStep
        {
            Action = Invoke::AutomationSendListStepAction.SendList,
            List = "list",
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Invoke::AutomationSendListStep copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AutomationSendListStepActionTest : TestBase
{
    [Theory]
    [InlineData(Invoke::AutomationSendListStepAction.SendList)]
    public void Validation_Works(Invoke::AutomationSendListStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoke::AutomationSendListStepAction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Invoke::AutomationSendListStepAction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoke::AutomationSendListStepAction.SendList)]
    public void SerializationRoundtrip_Works(Invoke::AutomationSendListStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoke::AutomationSendListStepAction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Invoke::AutomationSendListStepAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Invoke::AutomationSendListStepAction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Invoke::AutomationSendListStepAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AutomationUpdateProfileStepTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoke::AutomationUpdateProfileStep
        {
            Action = Invoke::AutomationUpdateProfileStepAction.UpdateProfile,
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Merge = Invoke::Merge.None,
            RecipientID = "recipient_id",
        };

        ApiEnum<string, Invoke::AutomationUpdateProfileStepAction> expectedAction =
            Invoke::AutomationUpdateProfileStepAction.UpdateProfile;
        Dictionary<string, JsonElement> expectedProfile = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, Invoke::Merge> expectedMerge = Invoke::Merge.None;
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
        var model = new Invoke::AutomationUpdateProfileStep
        {
            Action = Invoke::AutomationUpdateProfileStepAction.UpdateProfile,
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Merge = Invoke::Merge.None,
            RecipientID = "recipient_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::AutomationUpdateProfileStep>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoke::AutomationUpdateProfileStep
        {
            Action = Invoke::AutomationUpdateProfileStepAction.UpdateProfile,
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Merge = Invoke::Merge.None,
            RecipientID = "recipient_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::AutomationUpdateProfileStep>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Invoke::AutomationUpdateProfileStepAction> expectedAction =
            Invoke::AutomationUpdateProfileStepAction.UpdateProfile;
        Dictionary<string, JsonElement> expectedProfile = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, Invoke::Merge> expectedMerge = Invoke::Merge.None;
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
        var model = new Invoke::AutomationUpdateProfileStep
        {
            Action = Invoke::AutomationUpdateProfileStepAction.UpdateProfile,
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Merge = Invoke::Merge.None,
            RecipientID = "recipient_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Invoke::AutomationUpdateProfileStep
        {
            Action = Invoke::AutomationUpdateProfileStepAction.UpdateProfile,
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
        var model = new Invoke::AutomationUpdateProfileStep
        {
            Action = Invoke::AutomationUpdateProfileStepAction.UpdateProfile,
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
        var model = new Invoke::AutomationUpdateProfileStep
        {
            Action = Invoke::AutomationUpdateProfileStepAction.UpdateProfile,
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
        var model = new Invoke::AutomationUpdateProfileStep
        {
            Action = Invoke::AutomationUpdateProfileStepAction.UpdateProfile,
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            Merge = null,
            RecipientID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoke::AutomationUpdateProfileStep
        {
            Action = Invoke::AutomationUpdateProfileStepAction.UpdateProfile,
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Merge = Invoke::Merge.None,
            RecipientID = "recipient_id",
        };

        Invoke::AutomationUpdateProfileStep copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AutomationUpdateProfileStepActionTest : TestBase
{
    [Theory]
    [InlineData(Invoke::AutomationUpdateProfileStepAction.UpdateProfile)]
    public void Validation_Works(Invoke::AutomationUpdateProfileStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoke::AutomationUpdateProfileStepAction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Invoke::AutomationUpdateProfileStepAction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoke::AutomationUpdateProfileStepAction.UpdateProfile)]
    public void SerializationRoundtrip_Works(Invoke::AutomationUpdateProfileStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoke::AutomationUpdateProfileStepAction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Invoke::AutomationUpdateProfileStepAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Invoke::AutomationUpdateProfileStepAction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Invoke::AutomationUpdateProfileStepAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MergeTest : TestBase
{
    [Theory]
    [InlineData(Invoke::Merge.None)]
    [InlineData(Invoke::Merge.Overwrite)]
    [InlineData(Invoke::Merge.SoftMerge)]
    [InlineData(Invoke::Merge.Replace)]
    public void Validation_Works(Invoke::Merge rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoke::Merge> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoke::Merge>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoke::Merge.None)]
    [InlineData(Invoke::Merge.Overwrite)]
    [InlineData(Invoke::Merge.SoftMerge)]
    [InlineData(Invoke::Merge.Replace)]
    public void SerializationRoundtrip_Works(Invoke::Merge rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoke::Merge> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoke::Merge>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoke::Merge>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoke::Merge>>(
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
        var model = new Invoke::AutomationCancelStep
        {
            Action = Invoke::AutomationCancelStepAction.Cancel,
            CancelationToken = "cancelation_token",
        };

        ApiEnum<string, Invoke::AutomationCancelStepAction> expectedAction =
            Invoke::AutomationCancelStepAction.Cancel;
        string expectedCancelationToken = "cancelation_token";

        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedCancelationToken, model.CancelationToken);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invoke::AutomationCancelStep
        {
            Action = Invoke::AutomationCancelStepAction.Cancel,
            CancelationToken = "cancelation_token",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::AutomationCancelStep>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoke::AutomationCancelStep
        {
            Action = Invoke::AutomationCancelStepAction.Cancel,
            CancelationToken = "cancelation_token",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::AutomationCancelStep>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Invoke::AutomationCancelStepAction> expectedAction =
            Invoke::AutomationCancelStepAction.Cancel;
        string expectedCancelationToken = "cancelation_token";

        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedCancelationToken, deserialized.CancelationToken);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invoke::AutomationCancelStep
        {
            Action = Invoke::AutomationCancelStepAction.Cancel,
            CancelationToken = "cancelation_token",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoke::AutomationCancelStep
        {
            Action = Invoke::AutomationCancelStepAction.Cancel,
            CancelationToken = "cancelation_token",
        };

        Invoke::AutomationCancelStep copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AutomationCancelStepActionTest : TestBase
{
    [Theory]
    [InlineData(Invoke::AutomationCancelStepAction.Cancel)]
    public void Validation_Works(Invoke::AutomationCancelStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoke::AutomationCancelStepAction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoke::AutomationCancelStepAction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoke::AutomationCancelStepAction.Cancel)]
    public void SerializationRoundtrip_Works(Invoke::AutomationCancelStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoke::AutomationCancelStepAction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Invoke::AutomationCancelStepAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoke::AutomationCancelStepAction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Invoke::AutomationCancelStepAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AutomationFetchDataStepTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoke::AutomationFetchDataStep
        {
            Action = Invoke::AutomationFetchDataStepAction.FetchData,
            Webhook = new()
            {
                Method = Invoke::Method.Get,
                Url = "url",
                Body = "body",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
            MergeStrategy = Invoke::MergeStrategy.Replace,
        };

        ApiEnum<string, Invoke::AutomationFetchDataStepAction> expectedAction =
            Invoke::AutomationFetchDataStepAction.FetchData;
        Invoke::Webhook expectedWebhook = new()
        {
            Method = Invoke::Method.Get,
            Url = "url",
            Body = "body",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };
        ApiEnum<string, Invoke::MergeStrategy> expectedMergeStrategy =
            Invoke::MergeStrategy.Replace;

        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedWebhook, model.Webhook);
        Assert.Equal(expectedMergeStrategy, model.MergeStrategy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invoke::AutomationFetchDataStep
        {
            Action = Invoke::AutomationFetchDataStepAction.FetchData,
            Webhook = new()
            {
                Method = Invoke::Method.Get,
                Url = "url",
                Body = "body",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
            MergeStrategy = Invoke::MergeStrategy.Replace,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::AutomationFetchDataStep>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoke::AutomationFetchDataStep
        {
            Action = Invoke::AutomationFetchDataStepAction.FetchData,
            Webhook = new()
            {
                Method = Invoke::Method.Get,
                Url = "url",
                Body = "body",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
            MergeStrategy = Invoke::MergeStrategy.Replace,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::AutomationFetchDataStep>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Invoke::AutomationFetchDataStepAction> expectedAction =
            Invoke::AutomationFetchDataStepAction.FetchData;
        Invoke::Webhook expectedWebhook = new()
        {
            Method = Invoke::Method.Get,
            Url = "url",
            Body = "body",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };
        ApiEnum<string, Invoke::MergeStrategy> expectedMergeStrategy =
            Invoke::MergeStrategy.Replace;

        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedWebhook, deserialized.Webhook);
        Assert.Equal(expectedMergeStrategy, deserialized.MergeStrategy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invoke::AutomationFetchDataStep
        {
            Action = Invoke::AutomationFetchDataStepAction.FetchData,
            Webhook = new()
            {
                Method = Invoke::Method.Get,
                Url = "url",
                Body = "body",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
            MergeStrategy = Invoke::MergeStrategy.Replace,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Invoke::AutomationFetchDataStep
        {
            Action = Invoke::AutomationFetchDataStepAction.FetchData,
            Webhook = new()
            {
                Method = Invoke::Method.Get,
                Url = "url",
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
        var model = new Invoke::AutomationFetchDataStep
        {
            Action = Invoke::AutomationFetchDataStepAction.FetchData,
            Webhook = new()
            {
                Method = Invoke::Method.Get,
                Url = "url",
                Body = "body",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Invoke::AutomationFetchDataStep
        {
            Action = Invoke::AutomationFetchDataStepAction.FetchData,
            Webhook = new()
            {
                Method = Invoke::Method.Get,
                Url = "url",
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
        var model = new Invoke::AutomationFetchDataStep
        {
            Action = Invoke::AutomationFetchDataStepAction.FetchData,
            Webhook = new()
            {
                Method = Invoke::Method.Get,
                Url = "url",
                Body = "body",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },

            MergeStrategy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoke::AutomationFetchDataStep
        {
            Action = Invoke::AutomationFetchDataStepAction.FetchData,
            Webhook = new()
            {
                Method = Invoke::Method.Get,
                Url = "url",
                Body = "body",
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
            },
            MergeStrategy = Invoke::MergeStrategy.Replace,
        };

        Invoke::AutomationFetchDataStep copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AutomationFetchDataStepActionTest : TestBase
{
    [Theory]
    [InlineData(Invoke::AutomationFetchDataStepAction.FetchData)]
    public void Validation_Works(Invoke::AutomationFetchDataStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoke::AutomationFetchDataStepAction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Invoke::AutomationFetchDataStepAction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoke::AutomationFetchDataStepAction.FetchData)]
    public void SerializationRoundtrip_Works(Invoke::AutomationFetchDataStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoke::AutomationFetchDataStepAction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Invoke::AutomationFetchDataStepAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Invoke::AutomationFetchDataStepAction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Invoke::AutomationFetchDataStepAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class WebhookTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoke::Webhook
        {
            Method = Invoke::Method.Get,
            Url = "url",
            Body = "body",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        ApiEnum<string, Invoke::Method> expectedMethod = Invoke::Method.Get;
        string expectedUrl = "url";
        string expectedBody = "body";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };

        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedBody, model.Body);
        Assert.NotNull(model.Headers);
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
        var model = new Invoke::Webhook
        {
            Method = Invoke::Method.Get,
            Url = "url",
            Body = "body",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::Webhook>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoke::Webhook
        {
            Method = Invoke::Method.Get,
            Url = "url",
            Body = "body",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::Webhook>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Invoke::Method> expectedMethod = Invoke::Method.Get;
        string expectedUrl = "url";
        string expectedBody = "body";
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };

        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedBody, deserialized.Body);
        Assert.NotNull(deserialized.Headers);
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
        var model = new Invoke::Webhook
        {
            Method = Invoke::Method.Get,
            Url = "url",
            Body = "body",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Invoke::Webhook { Method = Invoke::Method.Get, Url = "url" };

        Assert.Null(model.Body);
        Assert.False(model.RawData.ContainsKey("body"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Invoke::Webhook { Method = Invoke::Method.Get, Url = "url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Invoke::Webhook
        {
            Method = Invoke::Method.Get,
            Url = "url",

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
        var model = new Invoke::Webhook
        {
            Method = Invoke::Method.Get,
            Url = "url",

            Body = null,
            Headers = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoke::Webhook
        {
            Method = Invoke::Method.Get,
            Url = "url",
            Body = "body",
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Invoke::Webhook copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MethodTest : TestBase
{
    [Theory]
    [InlineData(Invoke::Method.Get)]
    [InlineData(Invoke::Method.Post)]
    [InlineData(Invoke::Method.Put)]
    [InlineData(Invoke::Method.Patch)]
    [InlineData(Invoke::Method.Delete)]
    public void Validation_Works(Invoke::Method rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoke::Method> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoke::Method>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoke::Method.Get)]
    [InlineData(Invoke::Method.Post)]
    [InlineData(Invoke::Method.Put)]
    [InlineData(Invoke::Method.Patch)]
    [InlineData(Invoke::Method.Delete)]
    public void SerializationRoundtrip_Works(Invoke::Method rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoke::Method> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoke::Method>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoke::Method>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoke::Method>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MergeStrategyTest : TestBase
{
    [Theory]
    [InlineData(Invoke::MergeStrategy.Replace)]
    [InlineData(Invoke::MergeStrategy.Overwrite)]
    [InlineData(Invoke::MergeStrategy.SoftMerge)]
    public void Validation_Works(Invoke::MergeStrategy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoke::MergeStrategy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoke::MergeStrategy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoke::MergeStrategy.Replace)]
    [InlineData(Invoke::MergeStrategy.Overwrite)]
    [InlineData(Invoke::MergeStrategy.SoftMerge)]
    public void SerializationRoundtrip_Works(Invoke::MergeStrategy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoke::MergeStrategy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoke::MergeStrategy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoke::MergeStrategy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoke::MergeStrategy>>(
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
        var model = new Invoke::AutomationInvokeStep
        {
            Action = Invoke::AutomationInvokeStepAction.Invoke,
            Template = "template",
        };

        ApiEnum<string, Invoke::AutomationInvokeStepAction> expectedAction =
            Invoke::AutomationInvokeStepAction.Invoke;
        string expectedTemplate = "template";

        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedTemplate, model.Template);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invoke::AutomationInvokeStep
        {
            Action = Invoke::AutomationInvokeStepAction.Invoke,
            Template = "template",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::AutomationInvokeStep>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoke::AutomationInvokeStep
        {
            Action = Invoke::AutomationInvokeStepAction.Invoke,
            Template = "template",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoke::AutomationInvokeStep>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Invoke::AutomationInvokeStepAction> expectedAction =
            Invoke::AutomationInvokeStepAction.Invoke;
        string expectedTemplate = "template";

        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedTemplate, deserialized.Template);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invoke::AutomationInvokeStep
        {
            Action = Invoke::AutomationInvokeStepAction.Invoke,
            Template = "template",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoke::AutomationInvokeStep
        {
            Action = Invoke::AutomationInvokeStepAction.Invoke,
            Template = "template",
        };

        Invoke::AutomationInvokeStep copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AutomationInvokeStepActionTest : TestBase
{
    [Theory]
    [InlineData(Invoke::AutomationInvokeStepAction.Invoke)]
    public void Validation_Works(Invoke::AutomationInvokeStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoke::AutomationInvokeStepAction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoke::AutomationInvokeStepAction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoke::AutomationInvokeStepAction.Invoke)]
    public void SerializationRoundtrip_Works(Invoke::AutomationInvokeStepAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoke::AutomationInvokeStepAction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Invoke::AutomationInvokeStepAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoke::AutomationInvokeStepAction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Invoke::AutomationInvokeStepAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
