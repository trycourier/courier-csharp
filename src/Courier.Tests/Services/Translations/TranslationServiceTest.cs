using System.Threading.Tasks;

namespace Courier.Tests.Services.Translations;

public class TranslationServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var translation = await this.client.Translations.Retrieve(
            new() { Domain = "domain", Locale = "locale" }
        );
        _ = translation;
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Translations.Update(
            new()
            {
                Domain = "domain",
                Locale = "locale",
                Body = "body",
            }
        );
    }
}
