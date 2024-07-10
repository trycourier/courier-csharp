using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Net.Core;
using Courier.Net.Users;

#nullable enable

namespace Courier.Net.Users;

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
