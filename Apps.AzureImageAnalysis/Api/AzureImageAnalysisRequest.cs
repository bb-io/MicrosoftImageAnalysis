using Apps.AzureImageAnalysis.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using RestSharp;

namespace Apps.AzureImageAnalysis.Api;

public class AzureImageAnalysisRequest : BlackBirdRestRequest
{
    public AzureImageAnalysisRequest(string resource, Method method, IEnumerable<AuthenticationCredentialsProvider> creds) : base(resource, method, creds)
    {
    }

    protected override void AddAuth(IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var token = creds.Get(CredsNames.ApiKey).Value;
        this.AddHeader("Ocp-Apim-Subscription-Key", token);
    }
}