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
        get { return JsonModel.GetNullableClass<string>(this.RawData, "content"); }
        init { JsonModel.Set(this._rawData, "content", value); }
    }

    public bool? InheritDefault
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "inheritDefault"); }
        init { JsonModel.Set(this._rawData, "inheritDefault", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailFooter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
