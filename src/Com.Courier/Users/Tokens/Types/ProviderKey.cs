using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier.Core;
using Com.Courier.Users;

#nullable enable

namespace Com.Courier.Users;

[JsonConverter(typeof(StringEnumSerializer<ProviderKey>))]
public enum ProviderKey
{
    [EnumMember(Value = "firebase-fcm")]
    FirebaseFcm,

    [EnumMember(Value = "apn")]
    Apn,

    [EnumMember(Value = "expo")]
    Expo,

    [EnumMember(Value = "onesignal")]
    Onesignal
}
