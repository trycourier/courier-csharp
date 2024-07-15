using System.Net.Http;
using System.Text.Json;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public class NotificationsClient
{
    private RawClient _client;

    public NotificationsClient(RawClient client)
    {
        _client = client;
    }

    public async Task<NotificationListResponse> ListAsync(NotificationListParams request)
    {
        var _query = new Dictionary<string, object>() { };
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = "/notifications",
                Query = _query
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<NotificationListResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    public async Task<NotificationGetContentResponse> GetContentAsync(string id)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = $"/notifications/{id}/content"
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<NotificationGetContentResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    public async Task<NotificationGetContentResponse> GetDraftContentAsync(string id)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = $"/notifications/{id}/draft/content"
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<NotificationGetContentResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    public async Task<SubmissionChecksGetResponse> GetSubmissionChecksAsync(
        string id,
        string submissionId
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = $"/notifications/{id}/{submissionId}/checks"
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<SubmissionChecksGetResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    public async Task<SubmissionChecksReplaceResponse> ReplaceSubmissionChecksAsync(
        string id,
        string submissionId,
        SubmissionChecksReplaceParams request
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Put,
                Path = $"/notifications/{id}/{submissionId}/checks",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<SubmissionChecksReplaceResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    public async Task CancelSubmissionAsync(string id, string submissionId)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Delete,
                Path = $"/notifications/{id}/{submissionId}/checks"
            }
        );
    }
}
