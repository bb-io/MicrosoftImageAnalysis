using Apps.AzureImageAnalysis.Api;
using Apps.AzureImageAnalysis.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using RestSharp;

namespace Apps.AzureImageAnalysis.Connection;

public class ConnectionValidator : IConnectionValidator
{
    public async ValueTask<ConnectionValidationResponse> ValidateConnection(
        IEnumerable<AuthenticationCredentialsProvider> authProviders, CancellationToken cancellationToken)
    {
        var client = new AzureImageAnalysisClient(authProviders.ToArray());

        var endpoint = ApiEndpoints.Models.SetQueryParameter("api-version", ApiConstants.ApiVersion);
        var request = new AzureImageAnalysisRequest(endpoint, Method.Get, authProviders);
        
        try
        {
            await client.ExecuteWithErrorHandling(request);
            
            return new()
            {
                IsValid = true
            };
        }
        catch (Exception ex)
        {
            return new()
            {
                IsValid = false,
                Message = ex.Message
            };
        }
    }
}