using System;
using System.Net.Http;
using TryCourier.Models.WorkspacePreferences;

namespace TryCourier.Tests.Models.WorkspacePreferences;

public class WorkspacePreferencePublishParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkspacePreferencePublishParams
        {
            BrandID = "bnd_01kx4mrd0pfzw8wt7pn7p2fzag",
            Description = "Choose what you hear from us about.",
            Heading = "Notification Preferences",
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        string expectedBrandID = "bnd_01kx4mrd0pfzw8wt7pn7p2fzag";
        string expectedDescription = "Choose what you hear from us about.";
        string expectedHeading = "Notification Preferences";
        string expectedIdempotencyKey = "order-ORD-456-user-123";
        string expectedXIdempotencyExpiration = "1785312000";

        Assert.Equal(expectedBrandID, parameters.BrandID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedHeading, parameters.Heading);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXIdempotencyExpiration, parameters.XIdempotencyExpiration);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkspacePreferencePublishParams
        {
            BrandID = "bnd_01kx4mrd0pfzw8wt7pn7p2fzag",
            Description = "Choose what you hear from us about.",
            Heading = "Notification Preferences",
        };

        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XIdempotencyExpiration);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-idempotency-expiration"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WorkspacePreferencePublishParams
        {
            BrandID = "bnd_01kx4mrd0pfzw8wt7pn7p2fzag",
            Description = "Choose what you hear from us about.",
            Heading = "Notification Preferences",

            // Null should be interpreted as omitted for these properties
            IdempotencyKey = null,
            XIdempotencyExpiration = null,
        };

        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XIdempotencyExpiration);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-idempotency-expiration"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkspacePreferencePublishParams
        {
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        Assert.Null(parameters.BrandID);
        Assert.False(parameters.RawBodyData.ContainsKey("brand_id"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Heading);
        Assert.False(parameters.RawBodyData.ContainsKey("heading"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WorkspacePreferencePublishParams
        {
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",

            BrandID = null,
            Description = null,
            Heading = null,
        };

        Assert.Null(parameters.BrandID);
        Assert.True(parameters.RawBodyData.ContainsKey("brand_id"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Heading);
        Assert.True(parameters.RawBodyData.ContainsKey("heading"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkspacePreferencePublishParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/preferences/publish"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WorkspacePreferencePublishParams parameters = new()
        {
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(
            ["order-ORD-456-user-123"],
            requestMessage.Headers.GetValues("Idempotency-Key")
        );
        Assert.Equal(["1785312000"], requestMessage.Headers.GetValues("x-idempotency-expiration"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkspacePreferencePublishParams
        {
            BrandID = "bnd_01kx4mrd0pfzw8wt7pn7p2fzag",
            Description = "Choose what you hear from us about.",
            Heading = "Notification Preferences",
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        WorkspacePreferencePublishParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
