using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record RestoreListRequest
{
    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
