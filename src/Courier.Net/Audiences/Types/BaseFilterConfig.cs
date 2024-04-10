using System.Text.Json.Serialization;
using OneOf;
using Courier.Net;

namespace Courier.Net;

public class BaseFilterConfig
{
    /// <summary>
    /// The operator to use for filtering
    /// </summary>
    [JsonPropertyName("operator")]
    public OneOf<ComparisonOperator, LogicalOperator> Operator { get; init; }
}
