using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.AzureImageAnalysis;

public class AzureImageAnalysisApplication : IApplication, ICategoryProvider
{
    public IEnumerable<ApplicationCategory> Categories
    {
        get => [ApplicationCategory.Multimedia, ApplicationCategory.AzureApps, ApplicationCategory.Microsoft365Apps];
        set { }
    }
    
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