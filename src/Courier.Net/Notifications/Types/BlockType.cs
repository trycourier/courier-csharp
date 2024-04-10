using System.Runtime.Serialization;

namespace Courier.Net;

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
