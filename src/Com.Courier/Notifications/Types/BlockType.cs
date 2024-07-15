using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<BlockType>))]
public enum BlockType
{
    [EnumMember(Value = "action")]
    Action,

    [EnumMember(Value = "divider")]
    Divider,

    [EnumMember(Value = "image")]
    Image,

    [EnumMember(Value = "jsonnet")]
    Jsonnet,

    [EnumMember(Value = "list")]
    List,

    [EnumMember(Value = "markdown")]
    Markdown,

    [EnumMember(Value = "quote")]
    Quote,

    [EnumMember(Value = "template")]
    Template,

    [EnumMember(Value = "text")]
    Text
}
