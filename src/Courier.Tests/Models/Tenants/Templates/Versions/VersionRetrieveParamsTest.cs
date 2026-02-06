using System;
using Courier.Models.Tenants.Templates.Versions;

namespace Courier.Tests.Models.Tenants.Templates.Versions;

public class VersionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VersionRetrieveParams
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
    public void Url_Works()
    {
        VersionRetrieveParams parameters = new()
        {
            TenantID = "tenant_id",
            TemplateID = "template_id",
            Version = "version",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.courier.com/tenants/tenant_id/templates/template_id/versions/version"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VersionRetrieveParams
        {
            TenantID = "tenant_id",
            TemplateID = "template_id",
            Version = "version",
        };

        VersionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
