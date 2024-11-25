using System.Text.Json.Serialization;
using Courier.Client.Core;
using OneOf;

#nullable enable

namespace Courier.Client;

public record SingleFilterConfig
{
    /// <summary>
    /// The value to use for filtering
    /// </summary>
    [JsonPropertyName("value")]
    public required string Value { get; set; }

    /// <summary>
    /// The attribe name from profile whose value will be operated against the filter value
    /// </summary>
    [JsonPropertyName("path")]
    public required string Path { get; set; }

    /// <summary>
    /// The operator to use for filtering
    /// </summary>
    [JsonPropertyName("operator")]
    public required OneOf<ComparisonOperator, LogicalOperator> Operator { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
