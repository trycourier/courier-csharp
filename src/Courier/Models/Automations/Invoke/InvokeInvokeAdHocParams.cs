using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Automations.Invoke;

/// <summary>
/// Invoke an ad hoc automation run. This endpoint accepts a JSON payload with a series
/// of automation steps. For information about what steps are available, checkout
/// the ad hoc automation guide [here](https://www.courier.com/docs/automations/steps/).
/// </summary>
public sealed record class InvokeInvokeAdHocParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    public required Automation Automation
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("automation", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'automation' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "automation",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<Automation>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'automation' cannot be null",
                    new System::ArgumentNullException("automation")
                );
        }
        init
        {
            this._bodyProperties["automation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Brand
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("brand", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["brand"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, JsonElement>? Data
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, JsonElement>? Profile
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("profile", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["profile"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Recipient
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("recipient", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["recipient"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Template
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("template", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["template"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public InvokeInvokeAdHocParams() { }

    public InvokeInvokeAdHocParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvokeInvokeAdHocParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static InvokeInvokeAdHocParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override System::Uri Url(ICourierClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + "/automations/invoke"
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ICourierClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(ModelConverter<Automation>))]
public sealed record class Automation : ModelBase, IFromRaw<Automation>
{
    public required List<Step> Steps
    {
        get
        {
            if (!this._properties.TryGetValue("steps", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'steps' cannot be null",
                    new System::ArgumentOutOfRangeException("steps", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Step>>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'steps' cannot be null",
                    new System::ArgumentNullException("steps")
                );
        }
        init
        {
            this._properties["steps"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? CancelationToken
    {
        get
        {
            if (!this._properties.TryGetValue("cancelation_token", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cancelation_token"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Steps)
        {
            item.Validate();
        }
        _ = this.CancelationToken;
    }

    public Automation() { }

    public Automation(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Automation(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Automation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public Automation(List<Step> steps)
        : this()
    {
        this.Steps = steps;
    }
}

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
        System::Action<AutomationDelayStep> automationDelay,
        System::Action<AutomationSendStep> automationSend,
        System::Action<AutomationSendListStep> automationSendList,
        System::Action<AutomationUpdateProfileStep> automationUpdateProfile,
        System::Action<AutomationCancelStep> automationCancel,
        System::Action<AutomationFetchDataStep> automationFetchData,
        System::Action<AutomationInvokeStep> automationInvoke
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
        System::Func<AutomationDelayStep, T> automationDelay,
        System::Func<AutomationSendStep, T> automationSend,
        System::Func<AutomationSendListStep, T> automationSendList,
        System::Func<AutomationUpdateProfileStep, T> automationUpdateProfile,
        System::Func<AutomationCancelStep, T> automationCancel,
        System::Func<AutomationFetchDataStep, T> automationFetchData,
        System::Func<AutomationInvokeStep, T> automationInvoke
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
        if (this.Value is UnknownVariant)
        {
            throw new CourierInvalidDataException("Data did not match any variant of Step");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class StepConverter : JsonConverter<Step>
{
    public override Step? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'AutomationInvokeStep'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Step value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<AutomationDelayStep>))]
public sealed record class AutomationDelayStep : ModelBase, IFromRaw<AutomationDelayStep>
{
    public required ApiEnum<string, Action> Action
    {
        get
        {
            if (!this._properties.TryGetValue("action", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'action' cannot be null",
                    new System::ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Action>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["action"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Duration
    {
        get
        {
            if (!this._properties.TryGetValue("duration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Until
    {
        get
        {
            if (!this._properties.TryGetValue("until", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["until"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Action.Validate();
        _ = this.Duration;
        _ = this.Until;
    }

    public AutomationDelayStep() { }

    public AutomationDelayStep(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationDelayStep(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static AutomationDelayStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public AutomationDelayStep(ApiEnum<string, Action> action)
        : this()
    {
        this.Action = action;
    }
}

[JsonConverter(typeof(ActionConverter))]
public enum Action
{
    Delay,
}

sealed class ActionConverter : JsonConverter<Action>
{
    public override Action Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "delay" => Action.Delay,
            _ => (Action)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Action value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Action.Delay => "delay",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<AutomationSendStep>))]
public sealed record class AutomationSendStep : ModelBase, IFromRaw<AutomationSendStep>
{
    public required ApiEnum<string, ActionModel> Action
    {
        get
        {
            if (!this._properties.TryGetValue("action", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'action' cannot be null",
                    new System::ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ActionModel>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["action"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Brand
    {
        get
        {
            if (!this._properties.TryGetValue("brand", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["brand"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, JsonElement>? Data
    {
        get
        {
            if (!this._properties.TryGetValue("data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, JsonElement>? Profile
    {
        get
        {
            if (!this._properties.TryGetValue("profile", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["profile"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Recipient
    {
        get
        {
            if (!this._properties.TryGetValue("recipient", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["recipient"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Template
    {
        get
        {
            if (!this._properties.TryGetValue("template", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["template"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Action.Validate();
        _ = this.Brand;
        _ = this.Data;
        _ = this.Profile;
        _ = this.Recipient;
        _ = this.Template;
    }

    public AutomationSendStep() { }

    public AutomationSendStep(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationSendStep(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static AutomationSendStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public AutomationSendStep(ApiEnum<string, ActionModel> action)
        : this()
    {
        this.Action = action;
    }
}

[JsonConverter(typeof(ActionModelConverter))]
public enum ActionModel
{
    Send,
}

sealed class ActionModelConverter : JsonConverter<ActionModel>
{
    public override ActionModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "send" => ActionModel.Send,
            _ => (ActionModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ActionModel.Send => "send",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<AutomationSendListStep>))]
public sealed record class AutomationSendListStep : ModelBase, IFromRaw<AutomationSendListStep>
{
    public required ApiEnum<string, Action1> Action
    {
        get
        {
            if (!this._properties.TryGetValue("action", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'action' cannot be null",
                    new System::ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Action1>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["action"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string List
    {
        get
        {
            if (!this._properties.TryGetValue("list", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'list' cannot be null",
                    new System::ArgumentOutOfRangeException("list", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'list' cannot be null",
                    new System::ArgumentNullException("list")
                );
        }
        init
        {
            this._properties["list"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Brand
    {
        get
        {
            if (!this._properties.TryGetValue("brand", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["brand"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, JsonElement>? Data
    {
        get
        {
            if (!this._properties.TryGetValue("data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Action.Validate();
        _ = this.List;
        _ = this.Brand;
        _ = this.Data;
    }

    public AutomationSendListStep() { }

    public AutomationSendListStep(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationSendListStep(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static AutomationSendListStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(Action1Converter))]
public enum Action1
{
    SendList,
}

sealed class Action1Converter : JsonConverter<Action1>
{
    public override Action1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "send-list" => Action1.SendList,
            _ => (Action1)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Action1 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Action1.SendList => "send-list",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<AutomationUpdateProfileStep>))]
public sealed record class AutomationUpdateProfileStep
    : ModelBase,
        IFromRaw<AutomationUpdateProfileStep>
{
    public required ApiEnum<string, Action2> Action
    {
        get
        {
            if (!this._properties.TryGetValue("action", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'action' cannot be null",
                    new System::ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Action2>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["action"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Dictionary<string, JsonElement> Profile
    {
        get
        {
            if (!this._properties.TryGetValue("profile", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'profile' cannot be null",
                    new System::ArgumentOutOfRangeException("profile", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'profile' cannot be null",
                    new System::ArgumentNullException("profile")
                );
        }
        init
        {
            this._properties["profile"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, Merge>? Merge
    {
        get
        {
            if (!this._properties.TryGetValue("merge", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Merge>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["merge"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? RecipientID
    {
        get
        {
            if (!this._properties.TryGetValue("recipient_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["recipient_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Action.Validate();
        _ = this.Profile;
        this.Merge?.Validate();
        _ = this.RecipientID;
    }

    public AutomationUpdateProfileStep() { }

    public AutomationUpdateProfileStep(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationUpdateProfileStep(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static AutomationUpdateProfileStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(Action2Converter))]
public enum Action2
{
    UpdateProfile,
}

sealed class Action2Converter : JsonConverter<Action2>
{
    public override Action2 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "update-profile" => Action2.UpdateProfile,
            _ => (Action2)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Action2 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Action2.UpdateProfile => "update-profile",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(MergeConverter))]
public enum Merge
{
    None,
    Overwrite,
    SoftMerge,
    Replace,
}

sealed class MergeConverter : JsonConverter<Merge>
{
    public override Merge Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => Merge.None,
            "overwrite" => Merge.Overwrite,
            "soft-merge" => Merge.SoftMerge,
            "replace" => Merge.Replace,
            _ => (Merge)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Merge value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Merge.None => "none",
                Merge.Overwrite => "overwrite",
                Merge.SoftMerge => "soft-merge",
                Merge.Replace => "replace",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<AutomationCancelStep>))]
public sealed record class AutomationCancelStep : ModelBase, IFromRaw<AutomationCancelStep>
{
    public required ApiEnum<string, Action3> Action
    {
        get
        {
            if (!this._properties.TryGetValue("action", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'action' cannot be null",
                    new System::ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Action3>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["action"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string CancelationToken
    {
        get
        {
            if (!this._properties.TryGetValue("cancelation_token", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'cancelation_token' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "cancelation_token",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'cancelation_token' cannot be null",
                    new System::ArgumentNullException("cancelation_token")
                );
        }
        init
        {
            this._properties["cancelation_token"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Action.Validate();
        _ = this.CancelationToken;
    }

    public AutomationCancelStep() { }

    public AutomationCancelStep(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationCancelStep(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static AutomationCancelStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(Action3Converter))]
public enum Action3
{
    Cancel,
}

sealed class Action3Converter : JsonConverter<Action3>
{
    public override Action3 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cancel" => Action3.Cancel,
            _ => (Action3)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Action3 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Action3.Cancel => "cancel",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<AutomationFetchDataStep>))]
public sealed record class AutomationFetchDataStep : ModelBase, IFromRaw<AutomationFetchDataStep>
{
    public required ApiEnum<string, Action4> Action
    {
        get
        {
            if (!this._properties.TryGetValue("action", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'action' cannot be null",
                    new System::ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Action4>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["action"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Webhook Webhook
    {
        get
        {
            if (!this._properties.TryGetValue("webhook", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'webhook' cannot be null",
                    new System::ArgumentOutOfRangeException("webhook", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Webhook>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'webhook' cannot be null",
                    new System::ArgumentNullException("webhook")
                );
        }
        init
        {
            this._properties["webhook"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, MergeStrategy>? MergeStrategy
    {
        get
        {
            if (!this._properties.TryGetValue("merge_strategy", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, MergeStrategy>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["merge_strategy"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Action.Validate();
        this.Webhook.Validate();
        this.MergeStrategy?.Validate();
    }

    public AutomationFetchDataStep() { }

    public AutomationFetchDataStep(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationFetchDataStep(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static AutomationFetchDataStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(Action4Converter))]
public enum Action4
{
    FetchData,
}

sealed class Action4Converter : JsonConverter<Action4>
{
    public override Action4 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fetch-data" => Action4.FetchData,
            _ => (Action4)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Action4 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Action4.FetchData => "fetch-data",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Webhook>))]
public sealed record class Webhook : ModelBase, IFromRaw<Webhook>
{
    public required ApiEnum<string, global::Courier.Models.Automations.Invoke.Method> Method
    {
        get
        {
            if (!this._properties.TryGetValue("method", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'method' cannot be null",
                    new System::ArgumentOutOfRangeException("method", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Courier.Models.Automations.Invoke.Method>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["method"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string URL
    {
        get
        {
            if (!this._properties.TryGetValue("url", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'url' cannot be null",
                    new System::ArgumentOutOfRangeException("url", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'url' cannot be null",
                    new System::ArgumentNullException("url")
                );
        }
        init
        {
            this._properties["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Body
    {
        get
        {
            if (!this._properties.TryGetValue("body", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["body"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, string>? Headers
    {
        get
        {
            if (!this._properties.TryGetValue("headers", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["headers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Method.Validate();
        _ = this.URL;
        _ = this.Body;
        _ = this.Headers;
    }

    public Webhook() { }

    public Webhook(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Webhook(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Webhook FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(global::Courier.Models.Automations.Invoke.MethodConverter))]
public enum Method
{
    Get,
    Post,
    Put,
    Patch,
    Delete,
}

sealed class MethodConverter : JsonConverter<global::Courier.Models.Automations.Invoke.Method>
{
    public override global::Courier.Models.Automations.Invoke.Method Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET" => global::Courier.Models.Automations.Invoke.Method.Get,
            "POST" => global::Courier.Models.Automations.Invoke.Method.Post,
            "PUT" => global::Courier.Models.Automations.Invoke.Method.Put,
            "PATCH" => global::Courier.Models.Automations.Invoke.Method.Patch,
            "DELETE" => global::Courier.Models.Automations.Invoke.Method.Delete,
            _ => (global::Courier.Models.Automations.Invoke.Method)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Courier.Models.Automations.Invoke.Method value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Courier.Models.Automations.Invoke.Method.Get => "GET",
                global::Courier.Models.Automations.Invoke.Method.Post => "POST",
                global::Courier.Models.Automations.Invoke.Method.Put => "PUT",
                global::Courier.Models.Automations.Invoke.Method.Patch => "PATCH",
                global::Courier.Models.Automations.Invoke.Method.Delete => "DELETE",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(MergeStrategyConverter))]
public enum MergeStrategy
{
    Replace,
    Overwrite,
    SoftMerge,
}

sealed class MergeStrategyConverter : JsonConverter<MergeStrategy>
{
    public override MergeStrategy Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "replace" => MergeStrategy.Replace,
            "overwrite" => MergeStrategy.Overwrite,
            "soft-merge" => MergeStrategy.SoftMerge,
            _ => (MergeStrategy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MergeStrategy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MergeStrategy.Replace => "replace",
                MergeStrategy.Overwrite => "overwrite",
                MergeStrategy.SoftMerge => "soft-merge",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<AutomationInvokeStep>))]
public sealed record class AutomationInvokeStep : ModelBase, IFromRaw<AutomationInvokeStep>
{
    public required ApiEnum<string, Action5> Action
    {
        get
        {
            if (!this._properties.TryGetValue("action", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'action' cannot be null",
                    new System::ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Action5>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["action"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Template
    {
        get
        {
            if (!this._properties.TryGetValue("template", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'template' cannot be null",
                    new System::ArgumentOutOfRangeException("template", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'template' cannot be null",
                    new System::ArgumentNullException("template")
                );
        }
        init
        {
            this._properties["template"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Action.Validate();
        _ = this.Template;
    }

    public AutomationInvokeStep() { }

    public AutomationInvokeStep(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationInvokeStep(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static AutomationInvokeStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(Action5Converter))]
public enum Action5
{
    Invoke,
}

sealed class Action5Converter : JsonConverter<Action5>
{
    public override Action5 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invoke" => Action5.Invoke,
            _ => (Action5)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Action5 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Action5.Invoke => "invoke",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
