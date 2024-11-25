using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record Address
{
    [JsonPropertyName("formatted")]
    public required string Formatted { get; set; }

    [JsonPropertyName("street_address")]
    public required string StreetAddress { get; set; }

    [JsonPropertyName("locality")]
    public required string Locality { get; set; }

    [JsonPropertyName("region")]
    public required string Region { get; set; }

    [JsonPropertyName("postal_code")]
    public required string PostalCode { get; set; }

    [JsonPropertyName("country")]
    public required string Country { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
