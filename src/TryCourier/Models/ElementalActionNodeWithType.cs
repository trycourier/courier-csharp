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
[JsonConverter(
    typeof(JsonModelConverter<ElementalActionNodeWithType, ElementalActionNodeWithTypeFromRaw>)
)]
public sealed record class ElementalActionNodeWithType : JsonModel
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
    /// How prominent the action should be. `button` is the default, `secondary` and
    /// `tertiary` are the other two button styles, and `link` renders as inline
    /// text rather than a button.
    ///
    /// <para>Each channel draws these as closely as its medium allows. Email fills
    /// `button`, outlines `secondary`, and underlines `tertiary`. The in-app Inbox
    /// fills `button`, outlines `secondary`, and draws `tertiary` as a solid button.
    /// Slack renders all three as Block Kit buttons, with `secondary` in Slack's
    /// `primary` style and `tertiary` in its `danger` style.</para>
    ///
    /// <para>`background_color` is the fill for `button`, and the border and label
    /// color for `secondary`. For `tertiary` it colors the underline and label in
    /// email and the fill in the Inbox. It does not apply to `link`. An Inbox theme
    /// that sets its own action colors takes precedence over the template.</para>
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

    public ApiEnum<string, global::TryCourier.Models.Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, global::TryCourier.Models.Type>>(
                "type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    public static implicit operator ElementalActionNode(
        ElementalActionNodeWithType elementalActionNodeWithType
    ) =>
        new()
        {
            Channels = elementalActionNodeWithType.Channels,
            If = elementalActionNodeWithType.If,
            Loop = elementalActionNodeWithType.Loop,
            Ref = elementalActionNodeWithType.Ref,
            Content = elementalActionNodeWithType.Content,
            Href = elementalActionNodeWithType.Href,
            ActionID = elementalActionNodeWithType.ActionID,
            Align = elementalActionNodeWithType.Align,
            BackgroundColor = elementalActionNodeWithType.BackgroundColor,
            BorderRadius = elementalActionNodeWithType.BorderRadius,
            BorderSize = elementalActionNodeWithType.BorderSize,
            DisableTracking = elementalActionNodeWithType.DisableTracking,
            FontSize = elementalActionNodeWithType.FontSize,
            Locales = elementalActionNodeWithType.Locales,
            Padding = elementalActionNodeWithType.Padding,
            Style = elementalActionNodeWithType.Style,
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
        this.Type?.Validate();
    }

    public ElementalActionNodeWithType() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalActionNodeWithType(ElementalActionNodeWithType elementalActionNodeWithType)
        : base(elementalActionNodeWithType) { }
#pragma warning restore CS8618

    public ElementalActionNodeWithType(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalActionNodeWithType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalActionNodeWithTypeFromRaw.FromRawUnchecked"/>
    public static ElementalActionNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalActionNodeWithTypeFromRaw : IFromRawJson<ElementalActionNodeWithType>
{
    /// <inheritdoc/>
    public ElementalActionNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalActionNodeWithType.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ElementalActionNodeWithTypeIntersectionMember1,
        ElementalActionNodeWithTypeIntersectionMember1FromRaw
    >)
)]
public sealed record class ElementalActionNodeWithTypeIntersectionMember1 : JsonModel
{
    public ApiEnum<string, global::TryCourier.Models.Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, global::TryCourier.Models.Type>>(
                "type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type?.Validate();
    }

    public ElementalActionNodeWithTypeIntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalActionNodeWithTypeIntersectionMember1(
        ElementalActionNodeWithTypeIntersectionMember1 elementalActionNodeWithTypeIntersectionMember1
    )
        : base(elementalActionNodeWithTypeIntersectionMember1) { }
#pragma warning restore CS8618

    public ElementalActionNodeWithTypeIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalActionNodeWithTypeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalActionNodeWithTypeIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static ElementalActionNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalActionNodeWithTypeIntersectionMember1FromRaw
    : IFromRawJson<ElementalActionNodeWithTypeIntersectionMember1>
{
    /// <inheritdoc/>
    public ElementalActionNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalActionNodeWithTypeIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Action,
}

sealed class TypeConverter : JsonConverter<global::TryCourier.Models.Type>
{
    public override global::TryCourier.Models.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "action" => global::TryCourier.Models.Type.Action,
            _ => (global::TryCourier.Models.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::TryCourier.Models.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::TryCourier.Models.Type.Action => "action",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
