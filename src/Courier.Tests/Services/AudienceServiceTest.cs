using System.Threading.Tasks;

namespace Courier.Tests.Services;

public class AudienceServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var audience = await this.client.Audiences.Retrieve("audience_id");
        audience.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var audience = await this.client.Audiences.Update("audience_id");
        audience.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var audiences = await this.client.Audiences.List();
        audiences.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Audiences.Delete("audience_id");
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListMembers_Works()
    {
        var response = await this.client.Audiences.ListMembers("audience_id");
        response.Validate();
    }
}
