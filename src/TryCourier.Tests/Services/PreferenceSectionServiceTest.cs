using System.Threading.Tasks;

namespace TryCourier.Tests.Services;

public class PreferenceSectionServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var preferenceSectionGetResponse = await this.client.PreferenceSections.Create(
            new() { Name = "Account Notifications" },
            TestContext.Current.CancellationToken
        );
        preferenceSectionGetResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var preferenceSectionGetResponse = await this.client.PreferenceSections.Retrieve(
            "section_id",
            new(),
            TestContext.Current.CancellationToken
        );
        preferenceSectionGetResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var preferenceSectionListResponse = await this.client.PreferenceSections.List(
            new(),
            TestContext.Current.CancellationToken
        );
        preferenceSectionListResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Archive_Works()
    {
        await this.client.PreferenceSections.Archive(
            "section_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Publish_Works()
    {
        var publishPreferencesResponse = await this.client.PreferenceSections.Publish(
            new(),
            TestContext.Current.CancellationToken
        );
        publishPreferencesResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Replace_Works()
    {
        var preferenceSectionGetResponse = await this.client.PreferenceSections.Replace(
            "section_id",
            new() { Name = "name" },
            TestContext.Current.CancellationToken
        );
        preferenceSectionGetResponse.Validate();
    }
}
