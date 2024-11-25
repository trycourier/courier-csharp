using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ListTemplatesRequest
{
    /// <summary>
    /// A unique identifier that allows for fetching the next set of templates
    /// </summary>
    public string? Cursor { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
