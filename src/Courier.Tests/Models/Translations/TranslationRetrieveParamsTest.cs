using Courier.Models.Translations;

namespace Courier.Tests.Models.Translations;

public class TranslationRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TranslationRetrieveParams { Domain = "domain", Locale = "locale" };

        string expectedDomain = "domain";
        string expectedLocale = "locale";

        Assert.Equal(expectedDomain, parameters.Domain);
        Assert.Equal(expectedLocale, parameters.Locale);
    }
}
