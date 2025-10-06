using System.Threading.Tasks;

namespace Courier.Tests.Services.Messages;

public class MessageServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var message = await this.client.Messages.Retrieve(new() { MessageID = "message_id" });
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
        var messageDetails = await this.client.Messages.Cancel(new() { MessageID = "message_id" });
        messageDetails.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Content_Works()
    {
        var response = await this.client.Messages.Content(new() { MessageID = "message_id" });
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task History_Works()
    {
        var response = await this.client.Messages.History(new() { MessageID = "message_id" });
        response.Validate();
    }
}
