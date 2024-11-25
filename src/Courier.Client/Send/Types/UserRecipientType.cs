using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record UserRecipientType
{
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
