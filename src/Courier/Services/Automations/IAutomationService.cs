using Courier.Services.Automations.Invoke;

namespace Courier.Services.Automations;

public interface IAutomationService
{
    IInvokeService Invoke { get; }
}
