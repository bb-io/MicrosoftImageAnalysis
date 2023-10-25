namespace Apps.AzureImageAnalysis.Constants;

public class ApiEndpoints
{
    private const string ComputerVision = "/computervision";
    
    public const string Analysis = ComputerVision + "/imageanalysis:analyze";
    public const string Models = ComputerVision + "/models";
}