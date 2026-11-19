using System.Threading.Tasks;
using TryCourier.Models.Feedback;

namespace TryCourier.Tests.Services;

public class FeedbackServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var feedback = await this.client.Feedback.Create(
            new()
            {
                Category = Category.PossibleBug,
                Description =
                    "GET /lists/{list_id}/subscriptions returned items: [] with paging.more set to true, and following the cursor returned the remaining subscribers.",
                Surface = Surface.Api,
                Title = "List subscriptions returns an empty page with a next cursor",
            },
            TestContext.Current.CancellationToken
        );
        feedback.Validate();
    }
}
