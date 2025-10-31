using System.Threading.Tasks;
using Courier.Models.Send;

namespace Courier.Services.Send;

public interface ISendService
{
    /// <summary>
    /// API to send a message to one or more recipients.
    /// </summary>
    Task<SendMessageResponse> Message(SendMessageParams parameters);
}
