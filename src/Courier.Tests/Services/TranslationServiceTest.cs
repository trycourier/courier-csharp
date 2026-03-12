using System.Threading.Tasks;

namespace Courier.Tests.Services;

public class TranslationServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Translations.Retrieve(
            "locale",
            new() { Domain = "domain" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Translations.Update(
            "locale",
            new() { Domain = "domain", Body = "body" },
            TestContext.Current.CancellationToken
        );
    }
}
