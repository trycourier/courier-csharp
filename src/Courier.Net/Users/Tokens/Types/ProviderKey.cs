using System.Runtime.Serialization;

namespace Courier.Net.Users;

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
