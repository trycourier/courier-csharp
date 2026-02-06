using System;
using Courier.Models.Tenants.Templates;

namespace Courier.Tests.Models.Tenants.Templates;

public class TemplatePublishParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplatePublishParams
        {
            TenantID = "tenant_id",
            TemplateID = "template_id",
            Version = "version",
        };

        string expectedTenantID = "tenant_id";
        string expectedTemplateID = "template_id";
        string expectedVersion = "version";

        Assert.Equal(expectedTenantID, parameters.TenantID);
        Assert.Equal(expectedTemplateID, parameters.TemplateID);
        Assert.Equal(expectedVersion, parameters.Version);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplatePublishParams
        {
            TenantID = "tenant_id",
            TemplateID = "template_id",
        };

        Assert.Null(parameters.Version);
        Assert.False(parameters.RawBodyData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TemplatePublishParams
        {
            TenantID = "tenant_id",
            TemplateID = "template_id",

            // Null should be interpreted as omitted for these properties
            Version = null,
        };

        Assert.Null(parameters.Version);
        Assert.False(parameters.RawBodyData.ContainsKey("version"));
    }

    [Fact]
    public void Url_Works()
    {
        TemplatePublishParams parameters = new()
        {
            TenantID = "tenant_id",
            TemplateID = "template_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.courier.com/tenants/tenant_id/templates/template_id/publish"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TemplatePublishParams
        {
            TenantID = "tenant_id",
            TemplateID = "template_id",
            Version = "version",
        };

        TemplatePublishParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
