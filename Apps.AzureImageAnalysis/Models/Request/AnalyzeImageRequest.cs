using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.AzureImageAnalysis.Models.Request;

public class AnalyzeImageRequest
{
    public FileReference File { get; set; }
}