using System.Runtime.Serialization;

namespace Courier.Net;

public enum AutomationFetchDataWebhookMethod
{
    [EnumMember(Value = "GET")]
    Get,

    [EnumMember(Value = "POST")]
    Post
}
