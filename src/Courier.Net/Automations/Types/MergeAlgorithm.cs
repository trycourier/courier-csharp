using System.Runtime.Serialization;

namespace Courier.Net;

public enum MergeAlgorithm
{
    [EnumMember(Value = "replace")]
    Replace,

    [EnumMember(Value = "none")]
    None,

    [EnumMember(Value = "overwrite")]
    Overwrite,

    [EnumMember(Value = "soft-merge")]
    SoftMerge
}
