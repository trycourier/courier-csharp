# Reference
<details><summary><code>client.<a href="/src/Courier.Client/Courier.cs">SendAsync</a>(SendMessageRequest { ... }) -> SendMessageResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Use the send API to send a message to one or more recipients.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SendAsync(
    new SendMessageRequest
    {
        Message = new ContentMessage
        {
            Content = new ElementalContent
            {
                Version = "version",
                Brand = null,
                Elements = new List<object>()
                {
                    new ElementalTextNode
                    {
                        Content = "content",
                        Align = TextAlign.Left,
                        TextStyle = null,
                        Color = null,
                        Bold = null,
                        Italic = null,
                        Strikethrough = null,
                        Underline = null,
                        Locales = null,
                        Format = null,
                    },
                    new ElementalTextNode
                    {
                        Content = "content",
                        Align = TextAlign.Left,
                        TextStyle = null,
                        Color = null,
                        Bold = null,
                        Italic = null,
                        Strikethrough = null,
                        Underline = null,
                        Locales = null,
                        Format = null,
                    },
                },
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SendMessageRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Audiences
<details><summary><code>client.Audiences.<a href="/src/Courier.Client/Audiences/AudiencesClient.cs">GetAsync</a>(audienceId) -> Audience</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the specified audience by id.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Audiences.GetAsync("audience_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**audienceId:** `string` — A unique identifier representing the audience_id
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Audiences.<a href="/src/Courier.Client/Audiences/AudiencesClient.cs">UpdateAsync</a>(audienceId, AudienceUpdateParams { ... }) -> AudienceUpdateResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates or updates audience.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Audiences.UpdateAsync(
    "audience_id",
    new AudienceUpdateParams
    {
        Name = null,
        Description = null,
        Filter = null,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**audienceId:** `string` — A unique identifier representing the audience id
    
</dd>
</dl>

<dl>
<dd>

**request:** `AudienceUpdateParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Audiences.<a href="/src/Courier.Client/Audiences/AudiencesClient.cs">DeleteAsync</a>(audienceId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes the specified audience.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Audiences.DeleteAsync("audience_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**audienceId:** `string` — A unique identifier representing the audience id
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Audiences.<a href="/src/Courier.Client/Audiences/AudiencesClient.cs">ListMembersAsync</a>(audienceId, AudienceMembersListParams { ... }) -> AudienceMemberListResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get list of members of an audience.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Audiences.ListMembersAsync("audience_id", new AudienceMembersListParams());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**audienceId:** `string` — A unique identifier representing the audience id
    
</dd>
</dl>

<dl>
<dd>

**request:** `AudienceMembersListParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Audiences.<a href="/src/Courier.Client/Audiences/AudiencesClient.cs">ListAudiencesAsync</a>(AudiencesListParams { ... }) -> AudienceListResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get the audiences associated with the authorization token.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Audiences.ListAudiencesAsync(new AudiencesListParams());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `AudiencesListParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## AuditEvents
<details><summary><code>client.AuditEvents.<a href="/src/Courier.Client/AuditEvents/AuditEventsClient.cs">ListAsync</a>(ListAuditEventsRequest { ... }) -> ListAuditEventsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetch the list of audit events
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AuditEvents.ListAsync(new ListAuditEventsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListAuditEventsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.AuditEvents.<a href="/src/Courier.Client/AuditEvents/AuditEventsClient.cs">GetAsync</a>(auditEventId) -> AuditEvent</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetch a specific audit event by ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AuditEvents.GetAsync("audit-event-id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**auditEventId:** `string` — A unique identifier associated with the audit event you wish to retrieve
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## AuthTokens
<details><summary><code>client.AuthTokens.<a href="/src/Courier.Client/AuthTokens/AuthTokensClient.cs">IssueTokenAsync</a>(IssueTokenParams { ... }) -> IssueTokenResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a new access token.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AuthTokens.IssueTokenAsync(
    new IssueTokenParams { Scope = "scope", ExpiresIn = "expires_in" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `IssueTokenParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Automations
<details><summary><code>client.Automations.<a href="/src/Courier.Client/Automations/AutomationsClient.cs">InvokeAutomationTemplateAsync</a>(templateId, AutomationInvokeParams { ... }) -> AutomationInvokeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Invoke an automation run from an automation template.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Automations.InvokeAutomationTemplateAsync(
    "templateId",
    new AutomationInvokeParams
    {
        Brand = null,
        Data = null,
        Profile = null,
        Recipient = null,
        Template = null,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**templateId:** `string` — A unique identifier representing the automation template to be invoked. This could be the Automation Template ID or the Automation Template Alias.
    
</dd>
</dl>

<dl>
<dd>

**request:** `AutomationInvokeParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Automations.<a href="/src/Courier.Client/Automations/AutomationsClient.cs">InvokeAdHocAutomationAsync</a>(AutomationAdHocInvokeParams { ... }) -> AutomationInvokeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Invoke an ad hoc automation run. This endpoint accepts a JSON payload with a series of automation steps. For information about what steps are available, checkout the ad hoc automation guide [here](https://www.courier.com/docs/automations/steps/).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Automations.InvokeAdHocAutomationAsync(
    new AutomationAdHocInvokeParams
    {
        Data = new Dictionary<string, object>() { { "name", "Foo" } },
        Profile = new Dictionary<object, object?>() { { "tenant_id", "abc-123" } },
        Recipient = "user-yes",
        Automation = new Automation
        {
            CancelationToken = "delay-send--user-yes--abc-123",
            Steps = new List<
                OneOf<
                    AutomationAddToDigestStep,
                    AutomationAddToBatchStep,
                    AutomationThrottleStep,
                    AutomationCancelStep,
                    AutomationDelayStep,
                    AutomationFetchDataStep,
                    AutomationInvokeStep,
                    AutomationSendStep,
                    AutomationV2SendStep,
                    AutomationSendListStep,
                    AutomationUpdateProfileStep
                >
            >()
            {
                new AutomationDelayStep { Action = "delay", Until = "20240408T080910.123" },
                new AutomationSendStep
                {
                    Action = "send",
                    Template = "64TP5HKPFTM8VTK1Y75SJDQX9JK0",
                },
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `AutomationAdHocInvokeParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Brands
<details><summary><code>client.Brands.<a href="/src/Courier.Client/Brands/BrandsClient.cs">CreateAsync</a>(BrandParameters { ... }) -> Brand</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Brands.CreateAsync(
    new BrandParameters
    {
        Id = null,
        Name = "name",
        Settings = new BrandSettings
        {
            Colors = null,
            Inapp = null,
            Email = null,
        },
        Snippets = null,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BrandParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Brands.<a href="/src/Courier.Client/Brands/BrandsClient.cs">GetAsync</a>(brandId) -> Brand</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetch a specific brand by brand ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Brands.GetAsync("brand_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**brandId:** `string` — A unique identifier associated with the brand you wish to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Brands.<a href="/src/Courier.Client/Brands/BrandsClient.cs">ListAsync</a>(ListBrandsRequest { ... }) -> BrandsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get the list of brands.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Brands.ListAsync(new ListBrandsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListBrandsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Brands.<a href="/src/Courier.Client/Brands/BrandsClient.cs">DeleteAsync</a>(brandId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a brand by brand ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Brands.DeleteAsync("brand_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**brandId:** `string` — A unique identifier associated with the brand you wish to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Brands.<a href="/src/Courier.Client/Brands/BrandsClient.cs">ReplaceAsync</a>(brandId, BrandUpdateParameters { ... }) -> Brand</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Replace an existing brand with the supplied values.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Brands.ReplaceAsync(
    "brand_id",
    new BrandUpdateParameters
    {
        Name = "name",
        Settings = null,
        Snippets = null,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**brandId:** `string` — A unique identifier associated with the brand you wish to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `BrandUpdateParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Bulk
<details><summary><code>client.Bulk.<a href="/src/Courier.Client/Bulk/BulkClient.cs">CreateJobAsync</a>(BulkCreateJobParams { ... }) -> BulkCreateJobResponse</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bulk.CreateJobAsync(
    new BulkCreateJobParams { Message = new InboundBulkMessage { Message = null } }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkCreateJobParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bulk.<a href="/src/Courier.Client/Bulk/BulkClient.cs">IngestUsersAsync</a>(jobId, BulkIngestUsersParams { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Ingest user data into a Bulk Job
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bulk.IngestUsersAsync(
    "job_id",
    new BulkIngestUsersParams
    {
        Users = new List<InboundBulkMessageUser>()
        {
            new InboundBulkMessageUser
            {
                Preferences = null,
                Profile = null,
                Recipient = null,
                Data = null,
                To = null,
            },
            new InboundBulkMessageUser
            {
                Preferences = null,
                Profile = null,
                Recipient = null,
                Data = null,
                To = null,
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**jobId:** `string` — A unique identifier representing the bulk job
    
</dd>
</dl>

<dl>
<dd>

**request:** `BulkIngestUsersParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bulk.<a href="/src/Courier.Client/Bulk/BulkClient.cs">RunJobAsync</a>(jobId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Run a bulk job
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bulk.RunJobAsync("job_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**jobId:** `string` — A unique identifier representing the bulk job
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bulk.<a href="/src/Courier.Client/Bulk/BulkClient.cs">GetJobAsync</a>(jobId) -> BulkGetJobResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get a bulk job
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bulk.GetJobAsync("job_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**jobId:** `string` — A unique identifier representing the bulk job
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bulk.<a href="/src/Courier.Client/Bulk/BulkClient.cs">GetUsersAsync</a>(jobId, BulkGetUsersParams { ... }) -> BulkGetJobUsersResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get Bulk Job Users
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bulk.GetUsersAsync("job_id", new BulkGetUsersParams());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**jobId:** `string` — A unique identifier representing the bulk job
    
</dd>
</dl>

<dl>
<dd>

**request:** `BulkGetUsersParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Inbound
<details><summary><code>client.Inbound.<a href="/src/Courier.Client/Inbound/InboundClient.cs">TrackAsync</a>(InboundTrackEvent { ... }) -> TrackAcceptedResponse</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Inbound.TrackAsync(
    new InboundTrackEvent
    {
        Event = "New Order Placed",
        MessageId = "4c62c457-b329-4bea-9bfc-17bba86c393f",
        UserId = "1234",
        Type = "track",
        Properties = new Dictionary<string, object>()
        {
            { "order_id", 123 },
            { "total_orders", 5 },
            { "last_order_id", 122 },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `InboundTrackEvent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Lists
<details><summary><code>client.Lists.<a href="/src/Courier.Client/Lists/ListsClient.cs">ListAsync</a>(GetAllListsRequest { ... }) -> ListGetAllResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns all of the lists, with the ability to filter based on a pattern.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Lists.ListAsync(new GetAllListsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetAllListsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Lists.<a href="/src/Courier.Client/Lists/ListsClient.cs">GetAsync</a>(listId) -> List</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a list based on the list ID provided.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Lists.GetAsync("list_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**listId:** `string` — A unique identifier representing the list you wish to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Lists.<a href="/src/Courier.Client/Lists/ListsClient.cs">UpdateAsync</a>(listId, ListPutParams { ... }) -> List</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create or replace an existing list with the supplied values.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Lists.UpdateAsync("list_id", new ListPutParams { Name = "name", Preferences = null });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**listId:** `string` — A unique identifier representing the list you wish to retrieve.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListPutParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Lists.<a href="/src/Courier.Client/Lists/ListsClient.cs">DeleteAsync</a>(listId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a list by list ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Lists.DeleteAsync("list_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**listId:** `string` — A unique identifier representing the list you wish to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Lists.<a href="/src/Courier.Client/Lists/ListsClient.cs">RestoreAsync</a>(listId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Restore a previously deleted list.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Lists.RestoreAsync("list_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**listId:** `string` — A unique identifier representing the list you wish to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Lists.<a href="/src/Courier.Client/Lists/ListsClient.cs">GetSubscribersAsync</a>(listId, GetSubscriptionForListRequest { ... }) -> ListGetSubscriptionsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get the list's subscriptions.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Lists.GetSubscribersAsync("list_id", new GetSubscriptionForListRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**listId:** `string` — A unique identifier representing the list you wish to retrieve.
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetSubscriptionForListRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Lists.<a href="/src/Courier.Client/Lists/ListsClient.cs">UpdateSubscribersAsync</a>(listId, SubscribeUsersToListRequest { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Subscribes the users to the list, overwriting existing subscriptions. If the list does not exist, it will be automatically created.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Lists.UpdateSubscribersAsync(
    "list_id",
    new SubscribeUsersToListRequest
    {
        Recipients = new List<PutSubscriptionsRecipient>()
        {
            new PutSubscriptionsRecipient { RecipientId = "recipientId", Preferences = null },
            new PutSubscriptionsRecipient { RecipientId = "recipientId", Preferences = null },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**listId:** `string` — A unique identifier representing the list you wish to retrieve.
    
</dd>
</dl>

<dl>
<dd>

**request:** `SubscribeUsersToListRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Lists.<a href="/src/Courier.Client/Lists/ListsClient.cs">AddSubscribersAsync</a>(listId, AddSubscribersToList { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Subscribes additional users to the list, without modifying existing subscriptions. If the list does not exist, it will be automatically created.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Lists.AddSubscribersAsync(
    "list_id",
    new AddSubscribersToList
    {
        Recipients = new List<PutSubscriptionsRecipient>()
        {
            new PutSubscriptionsRecipient { RecipientId = "recipientId", Preferences = null },
            new PutSubscriptionsRecipient { RecipientId = "recipientId", Preferences = null },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**listId:** `string` — A unique identifier representing the list you wish to retrieve.
    
</dd>
</dl>

<dl>
<dd>

**request:** `AddSubscribersToList` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Lists.<a href="/src/Courier.Client/Lists/ListsClient.cs">SubscribeAsync</a>(listId, userId, SubscribeUserToListRequest { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Subscribe a user to an existing list (note: if the List does not exist, it will be automatically created).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Lists.SubscribeAsync(
    "list_id",
    "user_id",
    new SubscribeUserToListRequest { Preferences = null }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**listId:** `string` — A unique identifier representing the list you wish to retrieve.
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` — A unique identifier representing the recipient associated with the list
    
</dd>
</dl>

<dl>
<dd>

**request:** `SubscribeUserToListRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Lists.<a href="/src/Courier.Client/Lists/ListsClient.cs">UnsubscribeAsync</a>(listId, userId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a subscription to a list by list ID and user ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Lists.UnsubscribeAsync("list_id", "user_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**listId:** `string` — A unique identifier representing the list you wish to retrieve.
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` — A unique identifier representing the recipient associated with the list
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Messages
<details><summary><code>client.Messages.<a href="/src/Courier.Client/Messages/MessagesClient.cs">ListAsync</a>(ListMessagesRequest { ... }) -> ListMessagesResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetch the statuses of messages you've previously sent.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Messages.ListAsync(new ListMessagesRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListMessagesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Messages.<a href="/src/Courier.Client/Messages/MessagesClient.cs">GetAsync</a>(messageId) -> MessageDetails</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetch the status of a message you've previously sent.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Messages.GetAsync("message_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**messageId:** `string` — A unique identifier associated with the message you wish to retrieve (results from a send).
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Messages.<a href="/src/Courier.Client/Messages/MessagesClient.cs">CancelAsync</a>(messageId) -> MessageDetails</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Cancel a message that is currently in the process of being delivered. A well-formatted API call to the cancel message API will return either `200` status code for a successful cancellation or `409` status code for an unsuccessful cancellation. Both cases will include the actual message record in the response body (see details below).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Messages.CancelAsync("message_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**messageId:** `string` — A unique identifier representing the message ID
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Messages.<a href="/src/Courier.Client/Messages/MessagesClient.cs">GetHistoryAsync</a>(messageId, GetMessageHistoryRequest { ... }) -> MessageHistoryResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetch the array of events of a message you've previously sent.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Messages.GetHistoryAsync("message_id", new GetMessageHistoryRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**messageId:** `string` — A unique identifier representing the message ID
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetMessageHistoryRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Messages.<a href="/src/Courier.Client/Messages/MessagesClient.cs">GetContentAsync</a>(messageId) -> RenderOutputResponse</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Messages.GetContentAsync("message_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**messageId:** `string` — A unique identifier associated with the message you wish to retrieve (results from a send).
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Messages.<a href="/src/Courier.Client/Messages/MessagesClient.cs">ArchiveAsync</a>(requestId)</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Messages.ArchiveAsync("request_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**requestId:** `string` — A unique identifier representing the request ID
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Notifications
<details><summary><code>client.Notifications.<a href="/src/Courier.Client/Notifications/NotificationsClient.cs">ListAsync</a>(NotificationListParams { ... }) -> NotificationListResponse</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Notifications.ListAsync(new NotificationListParams());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `NotificationListParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Notifications.<a href="/src/Courier.Client/Notifications/NotificationsClient.cs">GetContentAsync</a>(id) -> NotificationGetContentResponse</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Notifications.GetContentAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Notifications.<a href="/src/Courier.Client/Notifications/NotificationsClient.cs">GetDraftContentAsync</a>(id) -> NotificationGetContentResponse</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Notifications.GetDraftContentAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Notifications.<a href="/src/Courier.Client/Notifications/NotificationsClient.cs">GetSubmissionChecksAsync</a>(id, submissionId) -> SubmissionChecksGetResponse</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Notifications.GetSubmissionChecksAsync("id", "submissionId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**submissionId:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Notifications.<a href="/src/Courier.Client/Notifications/NotificationsClient.cs">ReplaceSubmissionChecksAsync</a>(id, submissionId, SubmissionChecksReplaceParams { ... }) -> SubmissionChecksReplaceResponse</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Notifications.ReplaceSubmissionChecksAsync(
    "id",
    "submissionId",
    new SubmissionChecksReplaceParams
    {
        Checks = new List<BaseCheck>()
        {
            new BaseCheck
            {
                Id = "id",
                Status = CheckStatus.Resolved,
                Type = "custom",
            },
            new BaseCheck
            {
                Id = "id",
                Status = CheckStatus.Resolved,
                Type = "custom",
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**submissionId:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `SubmissionChecksReplaceParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Notifications.<a href="/src/Courier.Client/Notifications/NotificationsClient.cs">CancelSubmissionAsync</a>(id, submissionId)</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Notifications.CancelSubmissionAsync("id", "submissionId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**submissionId:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Profiles
<details><summary><code>client.Profiles.<a href="/src/Courier.Client/Profiles/ProfilesClient.cs">GetAsync</a>(userId) -> ProfileGetResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the specified user profile.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Profiles.GetAsync("user_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — A unique identifier representing the user associated with the requested profile.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Profiles.<a href="/src/Courier.Client/Profiles/ProfilesClient.cs">CreateAsync</a>(userId, MergeProfileRequest { ... }) -> MergeProfileResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Merge the supplied values with an existing profile or create a new profile if one doesn't already exist.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Profiles.CreateAsync(
    "user_id",
    new MergeProfileRequest
    {
        Profile = new Dictionary<string, object>()
        {
            {
                "profile",
                new Dictionary<object, object?>() { { "key", "value" } }
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — A unique identifier representing the user associated with the requested profile.
    
</dd>
</dl>

<dl>
<dd>

**request:** `MergeProfileRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Profiles.<a href="/src/Courier.Client/Profiles/ProfilesClient.cs">ReplaceAsync</a>(userId, ReplaceProfileRequest { ... }) -> ReplaceProfileResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

When using `PUT`, be sure to include all the key-value pairs required by the recipient's profile.
Any key-value pairs that exist in the profile but fail to be included in the `PUT` request will be
removed from the profile. Remember, a `PUT` update is a full replacement of the data. For partial updates,
use the [Patch](https://www.courier.com/docs/reference/profiles/patch/) request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Profiles.ReplaceAsync(
    "user_id",
    new ReplaceProfileRequest
    {
        Profile = new Dictionary<string, object>()
        {
            {
                "profile",
                new Dictionary<object, object?>() { { "key", "value" } }
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — A unique identifier representing the user associated with the requested profile.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ReplaceProfileRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Profiles.<a href="/src/Courier.Client/Profiles/ProfilesClient.cs">MergeProfileAsync</a>(userId, IEnumerable<UserProfilePatch> { ... })</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Profiles.MergeProfileAsync(
    "user_id",
    new List<UserProfilePatch>()
    {
        new UserProfilePatch
        {
            Op = "op",
            Path = "path",
            Value = "value",
        },
        new UserProfilePatch
        {
            Op = "op",
            Path = "path",
            Value = "value",
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — A unique identifier representing the user associated with the requested profile.
    
</dd>
</dl>

<dl>
<dd>

**request:** `IEnumerable<UserProfilePatch>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Profiles.<a href="/src/Courier.Client/Profiles/ProfilesClient.cs">DeleteAsync</a>(userId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes the specified user profile.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Profiles.DeleteAsync("user_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — A unique identifier representing the user associated with the requested profile.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Profiles.<a href="/src/Courier.Client/Profiles/ProfilesClient.cs">GetListSubscriptionsAsync</a>(userId, GetListSubscriptionsRequest { ... }) -> GetListSubscriptionsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the subscribed lists for a specified user.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Profiles.GetListSubscriptionsAsync("user_id", new GetListSubscriptionsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — A unique identifier representing the user associated with the requested profile.
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetListSubscriptionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Profiles.<a href="/src/Courier.Client/Profiles/ProfilesClient.cs">SubscribeToListsAsync</a>(userId, SubscribeToListsRequest { ... }) -> SubscribeToListsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Subscribes the given user to one or more lists. If the list does not exist, it will be created.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Profiles.SubscribeToListsAsync(
    "user_id",
    new SubscribeToListsRequest
    {
        Lists = new List<SubscribeToListsRequestListObject>()
        {
            new SubscribeToListsRequestListObject { ListId = "listId", Preferences = null },
            new SubscribeToListsRequestListObject { ListId = "listId", Preferences = null },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — A unique identifier representing the user associated with the requested profile.
    
</dd>
</dl>

<dl>
<dd>

**request:** `SubscribeToListsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Profiles.<a href="/src/Courier.Client/Profiles/ProfilesClient.cs">DeleteListSubscriptionAsync</a>(userId) -> DeleteListSubscriptionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Removes all list subscriptions for given user.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Profiles.DeleteListSubscriptionAsync("user_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — A unique identifier representing the user associated with the requested profile.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Templates
<details><summary><code>client.Templates.<a href="/src/Courier.Client/Templates/TemplatesClient.cs">ListAsync</a>(ListTemplatesRequest { ... }) -> ListTemplatesResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a list of notification templates
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Templates.ListAsync(new ListTemplatesRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListTemplatesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Tenants
<details><summary><code>client.Tenants.<a href="/src/Courier.Client/Tenants/TenantsClient.cs">CreateOrReplaceAsync</a>(tenantId, TenantCreateOrReplaceParams { ... }) -> Tenant</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Tenants.CreateOrReplaceAsync(
    "tenant_id",
    new TenantCreateOrReplaceParams
    {
        Name = "name",
        ParentTenantId = null,
        DefaultPreferences = null,
        Properties = null,
        UserProfile = null,
        BrandId = null,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**tenantId:** `string` — A unique identifier representing the tenant to be returned.
    
</dd>
</dl>

<dl>
<dd>

**request:** `TenantCreateOrReplaceParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Tenants.<a href="/src/Courier.Client/Tenants/TenantsClient.cs">GetAsync</a>(tenantId) -> Tenant</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Tenants.GetAsync("tenant_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**tenantId:** `string` — A unique identifier representing the tenant to be returned.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Tenants.<a href="/src/Courier.Client/Tenants/TenantsClient.cs">ListAsync</a>(ListTenantParams { ... }) -> TenantListResponse</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Tenants.ListAsync(new ListTenantParams());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListTenantParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Tenants.<a href="/src/Courier.Client/Tenants/TenantsClient.cs">DeleteAsync</a>(tenantId)</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Tenants.DeleteAsync("tenant_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**tenantId:** `string` — Id of the tenant to be deleted.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Tenants.<a href="/src/Courier.Client/Tenants/TenantsClient.cs">GetUsersByTenantAsync</a>(tenantId, ListUsersForTenantParams { ... }) -> ListUsersForTenantResponse</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Tenants.GetUsersByTenantAsync("tenant_id", new ListUsersForTenantParams());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**tenantId:** `string` — Id of the tenant for user membership.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListUsersForTenantParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Tenants.<a href="/src/Courier.Client/Tenants/TenantsClient.cs">CreateOrReplaceDefaultPreferencesForTopicAsync</a>(tenantId, topicId, SubscriptionTopicNew { ... })</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Tenants.CreateOrReplaceDefaultPreferencesForTopicAsync(
    "tenantABC",
    "HB529N49MD4D5PMX9WR5P4JH78NA",
    new SubscriptionTopicNew
    {
        Status = SubscriptionTopicStatus.OptedIn,
        HasCustomRouting = true,
        CustomRouting = new List<ChannelClassification>() { ChannelClassification.Inbox },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**tenantId:** `string` — Id of the tenant to update the default preferences for.
    
</dd>
</dl>

<dl>
<dd>

**topicId:** `string` — Id fo the susbcription topic you want to have a default preference for.
    
</dd>
</dl>

<dl>
<dd>

**request:** `SubscriptionTopicNew` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Tenants.<a href="/src/Courier.Client/Tenants/TenantsClient.cs">RemoveDefaultPreferencesForTopicAsync</a>(tenantId, topicId)</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Tenants.RemoveDefaultPreferencesForTopicAsync("tenant_id", "topic_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**tenantId:** `string` — Id of the tenant to update the default preferences for.
    
</dd>
</dl>

<dl>
<dd>

**topicId:** `string` — Id fo the susbcription topic you want to have a default preference for.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Translations
<details><summary><code>client.Translations.<a href="/src/Courier.Client/Translations/TranslationsClient.cs">GetAsync</a>(domain, locale) -> string</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get translations by locale
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Translations.GetAsync("domain", "locale");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**domain:** `string` — The domain you want to retrieve translations for. Only `default` is supported at the moment
    
</dd>
</dl>

<dl>
<dd>

**locale:** `string` — The locale you want to retrieve the translations for
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Translations.<a href="/src/Courier.Client/Translations/TranslationsClient.cs">UpdateAsync</a>(domain, locale, string { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update a translation
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Translations.UpdateAsync("domain", "locale", "string");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**domain:** `string` — The domain you want to retrieve translations for. Only `default` is supported at the moment
    
</dd>
</dl>

<dl>
<dd>

**locale:** `string` — The locale you want to retrieve the translations for
    
</dd>
</dl>

<dl>
<dd>

**request:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users Preferences
<details><summary><code>client.Users.Preferences.<a href="/src/Courier.Client/Users/Preferences/PreferencesClient.cs">ListAsync</a>(userId, UserPreferencesParams { ... }) -> UserPreferencesListResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetch all user preferences.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Preferences.ListAsync("user_id", new UserPreferencesParams());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — A unique identifier associated with the user whose preferences you wish to retrieve.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UserPreferencesParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Preferences.<a href="/src/Courier.Client/Users/Preferences/PreferencesClient.cs">GetAsync</a>(userId, topicId, UserPreferencesTopicParams { ... }) -> UserPreferencesGetResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetch user preferences for a specific subscription topic.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Preferences.GetAsync("user_id", "topic_id", new UserPreferencesTopicParams());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — A unique identifier associated with the user whose preferences you wish to retrieve.
    
</dd>
</dl>

<dl>
<dd>

**topicId:** `string` — A unique identifier associated with a subscription topic.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UserPreferencesTopicParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Preferences.<a href="/src/Courier.Client/Users/Preferences/PreferencesClient.cs">UpdateAsync</a>(userId, topicId, UserPreferencesUpdateParams { ... }) -> UserPreferencesUpdateResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update or Create user preferences for a specific subscription topic.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Preferences.UpdateAsync(
    "abc-123",
    "74Q4QGFBEX481DP6JRPMV751H4XT",
    new UserPreferencesUpdateParams
    {
        Topic = new TopicPreferenceUpdate
        {
            Status = PreferenceStatus.OptedIn,
            HasCustomRouting = true,
            CustomRouting = new List<ChannelClassification>()
            {
                ChannelClassification.Inbox,
                ChannelClassification.Email,
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — A unique identifier associated with the user whose preferences you wish to retrieve.
    
</dd>
</dl>

<dl>
<dd>

**topicId:** `string` — A unique identifier associated with a subscription topic.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UserPreferencesUpdateParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users Tenants
<details><summary><code>client.Users.Tenants.<a href="/src/Courier.Client/Users/Tenants/TenantsClient.cs">AddMultpleAsync</a>(userId, AddUserToMultipleTenantsParams { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint is used to add a user to
multiple tenants in one call.
A custom profile can also be supplied for each tenant.
This profile will be merged with the user's main
profile when sending to the user with that tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Tenants.AddMultpleAsync(
    "user_id",
    new AddUserToMultipleTenantsParams
    {
        Tenants = new List<UserTenantAssociation>()
        {
            new UserTenantAssociation
            {
                UserId = null,
                Type = null,
                TenantId = "tenant_id",
                Profile = null,
            },
            new UserTenantAssociation
            {
                UserId = null,
                Type = null,
                TenantId = "tenant_id",
                Profile = null,
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — The user's ID. This can be any uniquely identifiable string.
    
</dd>
</dl>

<dl>
<dd>

**request:** `AddUserToMultipleTenantsParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Tenants.<a href="/src/Courier.Client/Users/Tenants/TenantsClient.cs">AddAsync</a>(userId, tenantId, AddUserToSingleTenantsParams { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint is used to add a single tenant.

A custom profile can also be supplied with the tenant.
This profile will be merged with the user's main profile
when sending to the user with that tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Tenants.AddAsync(
    "user_id",
    "tenant_id",
    new AddUserToSingleTenantsParams { Profile = null }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — Id of the user to be added to the supplied tenant.
    
</dd>
</dl>

<dl>
<dd>

**tenantId:** `string` — Id of the tenant the user should be added to.
    
</dd>
</dl>

<dl>
<dd>

**request:** `AddUserToSingleTenantsParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Tenants.<a href="/src/Courier.Client/Users/Tenants/TenantsClient.cs">RemoveAllAsync</a>(userId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Removes a user from any tenants they may have been associated with.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Tenants.RemoveAllAsync("user_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — Id of the user to be removed from the supplied tenant.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Tenants.<a href="/src/Courier.Client/Users/Tenants/TenantsClient.cs">RemoveAsync</a>(userId, tenantId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Removes a user from the supplied tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Tenants.RemoveAsync("user_id", "tenant_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — Id of the user to be removed from the supplied tenant.
    
</dd>
</dl>

<dl>
<dd>

**tenantId:** `string` — Id of the tenant the user should be removed from.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Tenants.<a href="/src/Courier.Client/Users/Tenants/TenantsClient.cs">ListAsync</a>(userId, ListTenantsForUserParams { ... }) -> ListTenantsForUserResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a paginated list of user tenant associations.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Tenants.ListAsync("user_id", new ListTenantsForUserParams());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — Id of the user to retrieve all associated tenants for.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListTenantsForUserParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users Tokens
<details><summary><code>client.Users.Tokens.<a href="/src/Courier.Client/Users/Tokens/TokensClient.cs">AddMultipleAsync</a>(userId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Adds multiple tokens to a user and overwrites matching existing tokens.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Tokens.AddMultipleAsync("user_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — The user's ID. This can be any uniquely identifiable string.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Tokens.<a href="/src/Courier.Client/Users/Tokens/TokensClient.cs">AddAsync</a>(userId, token, UserToken { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Adds a single token to a user and overwrites a matching existing token.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Tokens.AddAsync(
    "user_id",
    "token",
    new UserToken
    {
        Token = null,
        ProviderKey = ProviderKey.FirebaseFcm,
        ExpiryDate = null,
        Properties = null,
        Device = null,
        Tracking = null,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — The user's ID. This can be any uniquely identifiable string.
    
</dd>
</dl>

<dl>
<dd>

**token:** `string` — The full token string.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UserToken` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Tokens.<a href="/src/Courier.Client/Users/Tokens/TokensClient.cs">UpdateAsync</a>(userId, token, PatchUserTokenOpts { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Apply a JSON Patch (RFC 6902) to the specified token.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Tokens.UpdateAsync(
    "user_id",
    "token",
    new PatchUserTokenOpts
    {
        Patch = new List<PatchOperation>()
        {
            new PatchOperation
            {
                Op = "op",
                Path = "path",
                Value = null,
            },
            new PatchOperation
            {
                Op = "op",
                Path = "path",
                Value = null,
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — The user's ID. This can be any uniquely identifiable string.
    
</dd>
</dl>

<dl>
<dd>

**token:** `string` — The full token string.
    
</dd>
</dl>

<dl>
<dd>

**request:** `PatchUserTokenOpts` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Tokens.<a href="/src/Courier.Client/Users/Tokens/TokensClient.cs">GetAsync</a>(userId, token) -> GetUserTokenResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get single token available for a `:token`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Tokens.GetAsync("user_id", "token");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — The user's ID. This can be any uniquely identifiable string.
    
</dd>
</dl>

<dl>
<dd>

**token:** `string` — The full token string.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Tokens.<a href="/src/Courier.Client/Users/Tokens/TokensClient.cs">ListAsync</a>(userId) -> IEnumerable<UserToken></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Gets all tokens available for a :user_id
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Tokens.ListAsync("user_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — The user's ID. This can be any uniquely identifiable string.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Tokens.<a href="/src/Courier.Client/Users/Tokens/TokensClient.cs">DeleteAsync</a>(userId, token)</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Tokens.DeleteAsync("user_id", "token");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — The user's ID. This can be any uniquely identifiable string.
    
</dd>
</dl>

<dl>
<dd>

**token:** `string` — The full token string.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>
