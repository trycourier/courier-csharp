using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required Automation Automation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Automation>("automation");
        }
        init { this._rawBodyData.Set("automation", value); }
    }

    public string? Brand
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("brand");
        }
        init { this._rawBodyData.Set("brand", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Data
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "data"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "data",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? Profile
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "profile"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "profile",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? Recipient
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("recipient");
        }
        init { this._rawBodyData.Set("recipient", value); }
    }

    public string? Template
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("template");
        }
        init { this._rawBodyData.Set("template", value); }
    }

    public InvokeInvokeAdHocParams() { }

    public InvokeInvokeAdHocParams(InvokeInvokeAdHocParams invokeInvokeAdHocParams)
        : base(invokeInvokeAdHocParams)
    {
        this._rawBodyData = new(invokeInvokeAdHocParams._rawBodyData);
    }

    public InvokeInvokeAdHocParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvokeInvokeAdHocParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
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

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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

[JsonConverter(typeof(JsonModelConverter<Automation, AutomationFromRaw>))]
public sealed record class Automation : JsonModel
{
    public required IReadOnlyList<Step> Steps
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Step>>("steps");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Step>>(
                "steps",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? CancelationToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cancelation_token");
        }
        init { this._rawData.Set("cancelation_token", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Steps)
        {
            item.Validate();
        }
        _ = this.CancelationToken;
    }

    public Automation() { }

    public Automation(Automation automation)
        : base(automation) { }

    public Automation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Automation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutomationFromRaw.FromRawUnchecked"/>
    public static Automation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Automation(IReadOnlyList<Step> steps)
        : this()
    {
        this.Steps = steps;
    }
}

class AutomationFromRaw : IFromRawJson<Automation>
{
    /// <inheritdoc/>
    public Automation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Automation.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StepConverter))]
