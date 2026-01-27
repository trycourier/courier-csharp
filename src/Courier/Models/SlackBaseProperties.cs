using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<SlackBaseProperties, SlackBasePropertiesFromRaw>))]
public sealed record class SlackBaseProperties : JsonModel
{
    public required string AccessToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("access_token");
        }
        init { this._rawData.Set("access_token", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccessToken;
    }

    public SlackBaseProperties() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SlackBaseProperties(SlackBaseProperties slackBaseProperties)
        : base(slackBaseProperties) { }
#pragma warning restore CS8618

    public SlackBaseProperties(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SlackBaseProperties(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SlackBasePropertiesFromRaw.FromRawUnchecked"/>
    public static SlackBaseProperties FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SlackBaseProperties(string accessToken)
        : this()
    {
        this.AccessToken = accessToken;
    }
}

class SlackBasePropertiesFromRaw : IFromRawJson<SlackBaseProperties>
{
    /// <inheritdoc/>
    public SlackBaseProperties FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SlackBaseProperties.FromRawUnchecked(rawData);
}
