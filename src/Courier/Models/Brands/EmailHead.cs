using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(JsonModelConverter<EmailHead, EmailHeadFromRaw>))]
public sealed record class EmailHead : JsonModel
{
    public required bool InheritDefault
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("inheritDefault");
        }
        init { this._rawData.Set("inheritDefault", value); }
    }

    public string? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InheritDefault;
        _ = this.Content;
    }

    public EmailHead() { }

    public EmailHead(EmailHead emailHead)
        : base(emailHead) { }

    public EmailHead(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailHead(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmailHeadFromRaw.FromRawUnchecked"/>
    public static EmailHead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EmailHead(bool inheritDefault)
        : this()
    {
        this.InheritDefault = inheritDefault;
    }
}

class EmailHeadFromRaw : IFromRawJson<EmailHead>
{
    /// <inheritdoc/>
    public EmailHead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EmailHead.FromRawUnchecked(rawData);
}