public record class Step : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
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

    public Step(AutomationDelayStep value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Step(AutomationSendStep value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Step(AutomationSendListStep value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Step(AutomationUpdateProfileStep value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Step(AutomationCancelStep value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Step(AutomationFetchDataStep value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Step(AutomationInvokeStep value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Step(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AutomationDelayStep"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAutomationDelay(out var value)) {
    ///     // `value` is of type `AutomationDelayStep`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAutomationDelay([NotNullWhen(true)] out AutomationDelayStep? value)
    {
        value = this.Value as AutomationDelayStep;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AutomationSendStep"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAutomationSend(out var value)) {
    ///     // `value` is of type `AutomationSendStep`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAutomationSend([NotNullWhen(true)] out AutomationSendStep? value)
    {
        value = this.Value as AutomationSendStep;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AutomationSendListStep"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAutomationSendList(out var value)) {
    ///     // `value` is of type `AutomationSendListStep`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAutomationSendList([NotNullWhen(true)] out AutomationSendListStep? value)
    {
        value = this.Value as AutomationSendListStep;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AutomationUpdateProfileStep"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAutomationUpdateProfile(out var value)) {
    ///     // `value` is of type `AutomationUpdateProfileStep`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAutomationUpdateProfile(
        [NotNullWhen(true)] out AutomationUpdateProfileStep? value
    )
    {
        value = this.Value as AutomationUpdateProfileStep;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AutomationCancelStep"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAutomationCancel(out var value)) {
    ///     // `value` is of type `AutomationCancelStep`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAutomationCancel([NotNullWhen(true)] out AutomationCancelStep? value)
    {
        value = this.Value as AutomationCancelStep;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AutomationFetchDataStep"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAutomationFetchData(out var value)) {
    ///     // `value` is of type `AutomationFetchDataStep`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAutomationFetchData([NotNullWhen(true)] out AutomationFetchDataStep? value)
    {
        value = this.Value as AutomationFetchDataStep;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AutomationInvokeStep"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAutomationInvoke(out var value)) {
    ///     // `value` is of type `AutomationInvokeStep`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAutomationInvoke([NotNullWhen(true)] out AutomationInvokeStep? value)
    {
        value = this.Value as AutomationInvokeStep;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="CourierInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (AutomationDelayStep value) => {...},
    ///     (AutomationSendStep value) => {...},
    ///     (AutomationSendListStep value) => {...},
    ///     (AutomationUpdateProfileStep value) => {...},
    ///     (AutomationCancelStep value) => {...},
    ///     (AutomationFetchDataStep value) => {...},
    ///     (AutomationInvokeStep value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="CourierInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (AutomationDelayStep value) => {...},
    ///     (AutomationSendStep value) => {...},
    ///     (AutomationSendListStep value) => {...},
    ///     (AutomationUpdateProfileStep value) => {...},
    ///     (AutomationCancelStep value) => {...},
    ///     (AutomationFetchDataStep value) => {...},
    ///     (AutomationInvokeStep value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="CourierInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new CourierInvalidDataException("Data did not match any variant of Step");
        }
        this.Switch(
            (automationDelay) => automationDelay.Validate(),
            (automationSend) => automationSend.Validate(),
            (automationSendList) => automationSendList.Validate(),
            (automationUpdateProfile) => automationUpdateProfile.Validate(),
            (automationCancel) => automationCancel.Validate(),
            (automationFetchData) => automationFetchData.Validate(),
            (automationInvoke) => automationInvoke.Validate()
        );
    }

    public virtual bool Equals(Step? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class StepConverter : JsonConverter<Step>
{
    public override Step? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationDelayStep>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationSendStep>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationSendListStep>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationUpdateProfileStep>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationCancelStep>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationFetchDataStep>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AutomationInvokeStep>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Step value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<AutomationDelayStep, AutomationDelayStepFromRaw>))]
public sealed record class AutomationDelayStep : JsonModel
{
    public required ApiEnum<string, Action> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Action>>("action");
        }
        init { this._rawData.Set("action", value); }
    }

    public string? Duration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("duration");
        }
        init { this._rawData.Set("duration", value); }
    }

    public string? Until
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("until");
        }
        init { this._rawData.Set("until", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Action.Validate();
        _ = this.Duration;
        _ = this.Until;
    }

    public AutomationDelayStep() { }

    public AutomationDelayStep(AutomationDelayStep automationDelayStep)
        : base(automationDelayStep) { }

    public AutomationDelayStep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationDelayStep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutomationDelayStepFromRaw.FromRawUnchecked"/>
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

class AutomationDelayStepFromRaw : IFromRawJson<AutomationDelayStep>
{
    /// <inheritdoc/>
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

[JsonConverter(typeof(JsonModelConverter<AutomationSendStep, AutomationSendStepFromRaw>))]
public sealed record class AutomationSendStep : JsonModel
{
    public required ApiEnum<string, AutomationSendStepAction> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AutomationSendStepAction>>(
                "action"
            );
        }
        init { this._rawData.Set("action", value); }
    }

    public string? Brand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("brand");
        }
        init { this._rawData.Set("brand", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("data");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "data",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? Profile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("profile");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "profile",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? Recipient
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("recipient");
        }
        init { this._rawData.Set("recipient", value); }
    }

    public string? Template
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("template");
        }
        init { this._rawData.Set("template", value); }
    }

    /// <inheritdoc/>
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

    public AutomationSendStep(AutomationSendStep automationSendStep)
        : base(automationSendStep) { }

    public AutomationSendStep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationSendStep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutomationSendStepFromRaw.FromRawUnchecked"/>
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

class AutomationSendStepFromRaw : IFromRawJson<AutomationSendStep>
{
    /// <inheritdoc/>
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

[JsonConverter(typeof(JsonModelConverter<AutomationSendListStep, AutomationSendListStepFromRaw>))]
public sealed record class AutomationSendListStep : JsonModel
{
    public required ApiEnum<string, AutomationSendListStepAction> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AutomationSendListStepAction>>(
                "action"
            );
        }
        init { this._rawData.Set("action", value); }
    }

    public required string List
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("list");
        }
        init { this._rawData.Set("list", value); }
    }

    public string? Brand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("brand");
        }
        init { this._rawData.Set("brand", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("data");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "data",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Action.Validate();
        _ = this.List;
        _ = this.Brand;
        _ = this.Data;
    }

    public AutomationSendListStep() { }

    public AutomationSendListStep(AutomationSendListStep automationSendListStep)
        : base(automationSendListStep) { }

    public AutomationSendListStep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationSendListStep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutomationSendListStepFromRaw.FromRawUnchecked"/>
    public static AutomationSendListStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutomationSendListStepFromRaw : IFromRawJson<AutomationSendListStep>
{
    /// <inheritdoc/>
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
    typeof(JsonModelConverter<AutomationUpdateProfileStep, AutomationUpdateProfileStepFromRaw>)
)]
public sealed record class AutomationUpdateProfileStep : JsonModel
{
    public required ApiEnum<string, AutomationUpdateProfileStepAction> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AutomationUpdateProfileStepAction>
            >("action");
        }
        init { this._rawData.Set("action", value); }
    }

    public required IReadOnlyDictionary<string, JsonElement> Profile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("profile");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "profile",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public ApiEnum<string, Merge>? Merge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Merge>>("merge");
        }
        init { this._rawData.Set("merge", value); }
    }

    public string? RecipientID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("recipient_id");
        }
        init { this._rawData.Set("recipient_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Action.Validate();
        _ = this.Profile;
        this.Merge?.Validate();
        _ = this.RecipientID;
    }

    public AutomationUpdateProfileStep() { }

    public AutomationUpdateProfileStep(AutomationUpdateProfileStep automationUpdateProfileStep)
        : base(automationUpdateProfileStep) { }

    public AutomationUpdateProfileStep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationUpdateProfileStep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutomationUpdateProfileStepFromRaw.FromRawUnchecked"/>
    public static AutomationUpdateProfileStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutomationUpdateProfileStepFromRaw : IFromRawJson<AutomationUpdateProfileStep>
{
    /// <inheritdoc/>
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

[JsonConverter(typeof(JsonModelConverter<AutomationCancelStep, AutomationCancelStepFromRaw>))]
public sealed record class AutomationCancelStep : JsonModel
{
    public required ApiEnum<string, AutomationCancelStepAction> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AutomationCancelStepAction>>(
                "action"
            );
        }
        init { this._rawData.Set("action", value); }
    }

    public required string CancelationToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("cancelation_token");
        }
        init { this._rawData.Set("cancelation_token", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Action.Validate();
        _ = this.CancelationToken;
    }

    public AutomationCancelStep() { }

    public AutomationCancelStep(AutomationCancelStep automationCancelStep)
        : base(automationCancelStep) { }

    public AutomationCancelStep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationCancelStep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutomationCancelStepFromRaw.FromRawUnchecked"/>
    public static AutomationCancelStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutomationCancelStepFromRaw : IFromRawJson<AutomationCancelStep>
{
    /// <inheritdoc/>
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

[JsonConverter(typeof(JsonModelConverter<AutomationFetchDataStep, AutomationFetchDataStepFromRaw>))]
public sealed record class AutomationFetchDataStep : JsonModel
{
    public required ApiEnum<string, AutomationFetchDataStepAction> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AutomationFetchDataStepAction>>(
                "action"
            );
        }
        init { this._rawData.Set("action", value); }
    }

    public required Webhook Webhook
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Webhook>("webhook");
        }
        init { this._rawData.Set("webhook", value); }
    }

    public ApiEnum<string, MergeStrategy>? MergeStrategy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MergeStrategy>>("merge_strategy");
        }
        init { this._rawData.Set("merge_strategy", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Action.Validate();
        this.Webhook.Validate();
        this.MergeStrategy?.Validate();
    }

    public AutomationFetchDataStep() { }

    public AutomationFetchDataStep(AutomationFetchDataStep automationFetchDataStep)
        : base(automationFetchDataStep) { }

    public AutomationFetchDataStep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationFetchDataStep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutomationFetchDataStepFromRaw.FromRawUnchecked"/>
    public static AutomationFetchDataStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutomationFetchDataStepFromRaw : IFromRawJson<AutomationFetchDataStep>
{
    /// <inheritdoc/>
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

[JsonConverter(typeof(JsonModelConverter<Webhook, WebhookFromRaw>))]
public sealed record class Webhook : JsonModel
{
    public required ApiEnum<string, global::Courier.Models.Automations.Invoke.Method> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Courier.Models.Automations.Invoke.Method>
            >("method");
        }
        init { this._rawData.Set("method", value); }
    }

    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    public string? Body
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("body");
        }
        init { this._rawData.Set("body", value); }
    }

    public IReadOnlyDictionary<string, string>? Headers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("headers");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Method.Validate();
        _ = this.Url;
        _ = this.Body;
        _ = this.Headers;
    }

    public Webhook() { }

    public Webhook(Webhook webhook)
        : base(webhook) { }

    public Webhook(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Webhook(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookFromRaw.FromRawUnchecked"/>
    public static Webhook FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookFromRaw : IFromRawJson<Webhook>
{
    /// <inheritdoc/>
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

[JsonConverter(typeof(JsonModelConverter<AutomationInvokeStep, AutomationInvokeStepFromRaw>))]
public sealed record class AutomationInvokeStep : JsonModel
{
    public required ApiEnum<string, AutomationInvokeStepAction> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AutomationInvokeStepAction>>(
                "action"
            );
        }
        init { this._rawData.Set("action", value); }
    }

    public required string Template
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("template");
        }
        init { this._rawData.Set("template", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Action.Validate();
        _ = this.Template;
    }

    public AutomationInvokeStep() { }

    public AutomationInvokeStep(AutomationInvokeStep automationInvokeStep)
        : base(automationInvokeStep) { }

    public AutomationInvokeStep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationInvokeStep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutomationInvokeStepFromRaw.FromRawUnchecked"/>
    public static AutomationInvokeStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutomationInvokeStepFromRaw : IFromRawJson<AutomationInvokeStep>
{
    /// <inheritdoc/>
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
