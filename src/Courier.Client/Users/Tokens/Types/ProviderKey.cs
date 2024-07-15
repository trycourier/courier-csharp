using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;
using Courier.Client.Users;

#nullable enable

namespace Courier.Client.Users;

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
