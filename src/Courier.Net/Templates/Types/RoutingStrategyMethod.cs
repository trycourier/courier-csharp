using System.Runtime.Serialization;

namespace Courier.Net;

public enum RoutingStrategyMethod
{
    [EnumMember(Value = "all")]
    All,

    [EnumMember(Value = "single")]
    Single
}
