using System.Runtime.Serialization;

namespace Courier.Net;

public enum Criteria
{
    [EnumMember(Value = "no-escalation")]
    NoEscalation,

    [EnumMember(Value = "delivered")]
    Delivered,

    [EnumMember(Value = "viewed")]
    Viewed,

    [EnumMember(Value = "engaged")]
    Engaged
}
