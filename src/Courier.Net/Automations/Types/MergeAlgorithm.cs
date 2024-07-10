using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

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
