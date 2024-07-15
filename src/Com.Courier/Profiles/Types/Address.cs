using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record Address
{
    [JsonPropertyName("formatted")]
    public required string Formatted { get; init; }

    [JsonPropertyName("street_address")]
    public required string StreetAddress { get; init; }

    [JsonPropertyName("locality")]
    public required string Locality { get; init; }

    [JsonPropertyName("region")]
    public required string Region { get; init; }

    [JsonPropertyName("postal_code")]
    public required string PostalCode { get; init; }

    [JsonPropertyName("country")]
    public required string Country { get; init; }
}
