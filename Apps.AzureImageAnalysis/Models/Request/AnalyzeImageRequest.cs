using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.AzureImageAnalysis.Models.Request;

public class AnalyzeImageRequest
{
    public File File { get; set; }
}