using System.Text.Json.Serialization;
using OneOf;
using Courier.Net;
using System;
using Courier.Net.Utilities;

namespace Courier.Net;

public class NestedFilterConfig
{
    [JsonPropertyName("rules")]
    public List<OneOf<SingleFilterConfig, NestedFilterConfig>> Rules { get; init; }

    /// <summary>
    /// The operator to use for filtering
    /// </summary>
    [JsonPropertyName("operator")JsonConverter(typeof(OneOfJsonConverter))]
    public OneOf<ComparisonOperator, LogicalOperator> Operator { get; init; }
}
