using Apps.AzureImageAnalysis.Models.Entities;

namespace Apps.AzureImageAnalysis.Models.Response;

public class ObjectsResponse
{
    public ObjectEntity[] Values { get; set; }
}