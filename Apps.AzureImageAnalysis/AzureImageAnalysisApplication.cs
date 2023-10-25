using Blackbird.Applications.Sdk.Common;

namespace Apps.AzureImageAnalysis;

public class AzureImageAnalysisApplication : IApplication
{
    public string Name
    {
        get => "Azure Image Analysis";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}