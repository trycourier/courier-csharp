# Courier C# SDK

Courier is a notifications API for sending messages across email, SMS, push, in-app inbox, Slack, and WhatsApp from a single API call.

## Setup

```csharp
using Courier;

CourierClient client = new(); // reads COURIER_API_KEY from env
```

## Core pattern

```csharp
using Courier.Models;
using Courier.Models.Send;
using System.Text.Json;

var response = await client.Send.Message(new SendMessageParams
{
    Message = new()
    {
        To = new UserRecipient() { UserID = "user_123" },
        Template = "TEMPLATE_ID",
        Data = new Dictionary<string, JsonElement>()
        {
            { "order_id", JsonSerializer.SerializeToElement("456") }
        },
    },
});

Console.WriteLine(response.RequestId);
```

## Key rules

- Use `routing.method: "single"` (fallback chain) unless the user explicitly asks for parallel delivery (`"all"`).
- Use `client.Profiles.Create()` for partial profile updates (it merges). Use `client.Profiles.Replace()` only when fully replacing all profile data.
- Test and production use different API keys from the same workspace. Always confirm which environment before sending.
- For transactional sends (OTP, orders, billing), pass an `Idempotency-Key` header to prevent duplicates.
- Bulk sends are a 3-step flow: `client.Bulk.CreateJob()` → `client.Bulk.AddUsers()` → `client.Bulk.RunJob()`.
- `RequestId` from a single-recipient send doubles as the `message_id`. For multi-recipient sends, each recipient gets a unique `message_id`.
- All service methods return `Task<T>` and should be awaited.

## Concepts

- `Template` — notification template ID from the Courier dashboard
- `Routing.Method` — `"single"` = try channels in order until one succeeds; `"all"` = send on every channel simultaneously
- `TenantId` — multi-tenant context; affects brand and preference defaults for the message
- `ListId` — send to all subscribers of a named list
- `UserRecipient` — registered user whose profile has channel addresses
- Ad-hoc recipients: pass email or phone directly in the `To` field (no stored profile needed)

## More context

- Full docs index: https://www.courier.com/docs/llms.txt
- API reference: https://www.courier.com/docs/reference/get-started
- MCP server: https://mcp.courier.com
- Courier Skills (Cursor / Claude Code): https://github.com/trycourier/courier-skills
