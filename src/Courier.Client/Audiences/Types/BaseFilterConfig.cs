using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;
using OneOf;

#nullable enable

namespace Courier.Client;

public record BaseFilterConfig
{
    /// <summary>
    /// The operator to use for filtering
    /// </summary>
    [JsonPropertyName("operator")]
    [JsonConverter(typeof(OneOfSerializer<OneOf<ComparisonOperator, LogicalOperator>>))]
    public required OneOf<ComparisonOperator, LogicalOperator> Operator { get; init; }
}
