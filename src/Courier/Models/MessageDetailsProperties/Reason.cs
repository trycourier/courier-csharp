using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.MessageDetailsProperties;

/// <summary>
/// The reason for the current status of the message.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    Bounced,
    Failed,
    Filtered,
    NoChannels,
    NoProviders,
    OptInRequired,
    ProviderError,
    Unpublished,
    Unsubscribed,
}

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BOUNCED" => Reason.Bounced,
            "FAILED" => Reason.Failed,
            "FILTERED" => Reason.Filtered,
            "NO_CHANNELS" => Reason.NoChannels,
            "NO_PROVIDERS" => Reason.NoProviders,
            "OPT_IN_REQUIRED" => Reason.OptInRequired,
            "PROVIDER_ERROR" => Reason.ProviderError,
            "UNPUBLISHED" => Reason.Unpublished,
            "UNSUBSCRIBED" => Reason.Unsubscribed,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.Bounced => "BOUNCED",
                Reason.Failed => "FAILED",
                Reason.Filtered => "FILTERED",
                Reason.NoChannels => "NO_CHANNELS",
                Reason.NoProviders => "NO_PROVIDERS",
                Reason.OptInRequired => "OPT_IN_REQUIRED",
                Reason.ProviderError => "PROVIDER_ERROR",
                Reason.Unpublished => "UNPUBLISHED",
                Reason.Unsubscribed => "UNSUBSCRIBED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
