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
/// `202 Accepted` body for `POST /journeys/cancel`, returning the submitted identifier.
/// When called with `cancelation_token`, returns `{ cancelation_token }`; when called
/// with `run_id`, returns `{ run_id, status }`.
/// </summary>
[JsonConverter(typeof(CancelJourneyResponseConverter))]
public record class CancelJourneyResponse : ModelBase
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

    public CancelJourneyResponse(TokenBranch value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CancelJourneyResponse(RunIDBranch value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CancelJourneyResponse(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TokenBranch"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTokenBranch(out var value)) {
    ///     // `value` is of type `TokenBranch`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTokenBranch([NotNullWhen(true)] out TokenBranch? value)
    {
        value = this.Value as TokenBranch;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RunIDBranch"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRunIDBranch(out var value)) {
    ///     // `value` is of type `RunIDBranch`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRunIDBranch([NotNullWhen(true)] out RunIDBranch? value)
    {
        value = this.Value as RunIDBranch;
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
    ///     (TokenBranch value) =&gt; {...},
    ///     (RunIDBranch value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<TokenBranch> tokenBranch,
        System::Action<RunIDBranch> runIDBranch
    )
    {
        switch (this.Value)
        {
            case TokenBranch value:
                tokenBranch(value);
                break;
            case RunIDBranch value:
                runIDBranch(value);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of CancelJourneyResponse"
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
    ///     (TokenBranch value) =&gt; {...},
    ///     (RunIDBranch value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<TokenBranch, T> tokenBranch,
        System::Func<RunIDBranch, T> runIDBranch
    )
    {
        return this.Value switch
        {
            TokenBranch value => tokenBranch(value),
            RunIDBranch value => runIDBranch(value),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of CancelJourneyResponse"
            ),
        };
    }

    public static implicit operator CancelJourneyResponse(TokenBranch value) => new(value);

    public static implicit operator CancelJourneyResponse(RunIDBranch value) => new(value);

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
                "Data did not match any variant of CancelJourneyResponse"
            );
        }
        this.Switch(
            (tokenBranch) => tokenBranch.Validate(),
            (runIDBranch) => runIDBranch.Validate()
        );
    }

    public virtual bool Equals(CancelJourneyResponse? other) =>
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
            TokenBranch _ => 0,
            RunIDBranch _ => 1,
            _ => -1,
        };
    }
}

sealed class CancelJourneyResponseConverter : JsonConverter<CancelJourneyResponse>
{
    public override CancelJourneyResponse? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<TokenBranch>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<RunIDBranch>(element, options);
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
        CancelJourneyResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<TokenBranch, TokenBranchFromRaw>))]
public sealed record class TokenBranch : JsonModel
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

    public TokenBranch() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TokenBranch(TokenBranch tokenBranch)
        : base(tokenBranch) { }
#pragma warning restore CS8618

    public TokenBranch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TokenBranch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TokenBranchFromRaw.FromRawUnchecked"/>
    public static TokenBranch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TokenBranch(string cancelationToken)
        : this()
    {
        this.CancelationToken = cancelationToken;
    }
}

class TokenBranchFromRaw : IFromRawJson<TokenBranch>
{
    /// <inheritdoc/>
    public TokenBranch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TokenBranch.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<RunIDBranch, RunIDBranchFromRaw>))]
public sealed record class RunIDBranch : JsonModel
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

    /// <summary>
    /// The run's resulting status. `CANCELED` when the run was active and has been
    /// canceled; `PROCESSED` or `ERROR` when the run had already finished and was
    /// left unchanged; `CANCELED` for an already-canceled run.
    /// </summary>
    public required string Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RunID;
        _ = this.Status;
    }

    public RunIDBranch() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RunIDBranch(RunIDBranch runIDBranch)
        : base(runIDBranch) { }
#pragma warning restore CS8618

    public RunIDBranch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RunIDBranch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RunIDBranchFromRaw.FromRawUnchecked"/>
    public static RunIDBranch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RunIDBranchFromRaw : IFromRawJson<RunIDBranch>
{
    /// <inheritdoc/>
    public RunIDBranch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RunIDBranch.FromRawUnchecked(rawData);
}
