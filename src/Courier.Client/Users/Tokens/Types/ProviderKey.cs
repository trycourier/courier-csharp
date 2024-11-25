using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client.Users;

[JsonConverter(typeof(EnumSerializer<ProviderKey>))]
public enum ProviderKey
{
    [EnumMember(Value = "firebase-fcm")]
    FirebaseFcm,

    [EnumMember(Value = "apn")]
    Apn,

    [EnumMember(Value = "expo")]
    Expo,

    [EnumMember(Value = "onesignal")]
    Onesignal,
}
