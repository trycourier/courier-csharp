using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Requests;

namespace Courier.Services;

public interface IRequestService
{
    IRequestService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Archive message
    /// </summary>
    Task Archive(RequestArchiveParams parameters, CancellationToken cancellationToken = default);
}
