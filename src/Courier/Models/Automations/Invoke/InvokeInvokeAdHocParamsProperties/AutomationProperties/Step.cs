using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties;

namespace Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties;

[JsonConverter(typeof(StepConverter))]
public record class Step
{
    public object Value { get; private init; }

    public string? Brand
    {
        get
        {
            return Match<string?>(
                automationDelay: (_) => null,
                automationSend: (x) => x.Brand,
                automationSendList: (x) => x.Brand,
                automationUpdateProfile: (_) => null,
                automationCancel: (_) => null,
                automationFetchData: (_) => null,
                automationInvoke: (_) => null
            );
        }
    }

    public string? Template
    {
        get
        {
            return Match<string?>(
                automationDelay: (_) => null,
                automationSend: (x) => x.Template,
                automationSendList: (_) => null,
                automationUpdateProfile: (_) => null,
                automationCancel: (_) => null,
                automationFetchData: (_) => null,
                automationInvoke: (x) => x.Template
            );
        }
    }

    public Step(AutomationDelayStep value)
    {
        Value = value;
    }

    public Step(AutomationSendStep value)
    {
        Value = value;
    }

    public Step(AutomationSendListStep value)
    {
        Value = value;
    }

    public Step(AutomationUpdateProfileStep value)
    {
        Value = value;
    }

    public Step(AutomationCancelStep value)
    {
        Value = value;
    }

    public Step(AutomationFetchDataStep value)
    {
        Value = value;
    }

    public Step(AutomationInvokeStep value)
    {
        Value = value;
    }

    Step(UnknownVariant value)
    {
        Value = value;
    }

    public static Step CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickAutomationDelay([NotNullWhen(true)] out AutomationDelayStep? value)
    {
        value = this.Value as AutomationDelayStep;
        return value != null;
    }

    public bool TryPickAutomationSend([NotNullWhen(true)] out AutomationSendStep? value)
    {
        value = this.Value as AutomationSendStep;
        return value != null;
    }

    public bool TryPickAutomationSendList([NotNullWhen(true)] out AutomationSendListStep? value)
    {
        value = this.Value as AutomationSendListStep;
        return value != null;
    }

    public bool TryPickAutomationUpdateProfile(
        [NotNullWhen(true)] out AutomationUpdateProfileStep? value
    )
    {
        value = this.Value as AutomationUpdateProfileStep;
        return value != null;
    }

    public bool TryPickAutomationCancel([NotNullWhen(true)] out AutomationCancelStep? value)
    {
        value = this.Value as AutomationCancelStep;
        return value != null;
    }

    public bool TryPickAutomationFetchData([NotNullWhen(true)] out AutomationFetchDataStep? value)
    {
        value = this.Value as AutomationFetchDataStep;
        return value != null;
    }

    public bool TryPickAutomationInvoke([NotNullWhen(true)] out AutomationInvokeStep? value)
    {
        value = this.Value as AutomationInvokeStep;
        return value != null;
    }

    public void Switch(
        Action<AutomationDelayStep> automationDelay,
        Action<AutomationSendStep> automationSend,
        Action<AutomationSendListStep> automationSendList,
        Action<AutomationUpdateProfileStep> automationUpdateProfile,
        Action<AutomationCancelStep> automationCancel,
        Action<AutomationFetchDataStep> automationFetchData,
        Action<AutomationInvokeStep> automationInvoke
    )
    {
        switch (this.Value)
        {
            case AutomationDelayStep value:
                automationDelay(value);
                break;
            case AutomationSendStep value:
                automationSend(value);
                break;
            case AutomationSendListStep value:
                automationSendList(value);
                break;
            case AutomationUpdateProfileStep value:
                automationUpdateProfile(value);
                break;
            case AutomationCancelStep value:
                automationCancel(value);
                break;
            case AutomationFetchDataStep value:
                automationFetchData(value);
                break;
            case AutomationInvokeStep value:
                automationInvoke(value);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of Step");
        }
    }

    public T Match<T>(
        Func<AutomationDelayStep, T> automationDelay,
        Func<AutomationSendStep, T> automationSend,
        Func<AutomationSendListStep, T> automationSendList,
        Func<AutomationUpdateProfileStep, T> automationUpdateProfile,
        Func<AutomationCancelStep, T> automationCancel,
        Func<AutomationFetchDataStep, T> automationFetchData,
        Func<AutomationInvokeStep, T> automationInvoke
    )
    {
        return this.Value switch
        {
            AutomationDelayStep value => automationDelay(value),
            AutomationSendStep value => automationSend(value),
            AutomationSendListStep value => automationSendList(value),
            AutomationUpdateProfileStep value => automationUpdateProfile(value),
            AutomationCancelStep value => automationCancel(value),
            AutomationFetchDataStep value => automationFetchData(value),
            AutomationInvokeStep value => automationInvoke(value),
            _ => throw new CourierInvalidDataException("Data did not match any variant of Step"),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new CourierInvalidDataException("Data did not match any variant of Step");
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
                deserialized.Validate();
                return new Step(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'AutomationDelayStep'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationSendStep>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Step(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'AutomationSendStep'",
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
                deserialized.Validate();
                return new Step(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'AutomationSendListStep'",
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
                deserialized.Validate();
                return new Step(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'AutomationUpdateProfileStep'",
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
                deserialized.Validate();
                return new Step(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'AutomationCancelStep'",
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
                deserialized.Validate();
                return new Step(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'AutomationFetchDataStep'",
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
                deserialized.Validate();
                return new Step(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'AutomationInvokeStep'",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Step value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
