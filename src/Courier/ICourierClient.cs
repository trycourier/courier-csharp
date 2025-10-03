using System;
using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Services.Send;

namespace Courier;

public interface ICourierClient
{
    HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    string APIKey { get; init; }

    ISendService Send { get; }

    Task<HttpResponse> Execute<T>(HttpRequest<T> request)
        where T : ParamsBase;
}
