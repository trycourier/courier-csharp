using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties;
using StepVariants = Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepVariants;

namespace Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties;

[JsonConverter(typeof(StepConverter))]
public abstract record class Step
{
    internal Step() { }

    public static implicit operator Step(AutomationAddToDigestStep value) =>
        new StepVariants::AutomationAddToDigestStep(value);

    public static implicit operator Step(AutomationAddToBatchStep value) =>
        new StepVariants::AutomationAddToBatchStep(value);

    public static implicit operator Step(AutomationThrottleStep value) =>
        new StepVariants::AutomationThrottleStep(value);

    public static implicit operator Step(AutomationCancelStep value) =>
        new StepVariants::AutomationCancelStep(value);

    public static implicit operator Step(AutomationDelayStep value) =>
        new StepVariants::AutomationDelayStep(value);

    public static implicit operator Step(AutomationFetchDataStep value) =>
        new StepVariants::AutomationFetchDataStep(value);

    public static implicit operator Step(AutomationInvokeStep value) =>
        new StepVariants::AutomationInvokeStep(value);

    public static implicit operator Step(AutomationSendStep value) =>
        new StepVariants::AutomationSendStep(value);

    public static implicit operator Step(AutomationV2SendStep value) =>
        new StepVariants::AutomationV2SendStep(value);

    public static implicit operator Step(AutomationSendListStep value) =>
        new StepVariants::AutomationSendListStep(value);

    public static implicit operator Step(AutomationUpdateProfileStep value) =>
        new StepVariants::AutomationUpdateProfileStep(value);

    public bool TryPickAutomationAddToDigest(
        [NotNullWhen(true)] out AutomationAddToDigestStep? value
    )
    {
        value = (this as StepVariants::AutomationAddToDigestStep)?.Value;
        return value != null;
    }

    public bool TryPickAutomationAddToBatch([NotNullWhen(true)] out AutomationAddToBatchStep? value)
    {
        value = (this as StepVariants::AutomationAddToBatchStep)?.Value;
        return value != null;
    }

    public bool TryPickAutomationThrottle([NotNullWhen(true)] out AutomationThrottleStep? value)
    {
        value = (this as StepVariants::AutomationThrottleStep)?.Value;
        return value != null;
    }

    public bool TryPickAutomationCancel([NotNullWhen(true)] out AutomationCancelStep? value)
    {
        value = (this as StepVariants::AutomationCancelStep)?.Value;
        return value != null;
    }

