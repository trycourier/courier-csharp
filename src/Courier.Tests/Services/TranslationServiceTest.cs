using System.Threading.Tasks;

namespace Courier.Tests.Services;

public class TranslationServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Translations.Retrieve("locale", new() { Domain = "domain" });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Translations.Update("locale", new() { Domain = "domain", Body = "body" });
    }
}
