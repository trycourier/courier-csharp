using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ListRecipientType
{
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
