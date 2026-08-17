using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models;

/// <summary>
/// Routes a push notification through the AWS SNS provider. The target ARN must be
/// nested under `aws_sns` — a top-level `target_arn` on the profile is ignored by
/// the provider.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AwsSns, AwsSnsFromRaw>))]
public sealed record class AwsSns : JsonModel
{
    /// <summary>
    /// The ARN of the SNS platform endpoint, topic, or application to publish to.
    /// </summary>
    public required string TargetArn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("target_arn");
        }
        init { this._rawData.Set("target_arn", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TargetArn;
    }

    public AwsSns() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AwsSns(AwsSns awsSns)
        : base(awsSns) { }
#pragma warning restore CS8618

    public AwsSns(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AwsSns(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AwsSnsFromRaw.FromRawUnchecked"/>
    public static AwsSns FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AwsSns(string targetArn)
        : this()
    {
        this.TargetArn = targetArn;
    }
}

class AwsSnsFromRaw : IFromRawJson<AwsSns>
{
    /// <inheritdoc/>
    public AwsSns FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AwsSns.FromRawUnchecked(rawData);
}
