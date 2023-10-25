using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.AzureImageAnalysis.Models.Request;

public class CaptionAnalysisQuery : AnalyzeImageQuery
{
    [JsonProperty("gender-neutral-caption")]
    [Display("Gender neutral caption")]
    public bool? GenderNeutralCaption { get; set; }
}