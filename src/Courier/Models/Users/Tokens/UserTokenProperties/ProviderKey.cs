using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.Users.Tokens.UserTokenProperties;

[JsonConverter(typeof(ProviderKeyConverter))]
public enum ProviderKey
{
    FirebaseFcm,
    Apn,
    Expo,
    Onesignal,
}

sealed class ProviderKeyConverter : JsonConverter<ProviderKey>
{
    public override ProviderKey Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "firebase-fcm" => ProviderKey.FirebaseFcm,
            "apn" => ProviderKey.Apn,
            "expo" => ProviderKey.Expo,
            "onesignal" => ProviderKey.Onesignal,
            _ => (ProviderKey)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProviderKey value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProviderKey.FirebaseFcm => "firebase-fcm",
                ProviderKey.Apn => "apn",
                ProviderKey.Expo => "expo",
                ProviderKey.Onesignal => "onesignal",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
