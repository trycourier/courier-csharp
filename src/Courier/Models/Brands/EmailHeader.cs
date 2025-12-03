using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<EmailHeader, EmailHeaderFromRaw>))]
public sealed record class EmailHeader : ModelBase
{
    public required Logo Logo
    {
        get { return ModelBase.GetNotNullClass<Logo>(this.RawData, "logo"); }
        init { ModelBase.Set(this._rawData, "logo", value); }
    }

    public string? BarColor
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "barColor"); }
        init { ModelBase.Set(this._rawData, "barColor", value); }
    }

    public bool? InheritDefault
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "inheritDefault"); }
        init { ModelBase.Set(this._rawData, "inheritDefault", value); }
    }

    public override void Validate()
    {
        this.Logo.Validate();
        _ = this.BarColor;
        _ = this.InheritDefault;
    }

    public EmailHeader() { }

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

class EmailHeaderFromRaw : IFromRaw<EmailHeader>
{
    public EmailHeader FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EmailHeader.FromRawUnchecked(rawData);
}
