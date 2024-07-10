using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

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
