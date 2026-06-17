using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Journeys;

/// <summary>
/// A single node in a journey DAG. Discriminated by `type`, with a secondary discriminator
/// on some variants (`trigger_type` for trigger, `mode` for delay, `method` for fetch,
/// `scope` for throttle).
/// </summary>
[JsonConverter(typeof(JourneyNodeConverter))]
public record class JourneyNode : ModelBase
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

    public string? ID
    {
        get
        {
            return Match<string?>(
                apiInvokeTrigger: (x) => x.ID,
                segmentTrigger: (x) => x.ID,
                send: (x) => x.ID,
                delayDuration: (x) => x.ID,
                delayUntil: (x) => x.ID,
                fetchGetDelete: (x) => x.ID,
                fetchPostPut: (x) => x.ID,
                ai: (x) => x.ID,
                throttleStatic: (x) => x.ID,
                throttleDynamic: (x) => x.ID,
                batch: (x) => x.ID,
                addToDigest: (x) => x.ID,
                exit: (x) => x.ID,
                branch: (x) => x.ID
            );
        }
    }

    public JourneyConditionsField? Conditions
    {
        get
        {
            return Match<JourneyConditionsField?>(
                apiInvokeTrigger: (x) => x.Conditions,
                segmentTrigger: (x) => x.Conditions,
                send: (x) => x.Conditions,
                delayDuration: (x) => x.Conditions,
                delayUntil: (x) => x.Conditions,
                fetchGetDelete: (x) => x.Conditions,
                fetchPostPut: (x) => x.Conditions,
                ai: (x) => x.Conditions,
                throttleStatic: (x) => x.Conditions,
                throttleDynamic: (x) => x.Conditions,
                batch: (x) => x.Conditions,
                addToDigest: (x) => x.Conditions,
                exit: (_) => null,
                branch: (_) => null
            );
        }
    }

    public ApiEnum<string, JourneyMergeStrategy>? MergeStrategy
    {
        get
        {
            return Match<ApiEnum<string, JourneyMergeStrategy>?>(
                apiInvokeTrigger: (_) => null,
                segmentTrigger: (_) => null,
                send: (_) => null,
                delayDuration: (_) => null,
                delayUntil: (_) => null,
                fetchGetDelete: (x) => x.MergeStrategy,
                fetchPostPut: (x) => x.MergeStrategy,
                ai: (_) => null,
                throttleStatic: (_) => null,
                throttleDynamic: (_) => null,
                batch: (_) => null,
                addToDigest: (_) => null,
                exit: (_) => null,
                branch: (_) => null
            );
        }
    }

    public string? Url
    {
        get
        {
            return Match<string?>(
                apiInvokeTrigger: (_) => null,
                segmentTrigger: (_) => null,
                send: (_) => null,
                delayDuration: (_) => null,
                delayUntil: (_) => null,
                fetchGetDelete: (x) => x.Url,
                fetchPostPut: (x) => x.Url,
                ai: (_) => null,
                throttleStatic: (_) => null,
                throttleDynamic: (_) => null,
                batch: (_) => null,
                addToDigest: (_) => null,
                exit: (_) => null,
                branch: (_) => null
            );
        }
    }

    public long? MaxAllowed
    {
        get
        {
            return Match<long?>(
                apiInvokeTrigger: (_) => null,
                segmentTrigger: (_) => null,
                send: (_) => null,
                delayDuration: (_) => null,
                delayUntil: (_) => null,
                fetchGetDelete: (_) => null,
                fetchPostPut: (_) => null,
                ai: (_) => null,
                throttleStatic: (x) => x.MaxAllowed,
                throttleDynamic: (x) => x.MaxAllowed,
                batch: (_) => null,
                addToDigest: (_) => null,
                exit: (_) => null,
                branch: (_) => null
            );
        }
    }

    public string? Period
    {
        get
        {
            return Match<string?>(
                apiInvokeTrigger: (_) => null,
                segmentTrigger: (_) => null,
                send: (_) => null,
                delayDuration: (_) => null,
                delayUntil: (_) => null,
                fetchGetDelete: (_) => null,
                fetchPostPut: (_) => null,
                ai: (_) => null,
                throttleStatic: (x) => x.Period,
                throttleDynamic: (x) => x.Period,
                batch: (_) => null,
                addToDigest: (_) => null,
                exit: (_) => null,
                branch: (_) => null
            );
        }
    }

    public JourneyNode(JourneyApiInvokeTriggerNode value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public JourneyNode(JourneySegmentTriggerNode value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public JourneyNode(JourneySendNode value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public JourneyNode(JourneyDelayDurationNode value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public JourneyNode(JourneyDelayUntilNode value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public JourneyNode(JourneyFetchGetDeleteNode value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public JourneyNode(JourneyFetchPostPutNode value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public JourneyNode(JourneyAINode value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public JourneyNode(JourneyThrottleStaticNode value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public JourneyNode(JourneyThrottleDynamicNode value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public JourneyNode(JourneyBatchNode value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public JourneyNode(JourneyAddToDigestNode value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public JourneyNode(JourneyExitNode value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public JourneyNode(JourneyBranchNode value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public JourneyNode(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JourneyApiInvokeTriggerNode"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickApiInvokeTrigger(out var value)) {
    ///     // `value` is of type `JourneyApiInvokeTriggerNode`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickApiInvokeTrigger([NotNullWhen(true)] out JourneyApiInvokeTriggerNode? value)
    {
        value = this.Value as JourneyApiInvokeTriggerNode;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JourneySegmentTriggerNode"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSegmentTrigger(out var value)) {
    ///     // `value` is of type `JourneySegmentTriggerNode`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSegmentTrigger([NotNullWhen(true)] out JourneySegmentTriggerNode? value)
    {
        value = this.Value as JourneySegmentTriggerNode;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JourneySendNode"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSend(out var value)) {
    ///     // `value` is of type `JourneySendNode`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSend([NotNullWhen(true)] out JourneySendNode? value)
    {
        value = this.Value as JourneySendNode;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JourneyDelayDurationNode"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDelayDuration(out var value)) {
    ///     // `value` is of type `JourneyDelayDurationNode`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDelayDuration([NotNullWhen(true)] out JourneyDelayDurationNode? value)
    {
        value = this.Value as JourneyDelayDurationNode;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JourneyDelayUntilNode"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDelayUntil(out var value)) {
    ///     // `value` is of type `JourneyDelayUntilNode`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDelayUntil([NotNullWhen(true)] out JourneyDelayUntilNode? value)
    {
        value = this.Value as JourneyDelayUntilNode;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JourneyFetchGetDeleteNode"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFetchGetDelete(out var value)) {
    ///     // `value` is of type `JourneyFetchGetDeleteNode`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFetchGetDelete([NotNullWhen(true)] out JourneyFetchGetDeleteNode? value)
    {
        value = this.Value as JourneyFetchGetDeleteNode;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JourneyFetchPostPutNode"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFetchPostPut(out var value)) {
    ///     // `value` is of type `JourneyFetchPostPutNode`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFetchPostPut([NotNullWhen(true)] out JourneyFetchPostPutNode? value)
    {
        value = this.Value as JourneyFetchPostPutNode;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JourneyAINode"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAI(out var value)) {
    ///     // `value` is of type `JourneyAINode`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAI([NotNullWhen(true)] out JourneyAINode? value)
    {
        value = this.Value as JourneyAINode;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JourneyThrottleStaticNode"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThrottleStatic(out var value)) {
    ///     // `value` is of type `JourneyThrottleStaticNode`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThrottleStatic([NotNullWhen(true)] out JourneyThrottleStaticNode? value)
    {
        value = this.Value as JourneyThrottleStaticNode;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JourneyThrottleDynamicNode"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThrottleDynamic(out var value)) {
    ///     // `value` is of type `JourneyThrottleDynamicNode`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThrottleDynamic([NotNullWhen(true)] out JourneyThrottleDynamicNode? value)
    {
        value = this.Value as JourneyThrottleDynamicNode;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JourneyBatchNode"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBatch(out var value)) {
    ///     // `value` is of type `JourneyBatchNode`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBatch([NotNullWhen(true)] out JourneyBatchNode? value)
    {
        value = this.Value as JourneyBatchNode;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JourneyAddToDigestNode"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAddToDigest(out var value)) {
    ///     // `value` is of type `JourneyAddToDigestNode`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAddToDigest([NotNullWhen(true)] out JourneyAddToDigestNode? value)
    {
        value = this.Value as JourneyAddToDigestNode;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JourneyExitNode"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExit(out var value)) {
    ///     // `value` is of type `JourneyExitNode`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExit([NotNullWhen(true)] out JourneyExitNode? value)
    {
        value = this.Value as JourneyExitNode;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JourneyBranchNode"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBranch(out var value)) {
    ///     // `value` is of type `JourneyBranchNode`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBranch([NotNullWhen(true)] out JourneyBranchNode? value)
    {
        value = this.Value as JourneyBranchNode;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (JourneyApiInvokeTriggerNode value) =&gt; {...},
    ///     (JourneySegmentTriggerNode value) =&gt; {...},
    ///     (JourneySendNode value) =&gt; {...},
    ///     (JourneyDelayDurationNode value) =&gt; {...},
    ///     (JourneyDelayUntilNode value) =&gt; {...},
    ///     (JourneyFetchGetDeleteNode value) =&gt; {...},
    ///     (JourneyFetchPostPutNode value) =&gt; {...},
    ///     (JourneyAINode value) =&gt; {...},
    ///     (JourneyThrottleStaticNode value) =&gt; {...},
    ///     (JourneyThrottleDynamicNode value) =&gt; {...},
    ///     (JourneyBatchNode value) =&gt; {...},
    ///     (JourneyAddToDigestNode value) =&gt; {...},
    ///     (JourneyExitNode value) =&gt; {...},
    ///     (JourneyBranchNode value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<JourneyApiInvokeTriggerNode> apiInvokeTrigger,
        System::Action<JourneySegmentTriggerNode> segmentTrigger,
        System::Action<JourneySendNode> send,
        System::Action<JourneyDelayDurationNode> delayDuration,
        System::Action<JourneyDelayUntilNode> delayUntil,
        System::Action<JourneyFetchGetDeleteNode> fetchGetDelete,
        System::Action<JourneyFetchPostPutNode> fetchPostPut,
        System::Action<JourneyAINode> ai,
        System::Action<JourneyThrottleStaticNode> throttleStatic,
        System::Action<JourneyThrottleDynamicNode> throttleDynamic,
        System::Action<JourneyBatchNode> batch,
        System::Action<JourneyAddToDigestNode> addToDigest,
        System::Action<JourneyExitNode> exit,
        System::Action<JourneyBranchNode> branch
    )
    {
        switch (this.Value)
        {
            case JourneyApiInvokeTriggerNode value:
                apiInvokeTrigger(value);
                break;
            case JourneySegmentTriggerNode value:
                segmentTrigger(value);
                break;
            case JourneySendNode value:
                send(value);
                break;
            case JourneyDelayDurationNode value:
                delayDuration(value);
                break;
            case JourneyDelayUntilNode value:
                delayUntil(value);
                break;
            case JourneyFetchGetDeleteNode value:
                fetchGetDelete(value);
                break;
            case JourneyFetchPostPutNode value:
                fetchPostPut(value);
                break;
            case JourneyAINode value:
                ai(value);
                break;
            case JourneyThrottleStaticNode value:
                throttleStatic(value);
                break;
            case JourneyThrottleDynamicNode value:
                throttleDynamic(value);
                break;
            case JourneyBatchNode value:
                batch(value);
                break;
            case JourneyAddToDigestNode value:
                addToDigest(value);
                break;
            case JourneyExitNode value:
                exit(value);
                break;
            case JourneyBranchNode value:
                branch(value);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of JourneyNode"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (JourneyApiInvokeTriggerNode value) =&gt; {...},
    ///     (JourneySegmentTriggerNode value) =&gt; {...},
    ///     (JourneySendNode value) =&gt; {...},
    ///     (JourneyDelayDurationNode value) =&gt; {...},
    ///     (JourneyDelayUntilNode value) =&gt; {...},
    ///     (JourneyFetchGetDeleteNode value) =&gt; {...},
    ///     (JourneyFetchPostPutNode value) =&gt; {...},
    ///     (JourneyAINode value) =&gt; {...},
    ///     (JourneyThrottleStaticNode value) =&gt; {...},
    ///     (JourneyThrottleDynamicNode value) =&gt; {...},
    ///     (JourneyBatchNode value) =&gt; {...},
    ///     (JourneyAddToDigestNode value) =&gt; {...},
    ///     (JourneyExitNode value) =&gt; {...},
    ///     (JourneyBranchNode value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<JourneyApiInvokeTriggerNode, T> apiInvokeTrigger,
        System::Func<JourneySegmentTriggerNode, T> segmentTrigger,
        System::Func<JourneySendNode, T> send,
        System::Func<JourneyDelayDurationNode, T> delayDuration,
        System::Func<JourneyDelayUntilNode, T> delayUntil,
        System::Func<JourneyFetchGetDeleteNode, T> fetchGetDelete,
        System::Func<JourneyFetchPostPutNode, T> fetchPostPut,
        System::Func<JourneyAINode, T> ai,
        System::Func<JourneyThrottleStaticNode, T> throttleStatic,
        System::Func<JourneyThrottleDynamicNode, T> throttleDynamic,
        System::Func<JourneyBatchNode, T> batch,
        System::Func<JourneyAddToDigestNode, T> addToDigest,
        System::Func<JourneyExitNode, T> exit,
        System::Func<JourneyBranchNode, T> branch
    )
    {
        return this.Value switch
        {
            JourneyApiInvokeTriggerNode value => apiInvokeTrigger(value),
            JourneySegmentTriggerNode value => segmentTrigger(value),
            JourneySendNode value => send(value),
            JourneyDelayDurationNode value => delayDuration(value),
            JourneyDelayUntilNode value => delayUntil(value),
            JourneyFetchGetDeleteNode value => fetchGetDelete(value),
            JourneyFetchPostPutNode value => fetchPostPut(value),
            JourneyAINode value => ai(value),
            JourneyThrottleStaticNode value => throttleStatic(value),
            JourneyThrottleDynamicNode value => throttleDynamic(value),
            JourneyBatchNode value => batch(value),
            JourneyAddToDigestNode value => addToDigest(value),
            JourneyExitNode value => exit(value),
            JourneyBranchNode value => branch(value),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of JourneyNode"
            ),
        };
    }

    public static implicit operator JourneyNode(JourneyApiInvokeTriggerNode value) => new(value);

    public static implicit operator JourneyNode(JourneySegmentTriggerNode value) => new(value);

    public static implicit operator JourneyNode(JourneySendNode value) => new(value);

    public static implicit operator JourneyNode(JourneyDelayDurationNode value) => new(value);

    public static implicit operator JourneyNode(JourneyDelayUntilNode value) => new(value);

    public static implicit operator JourneyNode(JourneyFetchGetDeleteNode value) => new(value);

    public static implicit operator JourneyNode(JourneyFetchPostPutNode value) => new(value);

    public static implicit operator JourneyNode(JourneyAINode value) => new(value);

    public static implicit operator JourneyNode(JourneyThrottleStaticNode value) => new(value);

    public static implicit operator JourneyNode(JourneyThrottleDynamicNode value) => new(value);

    public static implicit operator JourneyNode(JourneyBatchNode value) => new(value);

    public static implicit operator JourneyNode(JourneyAddToDigestNode value) => new(value);

    public static implicit operator JourneyNode(JourneyExitNode value) => new(value);

    public static implicit operator JourneyNode(JourneyBranchNode value) => new(value);

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
            throw new CourierInvalidDataException("Data did not match any variant of JourneyNode");
        }
        this.Switch(
            (apiInvokeTrigger) => apiInvokeTrigger.Validate(),
            (segmentTrigger) => segmentTrigger.Validate(),
            (send) => send.Validate(),
            (delayDuration) => delayDuration.Validate(),
            (delayUntil) => delayUntil.Validate(),
            (fetchGetDelete) => fetchGetDelete.Validate(),
            (fetchPostPut) => fetchPostPut.Validate(),
            (ai) => ai.Validate(),
            (throttleStatic) => throttleStatic.Validate(),
            (throttleDynamic) => throttleDynamic.Validate(),
            (batch) => batch.Validate(),
            (addToDigest) => addToDigest.Validate(),
            (exit) => exit.Validate(),
            (branch) => branch.Validate()
        );
    }

    public virtual bool Equals(JourneyNode? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            JourneyApiInvokeTriggerNode _ => 0,
            JourneySegmentTriggerNode _ => 1,
            JourneySendNode _ => 2,
            JourneyDelayDurationNode _ => 3,
            JourneyDelayUntilNode _ => 4,
            JourneyFetchGetDeleteNode _ => 5,
            JourneyFetchPostPutNode _ => 6,
            JourneyAINode _ => 7,
            JourneyThrottleStaticNode _ => 8,
            JourneyThrottleDynamicNode _ => 9,
            JourneyBatchNode _ => 10,
            JourneyAddToDigestNode _ => 11,
            JourneyExitNode _ => 12,
            JourneyBranchNode _ => 13,
            _ => -1,
        };
    }
}

sealed class JourneyNodeConverter : JsonConverter<JourneyNode>
{
    public override JourneyNode? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<JourneyApiInvokeTriggerNode>(
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
            var deserialized = JsonSerializer.Deserialize<JourneySegmentTriggerNode>(
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
            var deserialized = JsonSerializer.Deserialize<JourneySendNode>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<JourneyDelayDurationNode>(
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
            var deserialized = JsonSerializer.Deserialize<JourneyDelayUntilNode>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<JourneyFetchGetDeleteNode>(
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
            var deserialized = JsonSerializer.Deserialize<JourneyFetchPostPutNode>(
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
            var deserialized = JsonSerializer.Deserialize<JourneyAINode>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<JourneyThrottleStaticNode>(
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
            var deserialized = JsonSerializer.Deserialize<JourneyThrottleDynamicNode>(
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
            var deserialized = JsonSerializer.Deserialize<JourneyBatchNode>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<JourneyAddToDigestNode>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<JourneyExitNode>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<JourneyBranchNode>(element, options);
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

    public override void Write(
        Utf8JsonWriter writer,
        JourneyNode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Collect events arriving at the node into a single batch and fire one downstream
/// step with the aggregated payload. The first event into a batch owns the run;
/// later contributing events terminate at the batch step. The batch releases when
/// any of `max_items` is reached, a quiet window of `wait_period` elapses, or the
/// `max_wait_period` ceiling hits.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JourneyBatchNode, JourneyBatchNodeFromRaw>))]
public sealed record class JourneyBatchNode : JsonModel
{
    /// <summary>
    /// ISO 8601 duration. Hard ceiling from the first event into the batch; releases
    /// the batch unconditionally when it elapses.
    /// </summary>
    public required string MaxWaitPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("max_wait_period");
        }
        init { this._rawData.Set("max_wait_period", value); }
    }

    /// <summary>
    /// How to select which collected events to retain in the aggregated payload
    /// when the batch releases.
    /// </summary>
    public required Retain Retain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Retain>("retain");
        }
        init { this._rawData.Set("retain", value); }
    }

    public required ApiEnum<string, Scope> Scope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Scope>>("scope");
        }
        init { this._rawData.Set("scope", value); }
    }

    public required ApiEnum<string, JourneyBatchNodeType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneyBatchNodeType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// ISO 8601 duration. Quiet window that releases the batch when it elapses with
    /// no new contributing events. Must be less than `max_wait_period`.
    /// </summary>
    public required string WaitPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("wait_period");
        }
        init { this._rawData.Set("wait_period", value); }
    }

    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Optional partition key. Events with the same `category_key` are batched together;
    /// events with different values are batched separately.
    /// </summary>
    public string? CategoryKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("category_key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("category_key", value);
        }
    }

    /// <summary>
    /// Condition spec for a journey node. Accepts a single condition atom, an AND/OR
    /// group, or an AND/OR nested group. Omit the `conditions` property entirely
    /// to express "no conditions".
    /// </summary>
    public JourneyConditionsField? Conditions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JourneyConditionsField>("conditions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("conditions", value);
        }
    }

    /// <summary>
    /// Releases the batch once this many events have been collected.
    /// </summary>
    public long? MaxItems
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("max_items", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MaxWaitPeriod;
        this.Retain.Validate();
        this.Scope.Validate();
        this.Type.Validate();
        _ = this.WaitPeriod;
        _ = this.ID;
        _ = this.CategoryKey;
        this.Conditions?.Validate();
        _ = this.MaxItems;
    }

    public JourneyBatchNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyBatchNode(JourneyBatchNode journeyBatchNode)
        : base(journeyBatchNode) { }
#pragma warning restore CS8618

    public JourneyBatchNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyBatchNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyBatchNodeFromRaw.FromRawUnchecked"/>
    public static JourneyBatchNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyBatchNodeFromRaw : IFromRawJson<JourneyBatchNode>
{
    /// <inheritdoc/>
    public JourneyBatchNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JourneyBatchNode.FromRawUnchecked(rawData);
}

/// <summary>
/// How to select which collected events to retain in the aggregated payload when
/// the batch releases.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Retain, RetainFromRaw>))]
public sealed record class Retain : JsonModel
{
    public required long Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    public required ApiEnum<string, RetainType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RetainType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Dot-path into the event payload (e.g. `data.priority`). Required when `type`
    /// is `highest` or `lowest`.
    /// </summary>
    public string? SortKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sort_key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sort_key", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        this.Type.Validate();
        _ = this.SortKey;
    }

    public Retain() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Retain(Retain retain)
        : base(retain) { }
#pragma warning restore CS8618

    public Retain(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Retain(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RetainFromRaw.FromRawUnchecked"/>
    public static Retain FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RetainFromRaw : IFromRawJson<Retain>
{
    /// <inheritdoc/>
    public Retain FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Retain.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RetainTypeConverter))]
public enum RetainType
{
    First,
    Last,
    Highest,
    Lowest,
}

sealed class RetainTypeConverter : JsonConverter<RetainType>
{
    public override RetainType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "first" => RetainType.First,
            "last" => RetainType.Last,
            "highest" => RetainType.Highest,
            "lowest" => RetainType.Lowest,
            _ => (RetainType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RetainType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RetainType.First => "first",
                RetainType.Last => "last",
                RetainType.Highest => "highest",
                RetainType.Lowest => "lowest",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ScopeConverter))]
public enum Scope
{
    User,
}

sealed class ScopeConverter : JsonConverter<Scope>
{
    public override Scope Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => Scope.User,
            _ => (Scope)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Scope value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Scope.User => "user",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JourneyBatchNodeTypeConverter))]
public enum JourneyBatchNodeType
{
    Batch,
}

sealed class JourneyBatchNodeTypeConverter : JsonConverter<JourneyBatchNodeType>
{
    public override JourneyBatchNodeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "batch" => JourneyBatchNodeType.Batch,
            _ => (JourneyBatchNodeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyBatchNodeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyBatchNodeType.Batch => "batch",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Add the current event to a digest keyed by the given subscription topic. The
/// digest accumulates events and releases them on the schedule configured for the topic.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JourneyAddToDigestNode, JourneyAddToDigestNodeFromRaw>))]
public sealed record class JourneyAddToDigestNode : JsonModel
{
    /// <summary>
    /// The subscription topic that owns the digest the event is added to.
    /// </summary>
    public required string SubscriptionTopicID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subscription_topic_id");
        }
        init { this._rawData.Set("subscription_topic_id", value); }
    }

    public required ApiEnum<string, JourneyAddToDigestNodeType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneyAddToDigestNodeType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Condition spec for a journey node. Accepts a single condition atom, an AND/OR
    /// group, or an AND/OR nested group. Omit the `conditions` property entirely
    /// to express "no conditions".
    /// </summary>
    public JourneyConditionsField? Conditions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JourneyConditionsField>("conditions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("conditions", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SubscriptionTopicID;
        this.Type.Validate();
        _ = this.ID;
        this.Conditions?.Validate();
    }

    public JourneyAddToDigestNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyAddToDigestNode(JourneyAddToDigestNode journeyAddToDigestNode)
        : base(journeyAddToDigestNode) { }
#pragma warning restore CS8618

    public JourneyAddToDigestNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyAddToDigestNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyAddToDigestNodeFromRaw.FromRawUnchecked"/>
    public static JourneyAddToDigestNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyAddToDigestNodeFromRaw : IFromRawJson<JourneyAddToDigestNode>
{
    /// <inheritdoc/>
    public JourneyAddToDigestNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyAddToDigestNode.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JourneyAddToDigestNodeTypeConverter))]
public enum JourneyAddToDigestNodeType
{
    AddToDigest,
}

sealed class JourneyAddToDigestNodeTypeConverter : JsonConverter<JourneyAddToDigestNodeType>
{
    public override JourneyAddToDigestNodeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "add-to-digest" => JourneyAddToDigestNodeType.AddToDigest,
            _ => (JourneyAddToDigestNodeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyAddToDigestNodeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyAddToDigestNodeType.AddToDigest => "add-to-digest",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Branch node. Routes to the first entry in `paths[]` whose `conditions` match,
/// else falls through to `default.nodes`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JourneyBranchNode, JourneyBranchNodeFromRaw>))]
public sealed record class JourneyBranchNode : JsonModel
{
    public required Default Default
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Default>("default");
        }
        init { this._rawData.Set("default", value); }
    }

    public required IReadOnlyList<Path> Paths
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Path>>("paths");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Path>>(
                "paths",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, JourneyBranchNodeType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneyBranchNodeType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Default.Validate();
        foreach (var item in this.Paths)
        {
            item.Validate();
        }
        this.Type.Validate();
        _ = this.ID;
    }

    public JourneyBranchNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyBranchNode(JourneyBranchNode journeyBranchNode)
        : base(journeyBranchNode) { }
#pragma warning restore CS8618

    public JourneyBranchNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyBranchNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyBranchNodeFromRaw.FromRawUnchecked"/>
    public static JourneyBranchNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyBranchNodeFromRaw : IFromRawJson<JourneyBranchNode>
{
    /// <inheritdoc/>
    public JourneyBranchNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JourneyBranchNode.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Default, DefaultFromRaw>))]
public sealed record class Default : JsonModel
{
    public required IReadOnlyList<JourneyNode> Nodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JourneyNode>>("nodes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<JourneyNode>>(
                "nodes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("label");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("label", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Nodes)
        {
            item.Validate();
        }
        _ = this.Label;
    }

    public Default() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Default(Default default_)
        : base(default_) { }
#pragma warning restore CS8618

    public Default(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Default(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DefaultFromRaw.FromRawUnchecked"/>
    public static Default FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Default(IReadOnlyList<JourneyNode> nodes)
        : this()
    {
        this.Nodes = nodes;
    }
}

class DefaultFromRaw : IFromRawJson<Default>
{
    /// <inheritdoc/>
    public Default FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Default.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Path, PathFromRaw>))]
public sealed record class Path : JsonModel
{
    /// <summary>
    /// Condition spec for a journey node. Accepts a single condition atom, an AND/OR
    /// group, or an AND/OR nested group. Omit the `conditions` property entirely
    /// to express "no conditions".
    /// </summary>
    public required JourneyConditionsField Conditions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<JourneyConditionsField>("conditions");
        }
        init { this._rawData.Set("conditions", value); }
    }

    public required IReadOnlyList<JourneyNode> Nodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JourneyNode>>("nodes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<JourneyNode>>(
                "nodes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("label");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("label", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Conditions.Validate();
        foreach (var item in this.Nodes)
        {
            item.Validate();
        }
        _ = this.Label;
    }

    public Path() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Path(Path path)
        : base(path) { }
#pragma warning restore CS8618

    public Path(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Path(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PathFromRaw.FromRawUnchecked"/>
    public static Path FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PathFromRaw : IFromRawJson<Path>
{
    /// <inheritdoc/>
    public Path FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Path.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JourneyBranchNodeTypeConverter))]
public enum JourneyBranchNodeType
{
    Branch,
}

sealed class JourneyBranchNodeTypeConverter : JsonConverter<JourneyBranchNodeType>
{
    public override JourneyBranchNodeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "branch" => JourneyBranchNodeType.Branch,
            _ => (JourneyBranchNodeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyBranchNodeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyBranchNodeType.Branch => "branch",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
