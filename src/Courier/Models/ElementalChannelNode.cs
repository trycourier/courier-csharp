using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

/// <summary>
/// The channel element allows a notification to be customized based on which channel
/// it is sent through.  For example, you may want to display a detailed message when
/// the notification is sent through email,  and a more concise message in a push
/// notification. Channel elements are only valid as top-level  elements; you cannot
/// nest channel elements. If there is a channel element specified at the top-level
///  of the document, all sibling elements must be channel elements. Note: As an alternative,
/// most elements support a `channel` property. Which allows you to selectively  display
/// an individual element on a per channel basis. See the  [control flow docs](https://www.courier.com/docs/platform/content/elemental/control-flow/)
/// for more details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ElementalChannelNode, ElementalChannelNodeFromRaw>))]
public sealed record class ElementalChannelNode : JsonModel
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
    /// The channel the contents of this element should be applied to. Can be `email`,
    /// `push`, `direct_message`, `sms` or a provider such as slack
    /// </summary>
    public required string Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    /// <summary>
    /// Raw data to apply to the channel. If `elements` has not been specified, `raw`
    /// is required.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Raw
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("raw");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "raw",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public static implicit operator ElementalBaseNode(ElementalChannelNode elementalChannelNode) =>
        new()
        {
            Channels = elementalChannelNode.Channels,
            If = elementalChannelNode.If,
            Loop = elementalChannelNode.Loop,
            Ref = elementalChannelNode.Ref,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channels;
        _ = this.If;
        _ = this.Loop;
        _ = this.Ref;
        _ = this.Channel;
        _ = this.Raw;
    }

    public ElementalChannelNode() { }

    public ElementalChannelNode(ElementalChannelNode elementalChannelNode)
        : base(elementalChannelNode) { }

    public ElementalChannelNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalChannelNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalChannelNodeFromRaw.FromRawUnchecked"/>
    public static ElementalChannelNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ElementalChannelNode(string channel)
        : this()
    {
        this.Channel = channel;
    }
}

class ElementalChannelNodeFromRaw : IFromRawJson<ElementalChannelNode>
{
    /// <inheritdoc/>
    public ElementalChannelNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalChannelNode.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ElementalChannelNodeIntersectionMember1,
        ElementalChannelNodeIntersectionMember1FromRaw
    >)
)]
public sealed record class ElementalChannelNodeIntersectionMember1 : JsonModel
{
    /// <summary>
    /// The channel the contents of this element should be applied to. Can be `email`,
    /// `push`, `direct_message`, `sms` or a provider such as slack
    /// </summary>
    public required string Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    /// <summary>
    /// Raw data to apply to the channel. If `elements` has not been specified, `raw`
    /// is required.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Raw
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("raw");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "raw",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channel;
        _ = this.Raw;
    }

    public ElementalChannelNodeIntersectionMember1() { }

    public ElementalChannelNodeIntersectionMember1(
        ElementalChannelNodeIntersectionMember1 elementalChannelNodeIntersectionMember1
    )
        : base(elementalChannelNodeIntersectionMember1) { }

    public ElementalChannelNodeIntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalChannelNodeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalChannelNodeIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static ElementalChannelNodeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ElementalChannelNodeIntersectionMember1(string channel)
        : this()
    {
        this.Channel = channel;
    }
}

class ElementalChannelNodeIntersectionMember1FromRaw
    : IFromRawJson<ElementalChannelNodeIntersectionMember1>
{
    /// <inheritdoc/>
    public ElementalChannelNodeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalChannelNodeIntersectionMember1.FromRawUnchecked(rawData);
}
