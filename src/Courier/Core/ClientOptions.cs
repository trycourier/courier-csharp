using System;
using System.Net.Http;
using Courier.Exceptions;

namespace Courier.Core;

public struct ClientOptions()
{
    public HttpClient HttpClient { get; set; } = new();

    Lazy<Uri> _baseUrl = new(() =>
        new Uri(Environment.GetEnvironmentVariable("COURIER_BASE_URL") ?? "https://api.courier.com")
    );
    public Uri BaseUrl
    {
        readonly get { return _baseUrl.Value; }
        set { _baseUrl = new(() => value); }
    }

    Lazy<string> _apiKey = new(() =>
        Environment.GetEnvironmentVariable("COURIER_API_KEY")
        ?? throw new CourierInvalidDataException(
            string.Format("{0} cannot be null", nameof(APIKey)),
            new ArgumentNullException(nameof(APIKey))
        )
    );
    public string APIKey
    {
        readonly get { return _apiKey.Value; }
        set { _apiKey = new(() => value); }
    }
}
