using System.Runtime.Serialization;

namespace Courier.Net;

public enum IAlignment
{
    [EnumMember(Value = "center")]
    Center,

    [EnumMember(Value = "left")]
    Left,

    [EnumMember(Value = "right")]
    Right,

    [EnumMember(Value = "full")]
    Full
}
