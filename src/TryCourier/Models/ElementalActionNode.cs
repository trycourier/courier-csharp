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

/// <summary>
/// Allows the user to execute an action. Can be a button or a link.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ElementalActionNode, ElementalActionNodeFromRaw>))]
public sealed record class ElementalActionNode : JsonModel
{
    public IReadOnlyList<string>? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("channels");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "channels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? If
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("if");
        }
        init { this._rawData.Set("if", value); }
    }

    public string? Loop
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("loop");
        }
        init { this._rawData.Set("loop", value); }
    }

    public string? Ref
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ref");
        }
        init { this._rawData.Set("ref", value); }
    }

    /// <summary>
    /// The text content of the action shown to the user.
    /// </summary>
    public required string Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// The target URL of the action.
    /// </summary>
    public required string Href
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("href");
        }
        init { this._rawData.Set("href", value); }
    }

    /// <summary>
    /// A unique id used to identify the action when it is executed.
    /// </summary>
    public string? ActionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("action_id");
        }
        init { this._rawData.Set("action_id", value); }
    }

    public ApiEnum<string, Alignment>? Align
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Alignment>>("align");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("align", value);
        }
    }

    /// <summary>
    /// The background color of the action button.
    /// </summary>
    public string? BackgroundColor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("background_color");
        }
        init { this._rawData.Set("background_color", value); }
    }

    /// <summary>
    /// CSS border-radius applied to the action button. For example, `4px`
    /// </summary>
    public string? BorderRadius
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("border_radius");
        }
        init { this._rawData.Set("border_radius", value); }
    }

    /// <summary>
    /// CSS border width applied to the action button. For example, `1px`
    /// </summary>
    public string? BorderSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("border_size");
        }
        init { this._rawData.Set("border_size", value); }
    }

    /// <summary>
    /// When true, the action's href is not rewritten for click-through tracking,
    /// even when click-through tracking is enabled for the workspace.
    /// </summary>
    public bool? DisableTracking
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("disable_tracking");
        }
        init { this._rawData.Set("disable_tracking", value); }
    }

    /// <summary>
    /// CSS font-size applied to the action button label. For example, `14px`
    /// </summary>
    public string? FontSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("font_size");
        }
        init { this._rawData.Set("font_size", value); }
    }

    /// <summary>
    /// Region specific content. See [locales docs](https://www.courier.com/docs/platform/content/elemental/locales/)
    /// for more details.
    /// </summary>
    public IReadOnlyDictionary<string, LocalesItem>? Locales
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, LocalesItem>>("locales");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, LocalesItem>?>(
                "locales",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// CSS padding applied to the action button. For example, `8px 16px`
    /// </summary>
    public string? Padding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("padding");
        }
        init { this._rawData.Set("padding", value); }
    }

    /// <summary>
    /// Defaults to `button`.
    /// </summary>
    public ApiEnum<string, Style>? Style
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Style>>("style");
        }
        init { this._rawData.Set("style", value); }
    }

    public static implicit operator ElementalBaseNode(ElementalActionNode elementalActionNode) =>
        new()
        {
            Channels = elementalActionNode.Channels,
            If = elementalActionNode.If,
            Loop = elementalActionNode.Loop,
            Ref = elementalActionNode.Ref,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channels;
        _ = this.If;
        _ = this.Loop;
        _ = this.Ref;
        _ = this.Content;
        _ = this.Href;
        _ = this.ActionID;
        this.Align?.Validate();
        _ = this.BackgroundColor;
        _ = this.BorderRadius;
        _ = this.BorderSize;
        _ = this.DisableTracking;
        _ = this.FontSize;
        if (this.Locales != null)
        {
            foreach (var item in this.Locales.Values)
            {
                item.Validate();
            }
        }
        _ = this.Padding;
        this.Style?.Validate();
    }

    public ElementalActionNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalActionNode(ElementalActionNode elementalActionNode)
        : base(elementalActionNode) { }
