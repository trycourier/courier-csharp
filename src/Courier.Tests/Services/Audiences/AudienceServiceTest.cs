using System.Threading.Tasks;

namespace Courier.Tests.Services.Audiences;

public class AudienceServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var audience = await this.client.Audiences.Retrieve(new() { AudienceID = "audience_id" });
        audience.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var audience = await this.client.Audiences.Update(new() { AudienceID = "audience_id" });
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
        await this.client.Audiences.Delete(new() { AudienceID = "audience_id" });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListMembers_Works()
    {
        var response = await this.client.Audiences.ListMembers(
            new() { AudienceID = "audience_id" }
        );
        response.Validate();
    }
}
