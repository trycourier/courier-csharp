using System.Runtime.Serialization;

namespace Courier.Net;

public enum InAppPlacement
{
    [EnumMember(Value = "top")]
    Top,

    [EnumMember(Value = "bottom")]
    Bottom,

    [EnumMember(Value = "left")]
    Left,

    [EnumMember(Value = "right")]
    Right
}
