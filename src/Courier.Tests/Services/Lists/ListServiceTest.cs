using System.Threading.Tasks;

namespace Courier.Tests.Services.Lists;

public class ListServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var list = await this.client.Lists.Retrieve(new() { ListID = "list_id" });
        list.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Lists.Update(new() { ListID = "list_id", Name = "name" });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var lists = await this.client.Lists.List();
        lists.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Lists.Delete(new() { ListID = "list_id" });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Restore_Works()
    {
        await this.client.Lists.Restore(new() { ListID = "list_id" });
    }
}
