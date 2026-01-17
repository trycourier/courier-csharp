using System;
using Courier.Models.Tenants.Templates;

namespace Courier.Tests.Models.Tenants.Templates;

public class TemplateRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateRetrieveParams
        {
            TenantID = "tenant_id",
            TemplateID = "template_id",
        };

        string expectedTenantID = "tenant_id";
        string expectedTemplateID = "template_id";

        Assert.Equal(expectedTenantID, parameters.TenantID);
        Assert.Equal(expectedTemplateID, parameters.TemplateID);
    }

    [Fact]
    public void Url_Works()
    {
        TemplateRetrieveParams parameters = new()
        {
            TenantID = "tenant_id",
            TemplateID = "template_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.courier.com/tenants/tenant_id/templates/template_id"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TemplateRetrieveParams
        {
            TenantID = "tenant_id",
            TemplateID = "template_id",
        };

        TemplateRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
