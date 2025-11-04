using System.Threading.Tasks;

namespace Courier.Tests.Services.Translations;

public class TranslationServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Translations.Retrieve(new() { Domain = "domain", Locale = "locale" });
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
