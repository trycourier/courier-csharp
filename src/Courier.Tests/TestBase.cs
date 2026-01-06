using System;
using Courier;

namespace Courier.Tests;

public class TestBase
{
    protected ICourierClient client;

    public TestBase()
    {
        client = new CourierClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            ApiKey = "My API Key",
        };
    }
}
