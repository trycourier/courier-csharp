using Courier.Models;

namespace Courier.Tests.Models;

public class MessageContextTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageContext { TenantID = "tenant_id" };

        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedTenantID, model.TenantID);
    }
}
