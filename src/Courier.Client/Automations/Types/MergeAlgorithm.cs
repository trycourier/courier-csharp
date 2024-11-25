using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(EnumSerializer<MergeAlgorithm>))]
public enum MergeAlgorithm
{
    [EnumMember(Value = "replace")]
    Replace,

    [EnumMember(Value = "none")]
    None,

    [EnumMember(Value = "overwrite")]
    Overwrite,

    [EnumMember(Value = "soft-merge")]
    SoftMerge,
}
