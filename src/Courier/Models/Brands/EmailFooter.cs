using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(JsonModelConverter<EmailFooter, EmailFooterFromRaw>))]
public sealed record class EmailFooter : JsonModel
{
    public string? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public bool? InheritDefault
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inheritDefault");
        }
        init { this._rawData.Set("inheritDefault", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        _ = this.InheritDefault;
    }

    public EmailFooter() { }

    public EmailFooter(EmailFooter emailFooter)
        : base(emailFooter) { }

    public EmailFooter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailFooter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmailFooterFromRaw.FromRawUnchecked"/>
    public static EmailFooter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmailFooterFromRaw : IFromRawJson<EmailFooter>
{
    /// <inheritdoc/>
    public EmailFooter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EmailFooter.FromRawUnchecked(rawData);
}
