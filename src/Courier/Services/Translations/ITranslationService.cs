using System.Threading.Tasks;
using Courier.Models.Translations;

namespace Courier.Services.Translations;

public interface ITranslationService
{
    /// <summary>
    /// Get translations by locale
    /// </summary>
    Task<string> Retrieve(TranslationRetrieveParams parameters);

    /// <summary>
    /// Update a translation
    /// </summary>
    Task Update(TranslationUpdateParams parameters);
}
