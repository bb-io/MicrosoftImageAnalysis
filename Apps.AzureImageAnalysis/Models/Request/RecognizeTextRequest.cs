using Apps.AzureImageAnalysis.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.AzureImageAnalysis.Models.Request;

public class RecognizeTextRequest
{
    public FileReference File { get; set; } = new();

    [Display("Pages", Description = "Custom page numbers for multi-page documents(PDF/TIFF), input the number of the pages you want to get OCR result.")]
    public IEnumerable<string>? Pages { get; set; }
    
    [StaticDataSource(typeof(LanguageDataHandler))]
    public string? Language { get; set; }
}