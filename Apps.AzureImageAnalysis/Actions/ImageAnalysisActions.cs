using System.Net.Mime;
using Apps.AzureImageAnalysis.Api;
using Apps.AzureImageAnalysis.Constants;
using Apps.AzureImageAnalysis.Invocables;
using Apps.AzureImageAnalysis.Models.Entities;
using Apps.AzureImageAnalysis.Models.Request;
using Apps.AzureImageAnalysis.Models.Response;
using Apps.AzureImageAnalysis.Models.Response.Base;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using RestSharp;

namespace Apps.AzureImageAnalysis.Actions;

[ActionList]
public class ImageAnalysisActions : AzureImageAnalysisInvocable
{
    public ImageAnalysisActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("Analyze image tags", Description = "Analyze tags of the specified image")]
    public async Task<TagsResponse> AnalyzeTags(
        [ActionParameter] AnalyzeImageRequest input,
        [ActionParameter] AnalyzeImageQuery query)
    {
        var request = PrepareRequest(input, query, AnalysisFeatures.Tags);
      
        var response = await Client.ExecuteWithErrorHandling<AnalysisResponse>(request);
        return response.TagsResult;
    }
    
    [Action("Analyze image people", Description = "Analyze people of the specified image")]
    public async Task<PeopleResponse> AnalyzePeople(
        [ActionParameter] AnalyzeImageRequest input,
        [ActionParameter] AnalyzeImageQuery query)
    {
        var request = PrepareRequest(input, query, AnalysisFeatures.People);
      
        var response = await Client.ExecuteWithErrorHandling<AnalysisResponse>(request);
        return response.PeopleResult;
    } 
    
    [Action("Analyze image objects", Description = "Analyze objects of the specified image")]
    public async Task<ObjectsResponse> AnalyzeObjects(
        [ActionParameter] AnalyzeImageRequest input,
        [ActionParameter] AnalyzeImageQuery query)
    {
        var request = PrepareRequest(input, query, AnalysisFeatures.Objects);
      
        var response = await Client.ExecuteWithErrorHandling<AnalysisResponse>(request);
        return response.ObjectsResult;
    }
    
    [Action("Get image description", Description = "Analyze image and get its text description")]
    public async Task<CaptionEntity> AnalyzeCaptions(
        [ActionParameter] AnalyzeImageRequest input,
        [ActionParameter] CaptionAnalysisQuery query)
    {
        var request = PrepareRequest(input, query, AnalysisFeatures.Caption);
      
        var response = await Client.ExecuteWithErrorHandling<AnalysisResponse>(request);
        return response.CaptionResult;
    }    
    
    [Action("Get dense image descriptions", Description = "Get dense image description analysis")]
    public async Task<DenseCaptionsResponse> AnalyzeDenseCaptions(
        [ActionParameter] AnalyzeImageRequest input,
        [ActionParameter] CaptionAnalysisQuery query)
    {
        var request = PrepareRequest(input, query, AnalysisFeatures.DenseCaptions);
      
        var response = await Client.ExecuteWithErrorHandling<AnalysisResponse>(request);
        return response.DenseCaptionsResult;
    }
    
    private RestRequest PrepareRequest(AnalyzeImageRequest input, AnalyzeImageQuery query, string feature)
    {
        var endpoint = ApiEndpoints.Analysis.WithQuery(query)
            .SetQueryParameter("api-version", ApiConstants.ApiVersion)
            .SetQueryParameter("features", feature);

        return new AzureImageAnalysisRequest(endpoint, Method.Post, Creds)
            .AddParameter(MediaTypeNames.Image.Jpeg, input.File.Bytes, ParameterType.RequestBody);
    }
}