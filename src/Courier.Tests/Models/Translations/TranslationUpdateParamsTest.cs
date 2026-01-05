using Courier.Models.Translations;

namespace Courier.Tests.Models.Translations;

public class TranslationUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TranslationUpdateParams
        {
            Domain = "domain",
            Locale = "locale",
            Body = "body",
        };

        string expectedDomain = "domain";
        string expectedLocale = "locale";
        string expectedBody = "body";

        Assert.Equal(expectedDomain, parameters.Domain);
        Assert.Equal(expectedLocale, parameters.Locale);
        Assert.Equal(expectedBody, parameters.Body);
    }
}
