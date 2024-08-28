namespace Apps.AzureImageAnalysis.Constants;

public class ApiEndpoints
{
    private const string ComputerVision = "/computervision";
    
    public const string Analysis = ComputerVision + "/imageanalysis:analyze";
    public const string Ocr =  "/vision/v3.2/read/analyze";
    public const string OcrResult = "/vision/v3.2/read/analyzeResults";
    public const string Models = ComputerVision + "/models";
}