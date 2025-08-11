using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record RestoreListRequest
{
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
