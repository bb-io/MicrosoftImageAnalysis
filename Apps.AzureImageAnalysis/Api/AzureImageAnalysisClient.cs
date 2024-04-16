using Apps.AzureImageAnalysis.Constants;
using Apps.AzureImageAnalysis.Models.Response.Error;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.AzureImageAnalysis.Api;

public class AzureImageAnalysisClient : BlackBirdRestClient
{
    public AzureImageAnalysisClient(AuthenticationCredentialsProvider[] creds) :
        base(new()
        {
            BaseUrl = creds.Get(CredsNames.Endpoint).Value.ToUri()
        })
    {
    }

    protected override Exception ConfigureErrorException(RestResponse response)
    {
        if (string.IsNullOrEmpty(response.Content))
            return new(response.ErrorMessage);
        
        var error = JsonConvert.DeserializeObject<ErrorResponse>(response.Content!)!;
        return new(error.Error.Message);
    }
}