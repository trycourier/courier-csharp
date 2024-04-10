using System.Runtime.Serialization;

namespace Courier.Net;

public enum RoutingMethod
{
    [EnumMember(Value = "all")]
    All,

    [EnumMember(Value = "single")]
    Single
}
