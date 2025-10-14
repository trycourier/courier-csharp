using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models;
using Courier.Models.Tenants.Templates;

namespace Courier.Services.Tenants.Templates;

public sealed class TemplateService : ITemplateService
{
    readonly ICourierClient _client;

    public TemplateService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<BaseTemplateTenantAssociation> Retrieve(TemplateRetrieveParams parameters)
    {
        HttpRequest<TemplateRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<BaseTemplateTenantAssociation>().ConfigureAwait(false);
    }

    public async Task<TemplateListResponse> List(TemplateListParams parameters)
    {
        HttpRequest<TemplateListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<TemplateListResponse>().ConfigureAwait(false);
    }
}
