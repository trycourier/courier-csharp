using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<MergeAlgorithm>))]
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
