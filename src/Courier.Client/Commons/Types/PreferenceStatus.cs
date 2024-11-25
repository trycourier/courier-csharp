using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(EnumSerializer<PreferenceStatus>))]
public enum PreferenceStatus
{
    [EnumMember(Value = "OPTED_IN")]
    OptedIn,

    [EnumMember(Value = "OPTED_OUT")]
    OptedOut,

    [EnumMember(Value = "REQUIRED")]
    Required,
}
