using System;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Requests;

namespace Courier.Services.Requests;

public interface IRequestService
{
    IRequestService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Archive message
    /// </summary>
    Task Archive(RequestArchiveParams parameters);
}
