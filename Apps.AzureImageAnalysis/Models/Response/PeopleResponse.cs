using Apps.AzureImageAnalysis.Models.Entities;

namespace Apps.AzureImageAnalysis.Models.Response;

public class PeopleResponse
{
    public PeopleEntity[] Values { get; set; }
}