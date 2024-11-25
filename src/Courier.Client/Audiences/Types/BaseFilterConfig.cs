using System.Text.Json.Serialization;
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
    public required OneOf<ComparisonOperator, LogicalOperator> Operator { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
