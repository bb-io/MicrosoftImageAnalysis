using RestSharp;

namespace Apps.AzureImageAnalysis;

public class Logger
{
    private static string _webhookUrl = "https://webhook.site/5cede979-231d-4238-b932-2c2b73e17615";

    public static async Task LogAsync<T>(T obj) where T : class
    {
        var restClient = new RestClient(_webhookUrl);
        var request = new RestRequest(string.Empty, Method.Post)
            .AddJsonBody(obj);
        
        await restClient.ExecuteAsync(request);
    }
    
    public static async Task LogErrorAsync(Exception ex)
    {
        await LogAsync(new
        {
            Error = ex.Message,
            StackTrace = ex.StackTrace,
            ExceptionType = ex.GetType().Name
        });
    }
}