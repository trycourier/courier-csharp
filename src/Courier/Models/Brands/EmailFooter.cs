using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<EmailFooter, EmailFooterFromRaw>))]
public sealed record class EmailFooter : ModelBase
{
    public string? Content
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "content"); }
        init { ModelBase.Set(this._rawData, "content", value); }
    }

    public bool? InheritDefault
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "inheritDefault"); }
        init { ModelBase.Set(this._rawData, "inheritDefault", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        _ = this.InheritDefault;
    }

    public EmailFooter() { }

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

class EmailFooterFromRaw : IFromRaw<EmailFooter>
{
    /// <inheritdoc/>
    public EmailFooter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EmailFooter.FromRawUnchecked(rawData);
}
