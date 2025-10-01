using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.Send.BaseMessageSendToProperties.ToProperties.AudienceRecipientProperties.FilterProperties;

[JsonConverter(typeof(PathConverter))]
public enum Path
{
    AccountID,
}

sealed class PathConverter : JsonConverter<Path>
{
    public override Path Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account_id" => Path.AccountID,
            _ => (Path)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Path value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Path.AccountID => "account_id",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
