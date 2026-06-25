using System.Threading.Tasks;

namespace TryCourier.Tests.Services;

public class WorkspacePreferenceServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var workspacePreferenceGetResponse = await this.client.WorkspacePreferences.Create(
            new() { Name = "Account Notifications" },
            TestContext.Current.CancellationToken
        );
        workspacePreferenceGetResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var workspacePreferenceGetResponse = await this.client.WorkspacePreferences.Retrieve(
            "section_id",
            new(),
            TestContext.Current.CancellationToken
        );
        workspacePreferenceGetResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var workspacePreferenceListResponse = await this.client.WorkspacePreferences.List(
            new(),
            TestContext.Current.CancellationToken
        );
        workspacePreferenceListResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Archive_Works()
    {
        await this.client.WorkspacePreferences.Archive(
            "section_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Publish_Works()
    {
        var publishPreferencesResponse = await this.client.WorkspacePreferences.Publish(
            new(),
            TestContext.Current.CancellationToken
        );
        publishPreferencesResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Replace_Works()
    {
        var workspacePreferenceGetResponse = await this.client.WorkspacePreferences.Replace(
            "section_id",
            new() { Name = "name" },
            TestContext.Current.CancellationToken
        );
        workspacePreferenceGetResponse.Validate();
    }
}
