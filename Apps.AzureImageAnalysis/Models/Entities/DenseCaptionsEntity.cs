using Blackbird.Applications.Sdk.Common;

namespace Apps.AzureImageAnalysis.Models.Entities;

public class DenseCaptionsEntity : CaptionEntity
{
    [Display("Bounding box")]
    public BoundingBoxEntity BoundingBox { get; set; }
}