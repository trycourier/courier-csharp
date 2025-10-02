namespace Courier.Client.Core;

public interface IIsRetryableContent
{
    public bool IsRetryable { get; }
}
