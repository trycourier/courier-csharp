using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(EnumSerializer<Criteria>))]
public enum Criteria
{
    [EnumMember(Value = "no-escalation")]
    NoEscalation,

    [EnumMember(Value = "delivered")]
    Delivered,

    [EnumMember(Value = "viewed")]
    Viewed,

    [EnumMember(Value = "engaged")]
    Engaged,
}
