using System.Net.Mime;
using Apps.AzureImageAnalysis.Api;
using Apps.AzureImageAnalysis.Constants;
using Apps.AzureImageAnalysis.Invocables;
using Apps.AzureImageAnalysis.Models.Request;
using Apps.AzureImageAnalysis.Models.Response;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;
using RestSharp;

namespace Apps.AzureImageAnalysis.Actions;

[ActionList]
public class OcrActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient)
    : AzureImageAnalysisInvocable(invocationContext)
{
    [Action("Recognize text", Description = "Recognize text in the specified image or document")]
    public async Task<RecognizeTextResponse> RecognizeText(
        [ActionParameter] RecognizeTextRequest input)
    {
        var file = await fileManagementClient.DownloadAsync(input.File);
        var fileBytes = await file.GetByteData();
        var request = new AzureImageAnalysisRequest(ApiEndpoints.Ocr, Method.Post, Creds)
            .AddFile("file", fileBytes, input.File.Name, input.File.ContentType);

        if (!string.IsNullOrEmpty(input.Language))
        {
            request = request.AddQueryParameter("language", input.Language);
        }

        if (input.Pages != null)
        {
            var pages = string.Join(",", input.Pages);
            request = request.AddQueryParameter("pages", pages);
        }

        var response = await Client.ExecuteWithErrorHandling(request);
        var operationLocation = response.Headers!.FirstOrDefault(x => x.Name == ApiHeaders.OperationLocation)?.Value
                                    ?.ToString()
                                ?? throw new Exception("Operation-Location header not found in response");

        var latestGuid = operationLocation.Split('/').Last();
        ReadTextEntity readTextEntity;
        do
        {
            var resultRequest =
                new AzureImageAnalysisRequest($"{ApiEndpoints.OcrResult}/{latestGuid}", Method.Get, Creds);
            readTextEntity = await Client.ExecuteWithErrorHandling<ReadTextEntity>(resultRequest);
            await Task.Delay(3000);
        } while (readTextEntity.Status == "running" || readTextEntity.Status == "notStarted");

        if (readTextEntity.Status == "failed")
            throw new Exception("The operation has failed.");

        return new(readTextEntity);
    }
}