#pragma warning restore CS8618

    public ElementalActionNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalActionNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalActionNodeFromRaw.FromRawUnchecked"/>
    public static ElementalActionNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalActionNodeFromRaw : IFromRawJson<ElementalActionNode>
{
    /// <inheritdoc/>
    public ElementalActionNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ElementalActionNode.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<IntersectionMember1, IntersectionMember1FromRaw>))]
public sealed record class IntersectionMember1 : JsonModel
{
    /// <summary>
    /// The text content of the action shown to the user.
    /// </summary>
    public required string Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// The target URL of the action.
    /// </summary>
    public required string Href
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("href");
        }
        init { this._rawData.Set("href", value); }
    }

    /// <summary>
    /// A unique id used to identify the action when it is executed.
    /// </summary>
    public string? ActionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("action_id");
        }
        init { this._rawData.Set("action_id", value); }
    }

    /// <summary>
    /// The alignment of the action button. Defaults to "center".
    /// </summary>
    public ApiEnum<string, Alignment>? Align
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Alignment>>("align");
        }
        init { this._rawData.Set("align", value); }
    }

    /// <summary>
    /// The background color of the action button.
    /// </summary>
    public string? BackgroundColor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("background_color");
        }
        init { this._rawData.Set("background_color", value); }
    }

    /// <summary>
    /// CSS border-radius applied to the action button. For example, `4px`
    /// </summary>
    public string? BorderRadius
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("border_radius");
        }
        init { this._rawData.Set("border_radius", value); }
    }

    /// <summary>
    /// CSS border width applied to the action button. For example, `1px`
    /// </summary>
    public string? BorderSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("border_size");
        }
        init { this._rawData.Set("border_size", value); }
    }

    /// <summary>
    /// When true, the action's href is not rewritten for click-through tracking,
    /// even when click-through tracking is enabled for the workspace.
    /// </summary>
    public bool? DisableTracking
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("disable_tracking");
        }
        init { this._rawData.Set("disable_tracking", value); }
    }

    /// <summary>
    /// CSS font-size applied to the action button label. For example, `14px`
    /// </summary>
    public string? FontSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("font_size");
        }
        init { this._rawData.Set("font_size", value); }
    }

    /// <summary>
    /// Region specific content. See [locales docs](https://www.courier.com/docs/platform/content/elemental/locales/)
    /// for more details.
    /// </summary>
    public IReadOnlyDictionary<string, LocalesItem>? Locales
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, LocalesItem>>("locales");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, LocalesItem>?>(
                "locales",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// CSS padding applied to the action button. For example, `8px 16px`
    /// </summary>
    public string? Padding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("padding");
        }
        init { this._rawData.Set("padding", value); }
    }

    /// <summary>
    /// Defaults to `button`.
    /// </summary>
    public ApiEnum<string, Style>? Style
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Style>>("style");
        }
        init { this._rawData.Set("style", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        _ = this.Href;
        _ = this.ActionID;
        this.Align?.Validate();
        _ = this.BackgroundColor;
        _ = this.BorderRadius;
        _ = this.BorderSize;
        _ = this.DisableTracking;
        _ = this.FontSize;
        if (this.Locales != null)
        {
            foreach (var item in this.Locales.Values)
            {
                item.Validate();
            }
        }
        _ = this.Padding;
        this.Style?.Validate();
    }

    public IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntersectionMember1(IntersectionMember1 intersectionMember1)
        : base(intersectionMember1) { }
#pragma warning restore CS8618

    public IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntersectionMember1FromRaw : IFromRawJson<IntersectionMember1>
{
    /// <inheritdoc/>
    public IntersectionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// Defaults to `button`.
/// </summary>
[JsonConverter(typeof(StyleConverter))]
public enum Style
{
    Button,
    Link,
}

sealed class StyleConverter : JsonConverter<Style>
{
    public override Style Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "button" => Style.Button,
            "link" => Style.Link,
            _ => (Style)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Style value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Style.Button => "button",
                Style.Link => "link",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
