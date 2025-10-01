using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.Bulk.UserRecipientProperties.PreferencesProperties.CategoriesProperties.CategoriesItemProperties;

[JsonConverter(typeof(SourceConverter))]
public enum Source
{
    Subscription,
    List,
    Recipient,
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "subscription" => Source.Subscription,
            "list" => Source.List,
            "recipient" => Source.Recipient,
            _ => (Source)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Source.Subscription => "subscription",
                Source.List => "list",
                Source.Recipient => "recipient",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
