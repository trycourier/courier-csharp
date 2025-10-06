using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties;
using StepVariants = Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepVariants;

namespace Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties;

[JsonConverter(typeof(StepConverter))]
public abstract record class Step
{
    internal Step() { }

    public static implicit operator Step(AutomationDelayStep value) =>
        new StepVariants::AutomationDelayStep(value);

    public static implicit operator Step(AutomationSendStep value) =>
        new StepVariants::AutomationSendStep(value);

    public static implicit operator Step(AutomationSendListStep value) =>
        new StepVariants::AutomationSendListStep(value);

    public static implicit operator Step(AutomationUpdateProfileStep value) =>
        new StepVariants::AutomationUpdateProfileStep(value);

    public static implicit operator Step(AutomationCancelStep value) =>
        new StepVariants::AutomationCancelStep(value);

    public static implicit operator Step(AutomationFetchDataStep value) =>
        new StepVariants::AutomationFetchDataStep(value);

    public static implicit operator Step(AutomationInvokeStep value) =>
        new StepVariants::AutomationInvokeStep(value);

    public bool TryPickAutomationDelay([NotNullWhen(true)] out AutomationDelayStep? value)
    {
        value = (this as StepVariants::AutomationDelayStep)?.Value;
        return value != null;
    }

    public bool TryPickAutomationSend([NotNullWhen(true)] out AutomationSendStep? value)
    {
        value = (this as StepVariants::AutomationSendStep)?.Value;
        return value != null;
    }

    public bool TryPickAutomationSendList([NotNullWhen(true)] out AutomationSendListStep? value)
    {
        value = (this as StepVariants::AutomationSendListStep)?.Value;
        return value != null;
    }

    public bool TryPickAutomationUpdateProfile(
        [NotNullWhen(true)] out AutomationUpdateProfileStep? value
    )
    {
        value = (this as StepVariants::AutomationUpdateProfileStep)?.Value;
        return value != null;
    }

    public bool TryPickAutomationCancel([NotNullWhen(true)] out AutomationCancelStep? value)
    {
        value = (this as StepVariants::AutomationCancelStep)?.Value;
        return value != null;
    }

    public bool TryPickAutomationFetchData([NotNullWhen(true)] out AutomationFetchDataStep? value)
    {
        value = (this as StepVariants::AutomationFetchDataStep)?.Value;
        return value != null;
    }

    public bool TryPickAutomationInvoke([NotNullWhen(true)] out AutomationInvokeStep? value)
    {
        value = (this as StepVariants::AutomationInvokeStep)?.Value;
        return value != null;
    }

    public void Switch(
        Action<StepVariants::AutomationDelayStep> automationDelay,
        Action<StepVariants::AutomationSendStep> automationSend,
        Action<StepVariants::AutomationSendListStep> automationSendList,
        Action<StepVariants::AutomationUpdateProfileStep> automationUpdateProfile,
        Action<StepVariants::AutomationCancelStep> automationCancel,
        Action<StepVariants::AutomationFetchDataStep> automationFetchData,
        Action<StepVariants::AutomationInvokeStep> automationInvoke
    )
    {
        switch (this)
        {
            case StepVariants::AutomationDelayStep inner:
                automationDelay(inner);
                break;
            case StepVariants::AutomationSendStep inner:
                automationSend(inner);
                break;
            case StepVariants::AutomationSendListStep inner:
                automationSendList(inner);
                break;
            case StepVariants::AutomationUpdateProfileStep inner:
                automationUpdateProfile(inner);
                break;
            case StepVariants::AutomationCancelStep inner:
                automationCancel(inner);
                break;
            case StepVariants::AutomationFetchDataStep inner:
                automationFetchData(inner);
                break;
            case StepVariants::AutomationInvokeStep inner:
                automationInvoke(inner);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of Step");
        }
    }

    public T Match<T>(
        Func<StepVariants::AutomationDelayStep, T> automationDelay,
        Func<StepVariants::AutomationSendStep, T> automationSend,
        Func<StepVariants::AutomationSendListStep, T> automationSendList,
        Func<StepVariants::AutomationUpdateProfileStep, T> automationUpdateProfile,
        Func<StepVariants::AutomationCancelStep, T> automationCancel,
        Func<StepVariants::AutomationFetchDataStep, T> automationFetchData,
        Func<StepVariants::AutomationInvokeStep, T> automationInvoke
    )
    {
        return this switch
        {
            StepVariants::AutomationDelayStep inner => automationDelay(inner),
            StepVariants::AutomationSendStep inner => automationSend(inner),
            StepVariants::AutomationSendListStep inner => automationSendList(inner),
            StepVariants::AutomationUpdateProfileStep inner => automationUpdateProfile(inner),
            StepVariants::AutomationCancelStep inner => automationCancel(inner),
            StepVariants::AutomationFetchDataStep inner => automationFetchData(inner),
            StepVariants::AutomationInvokeStep inner => automationInvoke(inner),
            _ => throw new CourierInvalidDataException("Data did not match any variant of Step"),
        };
    }

    public abstract void Validate();
}

sealed class StepConverter : JsonConverter<Step>
{
    public override Step? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<CourierInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationDelayStep>(ref reader, options);
            if (deserialized != null)
            {
                return new StepVariants::AutomationDelayStep(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant StepVariants::AutomationDelayStep",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationSendStep>(ref reader, options);
            if (deserialized != null)
            {
                return new StepVariants::AutomationSendStep(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant StepVariants::AutomationSendStep",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationSendListStep>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new StepVariants::AutomationSendListStep(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant StepVariants::AutomationSendListStep",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationUpdateProfileStep>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new StepVariants::AutomationUpdateProfileStep(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant StepVariants::AutomationUpdateProfileStep",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationCancelStep>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new StepVariants::AutomationCancelStep(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant StepVariants::AutomationCancelStep",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationFetchDataStep>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new StepVariants::AutomationFetchDataStep(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant StepVariants::AutomationFetchDataStep",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationInvokeStep>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new StepVariants::AutomationInvokeStep(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant StepVariants::AutomationInvokeStep",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Step value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            StepVariants::AutomationDelayStep(var automationDelay) => automationDelay,
            StepVariants::AutomationSendStep(var automationSend) => automationSend,
            StepVariants::AutomationSendListStep(var automationSendList) => automationSendList,
            StepVariants::AutomationUpdateProfileStep(var automationUpdateProfile) =>
                automationUpdateProfile,
            StepVariants::AutomationCancelStep(var automationCancel) => automationCancel,
            StepVariants::AutomationFetchDataStep(var automationFetchData) => automationFetchData,
            StepVariants::AutomationInvokeStep(var automationInvoke) => automationInvoke,
            _ => throw new CourierInvalidDataException("Data did not match any variant of Step"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
