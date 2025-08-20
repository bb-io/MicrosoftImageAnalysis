using Apps.AzureImageAnalysis.Constants;
using Apps.AzureImageAnalysis.Models.Response.Error;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Exceptions;
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

    public override async Task<T> ExecuteWithErrorHandling<T>(RestRequest request)
    {
        string content = (await ExecuteWithErrorHandling(request)).Content;
        T val = JsonConvert.DeserializeObject<T>(content, JsonSettings);
        if (val == null)
        {
            throw new Exception($"Could not parse {content} to {typeof(T)}");
        }

        return val;
    }

    public override async Task<RestResponse> ExecuteWithErrorHandling(RestRequest request)
    {
        RestResponse restResponse = await ExecuteAsync(request);
        if (!restResponse.IsSuccessStatusCode)
        {
            throw ConfigureErrorException(restResponse);
        }

        return restResponse;
    }

    protected override Exception ConfigureErrorException(RestResponse response)
    {
        if (string.IsNullOrEmpty(response.Content))
            return new(response.ErrorMessage);
        
        var error = JsonConvert.DeserializeObject<ErrorResponse>(response.Content!)!;
        throw new PluginApplicationException(error.Error.Message);
    }
}