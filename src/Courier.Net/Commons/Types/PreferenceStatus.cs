using System.Runtime.Serialization;

namespace Courier.Net;

public enum PreferenceStatus
{
    [EnumMember(Value = "OPTED_IN")]
    OptedIn,

    [EnumMember(Value = "OPTED_OUT")]
    OptedOut,

    [EnumMember(Value = "REQUIRED")]
    Required
}
