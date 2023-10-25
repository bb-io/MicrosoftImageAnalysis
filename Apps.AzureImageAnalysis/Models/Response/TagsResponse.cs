using Apps.AzureImageAnalysis.Models.Entities;

namespace Apps.AzureImageAnalysis.Models.Response;

public class TagsResponse
{
    public TagEntity[] Values { get; set; }
}