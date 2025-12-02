using Courier.Models.Users.Preferences;

namespace Courier.Tests.Models.Users.Preferences;

public class PreferenceUpdateOrCreateTopicResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreferenceUpdateOrCreateTopicResponse { Message = "success" };

        string expectedMessage = "success";

        Assert.Equal(expectedMessage, model.Message);
    }
}
