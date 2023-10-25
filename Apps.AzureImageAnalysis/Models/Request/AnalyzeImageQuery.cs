using Apps.AzureImageAnalysis.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.AzureImageAnalysis.Models.Request;

public class AnalyzeImageQuery
{
    [JsonProperty("language")]
    [DataSource(typeof(LanguageDataHandler))]
    public string? Language { get; set; }
    
    [JsonProperty("model-name")]
    [Display("Model name")]
    public string? ModelName { get; set; }
}