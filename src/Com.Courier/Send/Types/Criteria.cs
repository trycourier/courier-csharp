using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<Criteria>))]
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
