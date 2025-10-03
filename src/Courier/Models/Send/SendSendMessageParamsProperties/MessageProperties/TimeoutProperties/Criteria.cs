using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.TimeoutProperties;

[JsonConverter(typeof(CriteriaConverter))]
public enum Criteria
{
    NoEscalation,
    Delivered,
    Viewed,
    Engaged,
}

sealed class CriteriaConverter : JsonConverter<Criteria>
{
    public override Criteria Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "no-escalation" => Criteria.NoEscalation,
            "delivered" => Criteria.Delivered,
            "viewed" => Criteria.Viewed,
            "engaged" => Criteria.Engaged,
            _ => (Criteria)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Criteria value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Criteria.NoEscalation => "no-escalation",
                Criteria.Delivered => "delivered",
                Criteria.Viewed => "viewed",
                Criteria.Engaged => "engaged",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
