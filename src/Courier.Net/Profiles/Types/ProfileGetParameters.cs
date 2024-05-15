using System.Text.Json.Serialization;

namespace Courier.Net;

public class ProfileGetParameters
{
    [JsonPropertyName("recipientId")]
    public string RecipientId { get; init; }
}
