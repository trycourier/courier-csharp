# Courier C# SDK

The Courier C# SDK provides typed access to the Courier REST API from .NET applications. Use it to send notifications, manage user profiles, check message status, issue JWT tokens for client-side SDKs, and more.

## Installation

```bash
dotnet add package TryCourier
```

Available on [NuGet](https://www.nuget.org/packages/TryCourier). Targets .NET 8 and .NET Framework 4.7.2.

## Quick Start

```csharp
using System;
using System.Collections.Generic;
using System.Text.Json;
using TryCourier;
using TryCourier.Models;
using TryCourier.Models.Send;

CourierClient client = new();

SendMessageParams parameters = new()
{
    Message = new()
    {
        To = new UserRecipient() { UserID = "your_user_id" },
        Template = "your_template_id",
        Data = new Dictionary<string, JsonElement>()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") }
        },
    },
};

SendMessageResponse response = await client.Send.Message(parameters);
Console.WriteLine(response.RequestID);
```

The client reads `COURIER_API_KEY` from your environment automatically.

## Documentation

Full documentation: **[courier.com/docs/sdk-libraries/csharp](https://www.courier.com/docs/sdk-libraries/csharp/)**

- [Quickstart](https://www.courier.com/docs/getting-started/quickstart/)
- [Send API](https://www.courier.com/docs/platform/sending/send-message/)
- [API Reference](https://www.courier.com/docs/reference/get-started/)
