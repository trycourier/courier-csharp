using System.Runtime.Serialization;

namespace Courier.Net.Users;

public enum PatchOp
{
    [EnumMember(Value = "replace")]
    Replace,

    [EnumMember(Value = "add")]
    Add,

    [EnumMember(Value = "remove")]
    Remove,

    [EnumMember(Value = "copy")]
    Copy,

    [EnumMember(Value = "move")]
    Move,

    [EnumMember(Value = "test")]
    Test
}
