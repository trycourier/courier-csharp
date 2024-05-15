using System.Runtime.Serialization;

namespace Courier.Net;

public enum LogicalOperator
{
    [EnumMember(Value = "AND")]
    And,

    [EnumMember(Value = "OR")]
    Or
}
