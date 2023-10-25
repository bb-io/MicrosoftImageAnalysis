using Blackbird.Applications.Sdk.Common;

namespace Apps.AzureImageAnalysis.Models.Entities;

public class PeopleEntity
{
    [Display("Bounding box")]
    public BoundingBoxEntity BoundingBox { get; set; }
    
    public decimal Confidence { get; set; }
}