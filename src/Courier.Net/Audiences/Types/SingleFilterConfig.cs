using System.Text.Json.Serialization;
using System;
using Courier.Net.Utilities;
using OneOf;
using Courier.Net;

namespace Courier.Net;

public class SingleFilterConfig
{
    /// <summary>
    /// The value to use for filtering
    /// </summary>
    [JsonPropertyName("value")]
    public string Value { get; init; }

    /// <summary>
    /// The attribe name from profile whose value will be operated against the filter value
    /// </summary>
    [JsonPropertyName("path")]
    public string Path { get; init; }

    /// <summary>
    /// The operator to use for filtering
    /// </summary>
    [JsonPropertyName("operator")JsonConverter(typeof(OneOfJsonConverter))]
    public OneOf<ComparisonOperator, LogicalOperator> Operator { get; init; }
}
