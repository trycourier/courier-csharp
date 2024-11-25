using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record PaymentRequired
{
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// A message describing the error that occurred.
    /// </summary>
    [JsonPropertyName("message")]
    public required string Message { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
