# Courier C# API Library

> [!NOTE]
> The Courier C# API Library is currently in **beta** and we're excited for you to experiment with it!
>
> This library has not yet been exhaustively tested in production environments and may be missing some features you'd expect in a stable release. As we continue development, there may be breaking changes that require updates to your code.
>
> **We'd love your feedback!** Please share any suggestions, bug reports, feature requests, or general thoughts by [filing an issue](https://www.github.com/trycourier/courier-csharp/issues/new).

The Courier C# SDK provides convenient access to the Courier REST API from applications written in C#.

It is generated with [Stainless](https://www.stainless.com/).

## Installation

```bash
git clone git@github.com:trycourier/courier-csharp.git
dotnet add reference courier-csharp/src/Courier
```

## Requirements

This library requires .NET 8 or later.

> [!NOTE]
> The library is currently in **beta**. The requirements will be lowered in the future.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```csharp
using System;
using System.Collections.Generic;
using System.Text.Json;
using Courier;
using Models = Courier.Models;
using Courier.Models.Send;

// Configured using the COURIER_API_KEY and COURIER_BASE_URL environment variables
CourierClient client = new();

SendMessageParams parameters = new()
{
    Message = new()
    {
        To = new(new Models::UserRecipient() { UserID = "your_user_id" }),
        Data = new Dictionary<string, JsonElement>()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") }
        },
    },
};

var response = await client.Send.Message(parameters);

Console.WriteLine(response);
```

## Client Configuration

Configure the client using environment variables:

```csharp
using Courier;

// Configured using the COURIER_API_KEY and COURIER_BASE_URL environment variables
CourierClient client = new();
```

Or manually:

```csharp
using Courier;

CourierClient client = new() { APIKey = "My API Key" };
```

Or using a combination of the two approaches.

See this table for the available options:

| Property  | Environment variable | Required | Default value               |
| --------- | -------------------- | -------- | --------------------------- |
| `APIKey`  | `COURIER_API_KEY`    | true     | -                           |
| `BaseUrl` | `COURIER_BASE_URL`   | true     | `"https://api.courier.com"` |

## Requests and responses

To send a request to the Courier API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.Send.Message` should be called with an instance of `SendMessageParams`, and it will return an instance of `Task<SendMessageResponse>`.

## Error handling

The SDK throws custom unchecked exception types:

- `CourierApiException`: Base class for API errors. See this table for which exception subclass is thrown for each HTTP status code:

| Status | Exception                              |
| ------ | -------------------------------------- |
| 400    | `CourierBadRequestException`           |
| 401    | `CourierUnauthorizedException`         |
| 403    | `CourierForbiddenException`            |
| 404    | `CourierNotFoundException`             |
| 422    | `CourierUnprocessableEntityException`  |
| 429    | `CourierRateLimitException`            |
| 5xx    | `Courier5xxException`                  |
| others | `CourierUnexpectedStatusCodeException` |

Additionally, all 4xx errors inherit from `Courier4xxException`.

false

- `CourierIOException`: I/O networking errors.

- `CourierInvalidDataException`: Failure to interpret successfully parsed data. For example, when accessing a property that's supposed to be required, but the API unexpectedly omitted it from the response.

- `CourierException`: Base class for all exceptions.

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/trycourier/courier-csharp/issues) with questions, bugs, or suggestions.
