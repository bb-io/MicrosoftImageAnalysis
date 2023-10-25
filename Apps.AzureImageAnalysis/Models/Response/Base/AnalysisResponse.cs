using Apps.AzureImageAnalysis.Models.Entities;

namespace Apps.AzureImageAnalysis.Models.Response.Base;

public class AnalysisResponse
{
    public TagsResponse TagsResult { get; set; }  
    
    public PeopleResponse PeopleResult { get; set; }  
    
    public ObjectsResponse ObjectsResult { get; set; }   
    
    public CaptionEntity CaptionResult { get; set; }   
    
    public DenseCaptionsResponse DenseCaptionsResult { get; set; }   
}