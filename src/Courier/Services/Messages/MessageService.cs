using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Messages;

namespace Courier.Services.Messages;

public sealed class MessageService : IMessageService
{
    readonly ICourierClient _client;

    public MessageService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<MessageRetrieveResponse> Retrieve(MessageRetrieveParams parameters)
    {
        HttpRequest<MessageRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<MessageRetrieveResponse>().ConfigureAwait(false);
    }

    public async Task<MessageListResponse> List(MessageListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<MessageListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<MessageListResponse>().ConfigureAwait(false);
    }

    public async Task<MessageDetails> Cancel(MessageCancelParams parameters)
    {
        HttpRequest<MessageCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<MessageDetails>().ConfigureAwait(false);
    }

    public async Task<MessageContentResponse> Content(MessageContentParams parameters)
    {
        HttpRequest<MessageContentParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<MessageContentResponse>().ConfigureAwait(false);
    }

    public async Task<MessageHistoryResponse> History(MessageHistoryParams parameters)
    {
        HttpRequest<MessageHistoryParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<MessageHistoryResponse>().ConfigureAwait(false);
    }
}