    public bool TryPickAutomationDelay([NotNullWhen(true)] out AutomationDelayStep? value)
    {
        value = (this as StepVariants::AutomationDelayStep)?.Value;
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

    public bool TryPickAutomationSend([NotNullWhen(true)] out AutomationSendStep? value)
    {
        value = (this as StepVariants::AutomationSendStep)?.Value;
        return value != null;
    }

    public bool TryPickAutomationV2Send([NotNullWhen(true)] out AutomationV2SendStep? value)
    {
        value = (this as StepVariants::AutomationV2SendStep)?.Value;
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

    public void Switch(
        Action<StepVariants::AutomationAddToDigestStep> automationAddToDigest,
        Action<StepVariants::AutomationAddToBatchStep> automationAddToBatch,
        Action<StepVariants::AutomationThrottleStep> automationThrottle,
        Action<StepVariants::AutomationCancelStep> automationCancel,
        Action<StepVariants::AutomationDelayStep> automationDelay,
        Action<StepVariants::AutomationFetchDataStep> automationFetchData,
        Action<StepVariants::AutomationInvokeStep> automationInvoke,
        Action<StepVariants::AutomationSendStep> automationSend,
        Action<StepVariants::AutomationV2SendStep> automationV2Send,
        Action<StepVariants::AutomationSendListStep> automationSendList,
        Action<StepVariants::AutomationUpdateProfileStep> automationUpdateProfile
    )
    {
        switch (this)
        {
            case StepVariants::AutomationAddToDigestStep inner:
                automationAddToDigest(inner);
                break;
            case StepVariants::AutomationAddToBatchStep inner:
                automationAddToBatch(inner);
                break;
            case StepVariants::AutomationThrottleStep inner:
                automationThrottle(inner);
                break;
            case StepVariants::AutomationCancelStep inner:
                automationCancel(inner);
                break;
            case StepVariants::AutomationDelayStep inner:
                automationDelay(inner);
                break;
            case StepVariants::AutomationFetchDataStep inner:
                automationFetchData(inner);
                break;
            case StepVariants::AutomationInvokeStep inner:
                automationInvoke(inner);
                break;
            case StepVariants::AutomationSendStep inner:
                automationSend(inner);
                break;
            case StepVariants::AutomationV2SendStep inner:
                automationV2Send(inner);
                break;
            case StepVariants::AutomationSendListStep inner:
                automationSendList(inner);
                break;
            case StepVariants::AutomationUpdateProfileStep inner:
                automationUpdateProfile(inner);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of Step");
        }
    }

    public T Match<T>(
        Func<StepVariants::AutomationAddToDigestStep, T> automationAddToDigest,
        Func<StepVariants::AutomationAddToBatchStep, T> automationAddToBatch,
        Func<StepVariants::AutomationThrottleStep, T> automationThrottle,
        Func<StepVariants::AutomationCancelStep, T> automationCancel,
        Func<StepVariants::AutomationDelayStep, T> automationDelay,
        Func<StepVariants::AutomationFetchDataStep, T> automationFetchData,
        Func<StepVariants::AutomationInvokeStep, T> automationInvoke,
        Func<StepVariants::AutomationSendStep, T> automationSend,
        Func<StepVariants::AutomationV2SendStep, T> automationV2Send,
        Func<StepVariants::AutomationSendListStep, T> automationSendList,
        Func<StepVariants::AutomationUpdateProfileStep, T> automationUpdateProfile
    )
    {
        return this switch
        {
            StepVariants::AutomationAddToDigestStep inner => automationAddToDigest(inner),
            StepVariants::AutomationAddToBatchStep inner => automationAddToBatch(inner),
            StepVariants::AutomationThrottleStep inner => automationThrottle(inner),
            StepVariants::AutomationCancelStep inner => automationCancel(inner),
            StepVariants::AutomationDelayStep inner => automationDelay(inner),
            StepVariants::AutomationFetchDataStep inner => automationFetchData(inner),
            StepVariants::AutomationInvokeStep inner => automationInvoke(inner),
            StepVariants::AutomationSendStep inner => automationSend(inner),
            StepVariants::AutomationV2SendStep inner => automationV2Send(inner),
            StepVariants::AutomationSendListStep inner => automationSendList(inner),
            StepVariants::AutomationUpdateProfileStep inner => automationUpdateProfile(inner),
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
            var deserialized = JsonSerializer.Deserialize<AutomationAddToDigestStep>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new StepVariants::AutomationAddToDigestStep(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant StepVariants::AutomationAddToDigestStep",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationAddToBatchStep>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new StepVariants::AutomationAddToBatchStep(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant StepVariants::AutomationAddToBatchStep",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationThrottleStep>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new StepVariants::AutomationThrottleStep(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant StepVariants::AutomationThrottleStep",
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
            var deserialized = JsonSerializer.Deserialize<AutomationV2SendStep>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new StepVariants::AutomationV2SendStep(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant StepVariants::AutomationV2SendStep",
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

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Step value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            StepVariants::AutomationAddToDigestStep(var automationAddToDigest) =>
                automationAddToDigest,
            StepVariants::AutomationAddToBatchStep(var automationAddToBatch) =>
                automationAddToBatch,
            StepVariants::AutomationThrottleStep(var automationThrottle) => automationThrottle,
            StepVariants::AutomationCancelStep(var automationCancel) => automationCancel,
            StepVariants::AutomationDelayStep(var automationDelay) => automationDelay,
            StepVariants::AutomationFetchDataStep(var automationFetchData) => automationFetchData,
            StepVariants::AutomationInvokeStep(var automationInvoke) => automationInvoke,
            StepVariants::AutomationSendStep(var automationSend) => automationSend,
            StepVariants::AutomationV2SendStep(var automationV2Send) => automationV2Send,
            StepVariants::AutomationSendListStep(var automationSendList) => automationSendList,
            StepVariants::AutomationUpdateProfileStep(var automationUpdateProfile) =>
                automationUpdateProfile,
            _ => throw new CourierInvalidDataException("Data did not match any variant of Step"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
