using System.Text.Json.Serialization;

namespace Courier.Net;

public class Address
{
    [JsonPropertyName("formatted")]
    public string Formatted { get; init; }

    [JsonPropertyName("street_address")]
    public string StreetAddress { get; init; }

    [JsonPropertyName("locality")]
    public string Locality { get; init; }

    [JsonPropertyName("region")]
    public string Region { get; init; }

    [JsonPropertyName("postal_code")]
    public string PostalCode { get; init; }

    [JsonPropertyName("country")]
    public string Country { get; init; }
}
