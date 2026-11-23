using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models;

[JsonConverter(typeof(JsonModelConverter<ElementalContent, ElementalContentFromRaw>))]
public sealed record class ElementalContent : JsonModel
{
    public required IReadOnlyList<ElementalNode> Elements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ElementalNode>>("elements");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ElementalNode>>(
                "elements",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// For example, "2022-01-01"
    /// </summary>
    public required string Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("version");
        }
        init { this._rawData.Set("version", value); }
    }

    /// <summary>
    /// How template variables read the data sent with the message. Under `strict`,
    /// data fields are read only through the `data.` prefix, as in `{{data.name}}`.
    /// Under `default`, `data` is spread onto the root, so `{{name}}` resolves and
    /// `{{data.name}}` renders as an empty string. Templates saved in Design Studio
    /// are `strict`. When omitted, the content is `default`. A write that replaces
    /// a template's content resets it to `default` unless the request sends `scope` again.
    /// </summary>
    public ApiEnum<string, Scope>? Scope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Scope>>("scope");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("scope", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Elements)
        {
            item.Validate();
        }
        _ = this.Version;
        this.Scope?.Validate();
    }

    public ElementalContent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalContent(ElementalContent elementalContent)
        : base(elementalContent) { }
#pragma warning restore CS8618

    public ElementalContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalContentFromRaw.FromRawUnchecked"/>
    public static ElementalContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalContentFromRaw : IFromRawJson<ElementalContent>
{
    /// <inheritdoc/>
    public ElementalContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ElementalContent.FromRawUnchecked(rawData);
}

/// <summary>
/// How template variables read the data sent with the message. Under `strict`, data
/// fields are read only through the `data.` prefix, as in `{{data.name}}`. Under
/// `default`, `data` is spread onto the root, so `{{name}}` resolves and `{{data.name}}`
/// renders as an empty string. Templates saved in Design Studio are `strict`. When
/// omitted, the content is `default`. A write that replaces a template's content
/// resets it to `default` unless the request sends `scope` again.
/// </summary>
[JsonConverter(typeof(ScopeConverter))]
public enum Scope
{
    Default,
    Strict,
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
            "default" => Scope.Default,
            "strict" => Scope.Strict,
            _ => (Scope)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Scope value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Scope.Default => "default",
                Scope.Strict => "strict",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
