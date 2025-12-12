using System.Threading.Tasks;

namespace Courier.Tests.Services;

public class ListServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var subscriptionList = await this.client.Lists.Retrieve(
            "list_id",
            new(),
            TestContext.Current.CancellationToken
        );
        subscriptionList.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Lists.Update(
            "list_id",
            new() { Name = "name" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var lists = await this.client.Lists.List(new(), TestContext.Current.CancellationToken);
        lists.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Lists.Delete("list_id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Restore_Works()
    {
        await this.client.Lists.Restore("list_id", new(), TestContext.Current.CancellationToken);
    }
}
