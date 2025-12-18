using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(JsonModelConverter<EmailHeader, EmailHeaderFromRaw>))]
public sealed record class EmailHeader : JsonModel
{
    public required Logo Logo
    {
        get { return JsonModel.GetNotNullClass<Logo>(this.RawData, "logo"); }
        init { JsonModel.Set(this._rawData, "logo", value); }
    }

    public string? BarColor
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "barColor"); }
        init { JsonModel.Set(this._rawData, "barColor", value); }
    }

    public bool? InheritDefault
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "inheritDefault"); }
        init { JsonModel.Set(this._rawData, "inheritDefault", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Logo.Validate();
        _ = this.BarColor;
        _ = this.InheritDefault;
    }

    public EmailHeader() { }

    public EmailHeader(EmailHeader emailHeader)
        : base(emailHeader) { }

    public EmailHeader(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailHeader(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmailHeaderFromRaw.FromRawUnchecked"/>
    public static EmailHeader FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EmailHeader(Logo logo)
        : this()
    {
        this.Logo = logo;
    }
}

class EmailHeaderFromRaw : IFromRawJson<EmailHeader>
{
    /// <inheritdoc/>
    public EmailHeader FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EmailHeader.FromRawUnchecked(rawData);
}
