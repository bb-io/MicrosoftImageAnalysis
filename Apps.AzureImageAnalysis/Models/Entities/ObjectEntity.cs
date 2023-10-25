using Blackbird.Applications.Sdk.Common;

namespace Apps.AzureImageAnalysis.Models.Entities;

public class ObjectEntity
{
    [Display("Bounding box")]
    public BoundingBoxEntity BoundingBox { get; set; }
    
    public TagEntity[] Tags { get; set; }
}