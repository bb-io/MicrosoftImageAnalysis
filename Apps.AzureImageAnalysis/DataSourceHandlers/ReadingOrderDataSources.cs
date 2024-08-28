using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.AzureImageAnalysis.DataSourceHandlers;

public class ReadingOrderDataSources : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
    {
        return new()
        {
            { "default", "Default" },
            { "natural", "Natural" },
        };
    }
}