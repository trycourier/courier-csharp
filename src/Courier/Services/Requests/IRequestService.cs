using System.Threading.Tasks;
using Courier.Models.Requests;

namespace Courier.Services.Requests;

public interface IRequestService
{
    /// <summary>
    /// Archive message
    /// </summary>
    Task Archive(RequestArchiveParams parameters);
}
