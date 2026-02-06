using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Tenants;
using Courier.Models.Tenants.Templates.Versions;

namespace Courier.Services.Tenants.Templates;

/// <inheritdoc/>
public sealed class VersionService : IVersionService
{
    readonly Lazy<IVersionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVersionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IVersionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VersionService(this._client.WithOptions(modifier));
    }

    public VersionService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new VersionServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BaseTemplateTenantAssociation> Retrieve(
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BaseTemplateTenantAssociation> Retrieve(
        string version,
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { Version = version }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class VersionServiceWithRawResponse : IVersionServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVersionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VersionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VersionServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BaseTemplateTenantAssociation>> Retrieve(
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Version == null)
        {
            throw new CourierInvalidDataException("'parameters.Version' cannot be null");
        }

        HttpRequest<VersionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var baseTemplateTenantAssociation = await response
                    .Deserialize<BaseTemplateTenantAssociation>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    baseTemplateTenantAssociation.Validate();
                }
                return baseTemplateTenantAssociation;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BaseTemplateTenantAssociation>> Retrieve(
        string version,
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { Version = version }, cancellationToken);
    }
}
