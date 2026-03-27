using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Notifications;

/// <summary>
/// A version entry for a notification template.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VersionNode, VersionNodeFromRaw>))]
public sealed record class VersionNode : JsonModel
{
    /// <summary>
    /// Epoch milliseconds when this version was created.
    /// </summary>
    public required long Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("created");
        }
        init { this._rawData.Set("created", value); }
    }

    /// <summary>
    /// User ID of the version creator.
    /// </summary>
    public required string Creator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creator");
        }
        init { this._rawData.Set("creator", value); }
    }

    /// <summary>
    /// Version identifier. One of "draft", "published:vNNN" (current published version),
    /// or "vNNN" (historical version).
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
    /// Whether the draft has unpublished changes. Only present on the draft version.
    /// </summary>
    public bool? HasChanges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("has_changes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("has_changes", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Created;
        _ = this.Creator;
        _ = this.Version;
        _ = this.HasChanges;
    }

    public VersionNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionNode(VersionNode versionNode)
        : base(versionNode) { }
#pragma warning restore CS8618

    public VersionNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionNodeFromRaw.FromRawUnchecked"/>
    public static VersionNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionNodeFromRaw : IFromRawJson<VersionNode>
{
    /// <inheritdoc/>
    public VersionNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VersionNode.FromRawUnchecked(rawData);
}
