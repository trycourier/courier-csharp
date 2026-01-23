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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Logo>("logo");
        }
        init { this._rawData.Set("logo", value); }
    }

    public string? BarColor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("barColor");
        }
        init { this._rawData.Set("barColor", value); }
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
        this.Logo.Validate();
        _ = this.BarColor;
        _ = this.InheritDefault;
    }

    public EmailHeader() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailHeader(EmailHeader emailHeader)
        : base(emailHeader) { }
#pragma warning restore CS8618

    public EmailHeader(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailHeader(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
