using Apps.AzureImageAnalysis.Models.Entities;

namespace Apps.AzureImageAnalysis.Models.Response;

public class DenseCaptionsResponse
{
    public DenseCaptionsEntity[] Values { get; set; }
}