using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Journeys;

/// <summary>
/// Request body for `POST /journeys/cancel`. Provide EXACTLY ONE of `cancelation_token`
/// (cancels every run associated with the token) or `run_id` (cancels a single tenant-scoped run).
/// </summary>
[JsonConverter(typeof(CancelJourneyRequestConverter))]
public record class CancelJourneyRequest : ModelBase
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

    public CancelJourneyRequest(ByCancelationToken value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CancelJourneyRequest(ByRunID value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CancelJourneyRequest(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ByCancelationToken"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickByCancelationToken(out var value)) {
    ///     // `value` is of type `ByCancelationToken`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickByCancelationToken([NotNullWhen(true)] out ByCancelationToken? value)
    {
        value = this.Value as ByCancelationToken;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ByRunID"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickByRunID(out var value)) {
    ///     // `value` is of type `ByRunID`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickByRunID([NotNullWhen(true)] out ByRunID? value)
    {
        value = this.Value as ByRunID;
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
    ///     (ByCancelationToken value) =&gt; {...},
    ///     (ByRunID value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ByCancelationToken> byCancelationToken,
        System::Action<ByRunID> byRunID
    )
    {
        switch (this.Value)
        {
            case ByCancelationToken value:
                byCancelationToken(value);
                break;
            case ByRunID value:
                byRunID(value);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of CancelJourneyRequest"
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
    ///     (ByCancelationToken value) =&gt; {...},
    ///     (ByRunID value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ByCancelationToken, T> byCancelationToken,
        System::Func<ByRunID, T> byRunID
    )
    {
        return this.Value switch
        {
            ByCancelationToken value => byCancelationToken(value),
            ByRunID value => byRunID(value),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of CancelJourneyRequest"
            ),
        };
    }

    public static implicit operator CancelJourneyRequest(ByCancelationToken value) => new(value);

    public static implicit operator CancelJourneyRequest(ByRunID value) => new(value);

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
            throw new CourierInvalidDataException(
                "Data did not match any variant of CancelJourneyRequest"
            );
        }
        this.Switch(
            (byCancelationToken) => byCancelationToken.Validate(),
            (byRunID) => byRunID.Validate()
        );
    }

    public virtual bool Equals(CancelJourneyRequest? other) =>
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
            ByCancelationToken _ => 0,
            ByRunID _ => 1,
            _ => -1,
        };
    }
}

sealed class CancelJourneyRequestConverter : JsonConverter<CancelJourneyRequest>
{
    public override CancelJourneyRequest? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ByCancelationToken>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<ByRunID>(element, options);
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
        CancelJourneyRequest value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<ByCancelationToken, ByCancelationTokenFromRaw>))]
public sealed record class ByCancelationToken : JsonModel
{
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
        _ = this.CancelationToken;
    }

    public ByCancelationToken() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ByCancelationToken(ByCancelationToken byCancelationToken)
        : base(byCancelationToken) { }
#pragma warning restore CS8618

    public ByCancelationToken(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ByCancelationToken(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ByCancelationTokenFromRaw.FromRawUnchecked"/>
    public static ByCancelationToken FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ByCancelationToken(string cancelationToken)
        : this()
    {
        this.CancelationToken = cancelationToken;
    }
}

class ByCancelationTokenFromRaw : IFromRawJson<ByCancelationToken>
{
    /// <inheritdoc/>
    public ByCancelationToken FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ByCancelationToken.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ByRunID, ByRunIDFromRaw>))]
public sealed record class ByRunID : JsonModel
{
    public required string RunID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("run_id");
        }
        init { this._rawData.Set("run_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RunID;
    }

    public ByRunID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ByRunID(ByRunID byRunID)
        : base(byRunID) { }
#pragma warning restore CS8618

    public ByRunID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ByRunID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ByRunIDFromRaw.FromRawUnchecked"/>
    public static ByRunID FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ByRunID(string runID)
        : this()
    {
        this.RunID = runID;
    }
}

class ByRunIDFromRaw : IFromRawJson<ByRunID>
{
    /// <inheritdoc/>
    public ByRunID FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ByRunID.FromRawUnchecked(rawData);
}
