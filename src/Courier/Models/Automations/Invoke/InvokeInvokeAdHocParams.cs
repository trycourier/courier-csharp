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
/// Invoke an ad hoc automation run. This endpoint accepts a JSON payload with a
/// series of automation steps. For information about what steps are available, checkout
/// the ad hoc automation guide [here](https://www.courier.com/docs/automations/steps/).
/// </summary>
public sealed record class InvokeInvokeAdHocParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required Automation Automation
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("automation", out JsonElement element))
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
            this._rawBodyData["automation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Brand
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("brand", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["brand"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, JsonElement>? Data
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, JsonElement>? Profile
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("profile", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["profile"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Recipient
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("recipient", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["recipient"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Template
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("template", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["template"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public InvokeInvokeAdHocParams() { }

    public InvokeInvokeAdHocParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvokeInvokeAdHocParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    public static InvokeInvokeAdHocParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/automations/invoke"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(ModelConverter<Automation, AutomationFromRaw>))]
public sealed record class Automation : ModelBase
{
    public required List<Step> Steps
    {
        get
        {
            if (!this._rawData.TryGetValue("steps", out JsonElement element))
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
            this._rawData["steps"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? CancelationToken
    {
        get
        {
            if (!this._rawData.TryGetValue("cancelation_token", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["cancelation_token"] = JsonSerializer.SerializeToElement(
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

    public Automation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Automation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Automation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Automation(List<Step> steps)
        : this()
    {
        this.Steps = steps;
    }
}

class AutomationFromRaw : IFromRaw<Automation>
{
    public Automation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Automation.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StepConverter))]
public record class Step
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

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

    public Step(AutomationDelayStep value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Step(AutomationSendStep value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Step(AutomationSendListStep value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Step(AutomationUpdateProfileStep value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Step(AutomationCancelStep value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Step(AutomationFetchDataStep value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Step(AutomationInvokeStep value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Step(JsonElement json)
    {
        this._json = json;
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

    public static implicit operator Step(AutomationDelayStep value) => new(value);

    public static implicit operator Step(AutomationSendStep value) => new(value);

    public static implicit operator Step(AutomationSendListStep value) => new(value);

    public static implicit operator Step(AutomationUpdateProfileStep value) => new(value);

    public static implicit operator Step(AutomationCancelStep value) => new(value);

    public static implicit operator Step(AutomationFetchDataStep value) => new(value);

    public static implicit operator Step(AutomationInvokeStep value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new CourierInvalidDataException("Data did not match any variant of Step");
        }
    }
}

sealed class StepConverter : JsonConverter<Step>
{
    public override Step? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationDelayStep>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationSendStep>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationSendListStep>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationUpdateProfileStep>(
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationCancelStep>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationFetchDataStep>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationInvokeStep>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(Utf8JsonWriter writer, Step value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<AutomationDelayStep, AutomationDelayStepFromRaw>))]
public sealed record class AutomationDelayStep : ModelBase
{
    public required ApiEnum<string, Action> Action
    {
        get
        {
            if (!this._rawData.TryGetValue("action", out JsonElement element))
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
            this._rawData["action"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Duration
    {
        get
        {
            if (!this._rawData.TryGetValue("duration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Until
    {
        get
        {
            if (!this._rawData.TryGetValue("until", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["until"] = JsonSerializer.SerializeToElement(
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

    public AutomationDelayStep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationDelayStep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AutomationDelayStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AutomationDelayStep(ApiEnum<string, Action> action)
        : this()
    {
        this.Action = action;
    }
}

class AutomationDelayStepFromRaw : IFromRaw<AutomationDelayStep>
{
    public AutomationDelayStep FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AutomationDelayStep.FromRawUnchecked(rawData);
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

[JsonConverter(typeof(ModelConverter<AutomationSendStep, AutomationSendStepFromRaw>))]
public sealed record class AutomationSendStep : ModelBase
{
    public required ApiEnum<string, AutomationSendStepAction> Action
    {
        get
        {
            if (!this._rawData.TryGetValue("action", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'action' cannot be null",
                    new System::ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, AutomationSendStepAction>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["action"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Brand
    {
        get
        {
            if (!this._rawData.TryGetValue("brand", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["brand"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, JsonElement>? Data
    {
        get
        {
            if (!this._rawData.TryGetValue("data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, JsonElement>? Profile
    {
        get
        {
            if (!this._rawData.TryGetValue("profile", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["profile"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Recipient
    {
        get
        {
            if (!this._rawData.TryGetValue("recipient", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["recipient"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Template
    {
        get
        {
            if (!this._rawData.TryGetValue("template", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["template"] = JsonSerializer.SerializeToElement(
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

    public AutomationSendStep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationSendStep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AutomationSendStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AutomationSendStep(ApiEnum<string, AutomationSendStepAction> action)
        : this()
    {
        this.Action = action;
    }
}

class AutomationSendStepFromRaw : IFromRaw<AutomationSendStep>
{
    public AutomationSendStep FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AutomationSendStep.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AutomationSendStepActionConverter))]
public enum AutomationSendStepAction
{
    Send,
}

sealed class AutomationSendStepActionConverter : JsonConverter<AutomationSendStepAction>
{
    public override AutomationSendStepAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "send" => AutomationSendStepAction.Send,
            _ => (AutomationSendStepAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AutomationSendStepAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AutomationSendStepAction.Send => "send",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<AutomationSendListStep, AutomationSendListStepFromRaw>))]
public sealed record class AutomationSendListStep : ModelBase
{
    public required ApiEnum<string, AutomationSendListStepAction> Action
    {
        get
        {
            if (!this._rawData.TryGetValue("action", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'action' cannot be null",
                    new System::ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, AutomationSendListStepAction>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["action"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string List
    {
        get
        {
            if (!this._rawData.TryGetValue("list", out JsonElement element))
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
            this._rawData["list"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Brand
    {
        get
        {
            if (!this._rawData.TryGetValue("brand", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["brand"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, JsonElement>? Data
    {
        get
        {
            if (!this._rawData.TryGetValue("data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["data"] = JsonSerializer.SerializeToElement(
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

    public AutomationSendListStep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationSendListStep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AutomationSendListStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutomationSendListStepFromRaw : IFromRaw<AutomationSendListStep>
{
    public AutomationSendListStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutomationSendListStep.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AutomationSendListStepActionConverter))]
public enum AutomationSendListStepAction
{
    SendList,
}

sealed class AutomationSendListStepActionConverter : JsonConverter<AutomationSendListStepAction>
{
    public override AutomationSendListStepAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "send-list" => AutomationSendListStepAction.SendList,
            _ => (AutomationSendListStepAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AutomationSendListStepAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AutomationSendListStepAction.SendList => "send-list",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(ModelConverter<AutomationUpdateProfileStep, AutomationUpdateProfileStepFromRaw>)
)]
public sealed record class AutomationUpdateProfileStep : ModelBase
{
    public required ApiEnum<string, AutomationUpdateProfileStepAction> Action
    {
        get
        {
            if (!this._rawData.TryGetValue("action", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'action' cannot be null",
                    new System::ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, AutomationUpdateProfileStepAction>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["action"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Dictionary<string, JsonElement> Profile
    {
        get
        {
            if (!this._rawData.TryGetValue("profile", out JsonElement element))
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
            this._rawData["profile"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, Merge>? Merge
    {
        get
        {
            if (!this._rawData.TryGetValue("merge", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Merge>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["merge"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? RecipientID
    {
        get
        {
            if (!this._rawData.TryGetValue("recipient_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["recipient_id"] = JsonSerializer.SerializeToElement(
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

    public AutomationUpdateProfileStep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationUpdateProfileStep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AutomationUpdateProfileStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutomationUpdateProfileStepFromRaw : IFromRaw<AutomationUpdateProfileStep>
{
    public AutomationUpdateProfileStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutomationUpdateProfileStep.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AutomationUpdateProfileStepActionConverter))]
public enum AutomationUpdateProfileStepAction
{
    UpdateProfile,
}

sealed class AutomationUpdateProfileStepActionConverter
    : JsonConverter<AutomationUpdateProfileStepAction>
{
    public override AutomationUpdateProfileStepAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "update-profile" => AutomationUpdateProfileStepAction.UpdateProfile,
            _ => (AutomationUpdateProfileStepAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AutomationUpdateProfileStepAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AutomationUpdateProfileStepAction.UpdateProfile => "update-profile",
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

[JsonConverter(typeof(ModelConverter<AutomationCancelStep, AutomationCancelStepFromRaw>))]
public sealed record class AutomationCancelStep : ModelBase
{
    public required ApiEnum<string, AutomationCancelStepAction> Action
    {
        get
        {
            if (!this._rawData.TryGetValue("action", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'action' cannot be null",
                    new System::ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, AutomationCancelStepAction>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["action"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string CancelationToken
    {
        get
        {
            if (!this._rawData.TryGetValue("cancelation_token", out JsonElement element))
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
            this._rawData["cancelation_token"] = JsonSerializer.SerializeToElement(
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

    public AutomationCancelStep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationCancelStep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AutomationCancelStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutomationCancelStepFromRaw : IFromRaw<AutomationCancelStep>
{
    public AutomationCancelStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutomationCancelStep.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AutomationCancelStepActionConverter))]
public enum AutomationCancelStepAction
{
    Cancel,
}

sealed class AutomationCancelStepActionConverter : JsonConverter<AutomationCancelStepAction>
{
    public override AutomationCancelStepAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cancel" => AutomationCancelStepAction.Cancel,
            _ => (AutomationCancelStepAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AutomationCancelStepAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AutomationCancelStepAction.Cancel => "cancel",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<AutomationFetchDataStep, AutomationFetchDataStepFromRaw>))]
public sealed record class AutomationFetchDataStep : ModelBase
{
    public required ApiEnum<string, AutomationFetchDataStepAction> Action
    {
        get
        {
            if (!this._rawData.TryGetValue("action", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'action' cannot be null",
                    new System::ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, AutomationFetchDataStepAction>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["action"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Webhook Webhook
    {
        get
        {
            if (!this._rawData.TryGetValue("webhook", out JsonElement element))
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
            this._rawData["webhook"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, MergeStrategy>? MergeStrategy
    {
        get
        {
            if (!this._rawData.TryGetValue("merge_strategy", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, MergeStrategy>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["merge_strategy"] = JsonSerializer.SerializeToElement(
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

    public AutomationFetchDataStep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationFetchDataStep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AutomationFetchDataStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutomationFetchDataStepFromRaw : IFromRaw<AutomationFetchDataStep>
{
    public AutomationFetchDataStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutomationFetchDataStep.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AutomationFetchDataStepActionConverter))]
public enum AutomationFetchDataStepAction
{
    FetchData,
}

sealed class AutomationFetchDataStepActionConverter : JsonConverter<AutomationFetchDataStepAction>
{
    public override AutomationFetchDataStepAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fetch-data" => AutomationFetchDataStepAction.FetchData,
            _ => (AutomationFetchDataStepAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AutomationFetchDataStepAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AutomationFetchDataStepAction.FetchData => "fetch-data",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Webhook, WebhookFromRaw>))]
public sealed record class Webhook : ModelBase
{
    public required ApiEnum<string, global::Courier.Models.Automations.Invoke.Method> Method
    {
        get
        {
            if (!this._rawData.TryGetValue("method", out JsonElement element))
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
            this._rawData["method"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string URL
    {
        get
        {
            if (!this._rawData.TryGetValue("url", out JsonElement element))
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
            this._rawData["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Body
    {
        get
        {
            if (!this._rawData.TryGetValue("body", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["body"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, string>? Headers
    {
        get
        {
            if (!this._rawData.TryGetValue("headers", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["headers"] = JsonSerializer.SerializeToElement(
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

    public Webhook(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Webhook(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Webhook FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookFromRaw : IFromRaw<Webhook>
{
    public Webhook FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Webhook.FromRawUnchecked(rawData);
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

[JsonConverter(typeof(ModelConverter<AutomationInvokeStep, AutomationInvokeStepFromRaw>))]
public sealed record class AutomationInvokeStep : ModelBase
{
    public required ApiEnum<string, AutomationInvokeStepAction> Action
    {
        get
        {
            if (!this._rawData.TryGetValue("action", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'action' cannot be null",
                    new System::ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, AutomationInvokeStepAction>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["action"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Template
    {
        get
        {
            if (!this._rawData.TryGetValue("template", out JsonElement element))
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
            this._rawData["template"] = JsonSerializer.SerializeToElement(
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

    public AutomationInvokeStep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationInvokeStep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AutomationInvokeStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutomationInvokeStepFromRaw : IFromRaw<AutomationInvokeStep>
{
    public AutomationInvokeStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutomationInvokeStep.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AutomationInvokeStepActionConverter))]
public enum AutomationInvokeStepAction
{
    Invoke,
}

sealed class AutomationInvokeStepActionConverter : JsonConverter<AutomationInvokeStepAction>
{
    public override AutomationInvokeStepAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invoke" => AutomationInvokeStepAction.Invoke,
            _ => (AutomationInvokeStepAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AutomationInvokeStepAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AutomationInvokeStepAction.Invoke => "invoke",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
