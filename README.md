<!-- AUTO-GENERATED-OVERVIEW:START — Do not edit this section. It is synced from mintlify-docs. -->
# Courier C# SDK

The Courier C# SDK provides typed access to the Courier REST API from applications written in C#. It targets .NET Standard 2.0, uses async/await throughout, and returns strongly typed response objects.

## Installation

```bash
dotnet add package Courier
```

Requires .NET Standard 2.0 or later.

## Quick Start

```csharp
using Courier;
using Courier.Models;
using Courier.Models.Send;

CourierClient client = new();

var response = await client.Send.Message(new SendMessageParams
{
    Message = new()
    {
        To = new UserRecipient { Email = "you@example.com" },
        Content = new()
        {
            Title = "Hello from Courier!",
            Body = "Your first notification, sent with the C# SDK.",
        },
    },
});

Console.WriteLine(response.RequestId);
```

The client reads `COURIER_API_KEY` from your environment automatically. You can also set it explicitly: `new CourierClient { ApiKey = "your-key" }`.

## Documentation

Full documentation: **[courier.com/docs/sdk-libraries/csharp](https://www.courier.com/docs/sdk-libraries/csharp/)**

- [Quickstart](https://www.courier.com/docs/getting-started/quickstart/)
- [Send API](https://www.courier.com/docs/platform/sending/send-message/)
- [API Reference](https://www.courier.com/docs/reference/get-started/)
<!-- AUTO-GENERATED-OVERVIEW:END -->
