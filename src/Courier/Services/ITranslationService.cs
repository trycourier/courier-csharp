using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Translations;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITranslationService
{
    ITranslationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get translations by locale
    /// </summary>
    Task<string> Retrieve(
        TranslationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get translations by locale
    /// </summary>
    Task<string> Retrieve(
        string locale,
        TranslationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a translation
    /// </summary>
    Task Update(TranslationUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a translation
    /// </summary>
    Task Update(
        string locale,
        TranslationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );
}
