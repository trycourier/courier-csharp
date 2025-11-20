using System.Threading.Tasks;

namespace Courier.Tests.Services;

public class MessageServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var message = await this.client.Messages.Retrieve("message_id");
        message.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var messages = await this.client.Messages.List();
        messages.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Cancel_Works()
    {
        var messageDetails = await this.client.Messages.Cancel("message_id");
        messageDetails.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Content_Works()
    {
        var response = await this.client.Messages.Content("message_id");
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task History_Works()
    {
        var response = await this.client.Messages.History("message_id");
        response.Validate();
    }
}
